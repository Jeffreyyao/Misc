import torch as T
from torch import nn
#from tqdm import tqdm
from minesweeper_train_env import Minesweeper

if __name__=="__main__":

    env = Minesweeper(5,5,3) # P(mine|ij)=0.16

    device = T.device('cuda:0' if T.cuda.is_available() else 'cpu')
    print(device)
    model = nn.Sequential(nn.Conv2d(1,20,3,padding=2), nn.ReLU(),
                        nn.Conv2d(20,40,3,padding=2), nn.ReLU(),
                        nn.Conv2d(40,20,3), nn.ReLU(),
                        nn.Conv2d(20,1,3), nn.Sigmoid()).to(device)
                        
    criterion = nn.MSELoss()
    optimizer = T.optim.SGD(model.parameters(), lr=0.1)

    def get_train_data():
        env.reset()
        #state, _, _, _ = env.step(12) # center of the 5x5 map

        # for block-1 training
        for i in range(6,17,5):
            for j in range(i,i+3):
                state, _, _, _ = env.step(j)

        nn_input = state
        nn_output = env.map
        return T.tensor([[nn_input]]).float().to(device), T.tensor([[nn_output]]).float().to(device)

    num_epoch = 200000
    for _ in range(num_epoch):
        nn_input, nn_desired_output = get_train_data()
        optimizer.zero_grad()
        nn_output = model(nn_input)
        loss = criterion(nn_output, nn_desired_output).to(device)
        loss.backward()
        optimizer.step()

    T.save(model,"minesweeper_model_1")
    print("model saved")