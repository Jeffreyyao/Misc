import torch as T
from torch import nn
from tqdm import tqdm
from minesweeper_train_env import Minesweeper

env = Minesweeper(5,5,3) # P(mine|ij)=0.16

model = nn.Sequential(nn.Conv2d(1,20,3,padding=2), nn.ReLU(),
                      nn.Conv2d(20,40,3,padding=2), nn.ReLU(),
                      nn.Conv2d(40,20,3), nn.ReLU(),
                      nn.Conv2d(20,1,3), nn.Sigmoid())
criterion = nn.MSELoss()
optimizer = T.optim.SGD(model.parameters(), lr=0.1)

def get_train_data():
    env.reset()
    nn_input, _, _, _ = env.step(12) # center of the 5x5 map
    nn_input = nn_input.T
    nn_output = env.map.T
    return T.tensor([[nn_input]]).float(), T.tensor([[nn_output]]).float()

num_epoch = 500000
for _ in tqdm(range(num_epoch)):
    nn_input, nn_desired_output = get_train_data()
    optimizer.zero_grad()
    nn_output = model(nn_input)
    loss = criterion(nn_output, nn_desired_output)
    loss.backward()
    optimizer.step()

T.save(model,"minesweeper_model")
print("model saved")