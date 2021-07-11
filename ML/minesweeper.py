import numpy as np
from random import randrange
import pygame

class Minesweeper():

    # a minesweeper environment implemented in openai gym style
    # STATE
    #   given the map of height x width, numbers in each block of map:
    #   1. -1 denotes unopened block
    #   2. 0-8 denotes the number of mines in the surrounding 8 blocks of the block
    # MAP
    #   the map is unobervable to the agent where 0 is non-mine, 1 has a mine
    # ACTIONS
    #   action is Discrete(height*width) representing an attempt to open at the block's
    #   index when the map is flattened.
    # RESET
    #   be sure to call the reset function before using any other function in the class
    # STEP(ACTION)
    #   returns a four tuple: next_state, reward, done, _
    # RENDER
    #   renders the current state using pygame

    def __init__(self, height, width, num_mines):
        self.height = height
        self.width = width
        self.num_mines = num_mines
        self.win_reward = 50
        self.fail_reward = -10
        self.map = np.array([[False]*width for _ in range(height)])
        self.action_space = height*width
        self.state = np.zeros((height, width))-1
        self.step_cntr = 0
        self.step_cntr_max = (height*width-num_mines)*2

        self.block_size = 25
        self.window_height = self.block_size * height
        self.window_width = self.block_size * width
        self.map = None
        self.generate_mines()
        

    def generate_mines(self):
        self.map = np.array([[False]*self.width for _ in range(self.height)])
        for _ in range(self.num_mines):
            x = randrange(self.height)
            y = randrange(self.width)
            while self.map[x,y]:
                x = randrange(self.height)
                y = randrange(self.width)
            self.map[x,y] = True

    def reset(self):
        self.screen = pygame.display.set_mode((self.window_width, self.window_height))
        pygame.init()
        self.font = pygame.font.SysFont(pygame.font.get_default_font(), 20)
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
        for x in range(0, self.window_width, self.block_size):
            for y in range(0, self.window_height, self.block_size):
                rect = pygame.Rect(x, y, self.block_size, self.block_size)
                num = int(self.state[int(x/self.block_size),int(y/self.block_size)])
                if num==-1:
                    pygame.draw.rect(self.screen, (255,255,255), rect, 1)
                else:
                    color = (250, 250-num*30, 250-num*30)
                    pygame.draw.rect(self.screen, color, rect)
                    textsurface = self.font.render(str(num), False, (0, 0, 0))
                    self.screen.blit(textsurface,(x+self.block_size/3,y+self.block_size/3))
        pygame.display.update()

    def render(self):
        self.screen.fill((0,0,0))
        self.drawGrid()