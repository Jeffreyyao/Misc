import random
import gym
import torch
from torch import nn
from tqdm import tqdm

ENV_NAME = "CartPole-v1"
reward_threshold = 80
observation_space = 4
action_space = 2
num_games = 80000
learning_rate = 0.001
training_epochs = 10

def get_training_data():
    env = gym.make(ENV_NAME)
    training_states = []
    training_actions = []
    print("Generating training data")
    for _ in tqdm(range(num_games)):
        done = False
        total_reward = 0
        states = []
        actions = []
        state = env.reset()
        while not done:
            action = random.randint(0,action_space-1)
            states.append(state)
            if action==0:
                actions.append([1,0]) # left
            else:
                actions.append([0,1]) # right
            state_next, reward, done, _ = env.step(action)
            total_reward += reward
            state = state_next
        if total_reward>reward_threshold:
            training_states += states
            training_actions += actions
    print("# of qualified training data:",len(training_states))
    return (training_states, training_actions)

def train_model():
    model = nn.Sequential(
        nn.Linear(observation_space,128), nn.ReLU(),
        nn.Linear(128,64), nn.ReLU(),
        nn.Linear(64,action_space))
    criterion = nn.MSELoss()
    optimizer = torch.optim.SGD(model.parameters(), lr=learning_rate)
    states,actions = get_training_data()
    print("Start training")
    for e in range(training_epochs):
        running_loss = 0
        for state,action in zip(states,actions):
            optimizer.zero_grad()
            output = model(torch.tensor(state).float())
            loss = criterion(output,torch.tensor(action).float())
            loss.backward()
            optimizer.step()
            running_loss += loss.item()
        else:
            print(f"Epoch: {e}, Training loss: {running_loss/len(states)}")
    return model
    
        

def cartpole():
    env = gym.make(ENV_NAME)
    model = train_model()
    for g in range(10):
        state = env.reset()
        reward = 0
        done = False
        while not done:
            action = torch.argmax(model(torch.tensor(state).float()))
            state,r,done,_ = env.step(int(action))
            env.render()
            reward += r
        print("Game:",g," Final reward:",reward)


cartpole()