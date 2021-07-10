from warnings import resetwarnings
import torch as T
import numpy as np
from minesweeper import Minesweeper
import time

# minesweeper model takes in a 5x5 0-centered state map
# outputs the probability of a mine present in each block
model = T.load("minesweeper_model_alt1")

sleep_interval = 0.2

prob_threshold = 0.95
height,width = 16,16
num_mines = 40
env = Minesweeper(height,width,num_mines)
done = False
env.reset()

# first move: open the center most block
state, _, done, _ = env.step((height*width)//2)
while state[height//2,width//2]!=0:
    env.reset()
    state, _, done, _ = env.step((height*width)//2)
env.render()

def get_5x5_block(state,x,y):
    return state[x-2:x+3,y-2:y+3]

max_steps = height*width-num_mines
visited = []

def get_all_01s(state):
    zeros = []
    for i in range(2,height-2):
        for j in range(2,width-2):
            if state[i,j]==1 or state[i,j]==0:
                zeros.append((i,j))
    return zeros

while not done:
    zeros_and_ones = get_all_01s(state)
    if len(zeros_and_ones)==len(visited):
        print("no more blocks to open")
        input()
        quit()
    for i,j in zeros_and_ones:
        if (i,j) not in visited:
            visited.append((i,j))
            nn_input = get_5x5_block(state,i,j)
            with T.no_grad():
                nn_output = 1-model(T.tensor([[nn_input]]).float()).numpy()[0][0]
                for a in range(5):
                    if nn_output[a,0]>prob_threshold and state[i+a-2,j-2]==-1:
                        state,_,done,_ = env.step(height*(i+a-2)+j-2)
                        time.sleep(sleep_interval)
                        env.render()
                        if done: break
                    if nn_output[a,4]>prob_threshold and state[i+a-2,j+2]==-1:
                        state,_,done,_ = env.step(height*(i+a-2)+j+2)
                        time.sleep(sleep_interval)
                        env.render()
                        if done: break
                for a in range(5):
                    if nn_output[0,a]>prob_threshold and state[i-2,j+a-2]==-1:
                        state,_,done,_ = env.step(height*(i-2)+a+j-2)
                        time.sleep(sleep_interval)
                        env.render()
                        if done: break
                    if nn_output[4,a]>prob_threshold and state[i+2,j+a-2]==-1:
                        state,_,done,_ = env.step(height*(i+2)+a+j-2)
                        time.sleep(sleep_interval)
                        env.render()
                        if done: break
print("stepped on bomb")
input()