import numpy as np
from random import random

class Minesweeper():
    def __init__(self, height, width, num_mines, render):
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

        if render:
            import pygame
            self.block_size = 50
            self.window_height = self.block_size * height
            self.window_width = self.block_size * width
            self.screen = pygame.display.set_mode((self.window_width, self.window_height))
            pygame.init()

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

    def drawGrid(self):
        import pygame
        for x in range(0, self.window_width, self.block_size):
            for y in range(0, self.window_height, self.block_size):
                rect = pygame.Rect(x, y, self.block_size, self.block_size)
                if self.state[int(x/self.block_size),int(y/self.block_size)]==-1:
                    pygame.draw.rect(self.screen, (255,255,255), rect, 1)
                else:
                    num = int(self.state[int(x/self.block_size),int(y/self.block_size)])
                    if num==0:
                        pygame.draw.rect(self.screen, (250,255,255), rect)
                    elif num==1:
                        pygame.draw.rect(self.screen, (220,220,220), rect)
                    elif num==2:
                        pygame.draw.rect(self.screen, (190,190,190), rect)
                    elif num==3:
                        pygame.draw.rect(self.screen, (160,160,160), rect)
                    elif num==4:
                        pygame.draw.rect(self.screen, (130,130,130), rect)
                    elif num==5:
                        pygame.draw.rect(self.screen, (100,100,100), rect)
                    else:
                        pygame.draw.rect(self.screen, (70,70,70), rect)
        pygame.display.update()

    def render(self):
        self.screen.fill((0,0,0))
        self.drawGrid()