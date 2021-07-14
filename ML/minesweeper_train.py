import torch as T
from torch import nn
from tqdm import tqdm
from minesweeper_train_env import Minesweeper

class msnn(nn.Module):
    def __init__(self):
        super(msnn,self).__init__()
        self.fc1 = nn.Linear(25,64)
        self.fc2 = nn.Linear(64,256)
        self.fc3 = nn.Linear(256,1024)
        self.fc4 = nn.Linear(1024,64)
        self.fc5 = nn.Linear(64,25)
        self.device = T.device('cuda:0' if T.cuda.is_available() else 'cpu')
        self.to(self.device)

    def forward(self, state):
        x = state.flatten()
        x = T.relu(self.fc1(x))
        x = T.relu(self.fc2(x))
        x = T.relu(self.fc3(x))
        x = T.relu(self.fc4(x))
        x = T.sigmoid(self.fc5(x)).reshape(5,5)
        return x

if __name__=="__main__":

    env = Minesweeper(5,5,3) # P(mine|ij)=0.16

    device = T.device('cuda:0' if T.cuda.is_available() else 'cpu')
    print(device)
    # model = nn.Sequential(nn.Conv2d(1,20,3,padding=2), nn.ReLU(),
    #                      nn.Conv2d(20,40,3,padding=2), nn.ReLU(),
    #                      nn.Conv2d(40,20,3), nn.ReLU(),
    #                      nn.Conv2d(20,1,3), nn.Sigmoid()).to(device)
    model = msnn()
                        
    criterion = nn.MSELoss()
    optimizer = T.optim.SGD(model.parameters(), lr=0.1)

    def get_train_data():
        env.reset()
        state, _, _, _ = env.step(12) # center of the 5x5 map
        nn_input = state
        nn_output = env.map
        return T.tensor([[nn_input]]).float().to(device), T.tensor([[nn_output]]).float().to(device)

    num_epoch = 1000000
    for _ in tqdm(range(num_epoch)):
        nn_input, nn_desired_output = get_train_data()
        optimizer.zero_grad()
        nn_output = model(nn_input)
        loss = criterion(nn_output, nn_desired_output).to(device)
        loss.backward()
        optimizer.step()

    T.save(model,"minesweeper_model_alt3")
    print("model saved")