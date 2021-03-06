import torch as T
import numpy as np
from minesweeper_train_env import Minesweeper

env = Minesweeper(5,5,3)
model = T.load("minesweeper_model_1")

def cmp(setup):
    env.reset()
    if setup:
        nn_input = []
        for i in range(5):
            print("Enter row", i)
            row = list(map(lambda x:int(x),input().split(",")))
            nn_input.append(row)
        nn_input = np.array(nn_input)
    else:
        nn_input, _, _, _ = env.step(12)
        nn_input = nn_input.T
        print("mine map:\n", env.map.T)

    nn_output = model(T.tensor([[nn_input]]).float())[0][0]
    
    with T.no_grad():
        print("given state input:\n", nn_input)
        print("prob of non-mine\n", 1-nn_output.numpy())

cmp(1)