import numpy as np
from random import random

class Minesweeper():
    def __init__(self, height, width, num_mines):
        self.height = height
        self.width = width
        self.num_mines = num_mines
        self.win_reward = 50
        self.fail_reward = -10
        self.action_space = height*width
        self.state = np.zeros((height, width))-1
        self.step_cntr = 0
        self.step_cntr_max = (height*width-num_mines)*2
        self.mine_density = 2*num_mines/self.action_space
        self.map = None
        self.generate_mines()
        

    def generate_mines(self):
        self.map = np.array([[0]*self.width for _ in range(self.height)])
        for i in range(self.height):
            if random()<=self.mine_density:
                self.map[i,0] = 1
            else:
                self.map[i,0] = 0
        for i in range(self.height):
            if random()<=self.mine_density:
                self.map[i,self.width-1] = 1
            else:
                self.map[i,self.width-1] = 0
        for i in range(self.width):
            if random()<=self.mine_density:
                self.map[0,i] = 1
            else:
                self.map[0,i] = 0
        for i in range(self.width):
            if random()<=self.mine_density:
                self.map[self.height-1,i] = 1
            else:
                self.map[self.height-1,i] = 0

        coords = np.array([[1,1],[1,2],[1,3],[2,1],[2,3],[3,1],[3,2],[3,3]])
        c = np.random.choice(8, 1, replace=False)# for block-n training
        for i in coords[c]:
            self.map[i[0],i[1]]= 1

    def reset(self):
        self.generate_mines()
        self.step_cntr = 0
        self.state = np.zeros((self.height, self.width))-1
        return self.state

    def get_num_opened(self):
        count = 0
        for i in self.state.flatten():
            if i>=0: count += 1
        return count

    def get_num_surr(self, x, y):
        count = 0
        for i in range(max(0,x-1), min(self.height,x+2)):
            for j in range(max(0,y-1), min(self.width,y+2)):
                if not (i==x and j==y):
                    if self.map[i,j]:
                        count += 1
        return count

    def update_state(self, x, y):
        num_surr = self.get_num_surr(x,y)
        self.state[x,y] = num_surr
        if num_surr==0:
            for i in range(max(0,x-1), min(self.height,x+2)):
                for j in range(max(0,y-1), min(self.width,y+2)):
                    if (not (i==x and j==y)) and self.state[i,j]==-1:
                        self.update_state(i,j)

    def step(self, action):
        if type(action)!=type(1):
            raise TypeError
        if action<0 or action>self.action_space-1:
            raise ValueError
        if self.step_cntr==self.step_cntr_max:
            return self.state, 0, True, None
        else:
            self.step_cntr += 1
        f_map = self.map.flatten()
        if f_map[action]:
            return self.state, self.fail_reward, True, None
        else:
            num_opened = self.get_num_opened()
            x,y = action//self.height,action%self.width
            if self.state[x,y]!=-1:
                return self.state, 0, False, None
            self.update_state(x,y)
            new_num_opened = self.get_num_opened()
            if new_num_opened==self.action_space-self.num_mines:
                return self.state, self.win_reward, True, None
            return self.state, new_num_opened-num_opened, False, None