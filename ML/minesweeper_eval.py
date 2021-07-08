from warnings import resetwarnings
import torch as T
import numpy as np
from minesweeper import Minesweeper
import time

# minesweeper model takes in a 5x5 0-centered state map
# outputs the probability of a mine present in each block
model = T.load("minesweeper_model")

height,width = 9,9
num_mines = 10
env = Minesweeper(height,width,num_mines)
done = False
env.reset()

# first move: open the center most block
state, _, done, _ = env.step((height*width)//2)
while state[4,4]!=0:
    env.reset()
    state, _, done, _ = env.step((height*width)//2)
env.render()

def get_5x5_block(state,x,y):
    return state[x-2:x+3,y-2:y+3]

while not done:
    for i in range(2,height-2):
        for j in range(2,width-2):
            if state[i,j]==0:
                nn_input = get_5x5_block(state,i,j)
                with T.no_grad():
                    nn_output = 1-model(T.tensor([[nn_input]]).float()).numpy()[0][0]
                    for a in range(5):
                        if nn_output[a,0]>0.9:
                            state,_,done,_ = env.step(9*(i+a-2)+j-2)
                        if nn_output[a,4]>0.9:
                            state,_,done,_ = env.step(9*(i+a-2)+j+2)
                    for a in range(5):
                        if nn_output[0,a]>0.9:
                            state,_,done,_ = env.step(9*(i-2)+a+j-2)
                        if nn_output[4,a]>0.9:
                            state,_,done,_ = env.step(9*(i+2)+a+j-2)
env.render()
print("game end")
time.sleep(10000)