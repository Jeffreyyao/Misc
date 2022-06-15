import gym
import numpy as np
from tqdm import tqdm

ENV_NAME = "CartPole-v1"
env = gym.make(ENV_NAME)

alpha = 0.5 # learning rate
epsilon = 1
Observation = [30, 30, 50, 50]
np_array_win_size = np.array([0.25, 0.25, 0.01, 0.1])

buckets=(6, 12, 6, 12,)
q = np.zeros(buckets + (env.action_space.n,))
print(q.shape)

def discretize(obs):
    """
    Convert continuous observation space into discrete values
    """
    high = env.observation_space.high
    low = env.observation_space.low
    upper_bounds = [high[0], high[1] / 1e38, high[2], high[3] / 1e38]
    lower_bounds = [low[0], low[1] / 1e38, low[2], low[3] / 1e38]

    ratios = [(obs[i] + abs(lower_bounds[i])) / (upper_bounds[i] - lower_bounds[i]) for i in range(len(obs))]
    new_obs = [int(round((buckets[i] - 1) * ratios[i])) for i in range(len(obs))]
    new_obs = [min(buckets[i] - 1, max(0, new_obs[i])) for i in range(len(obs))]

    return tuple(new_obs)

for i in tqdm(range(5001)):
    s = env.reset()
    s_discrete = discretize(s)
    done = False
    while not done:
        if np.random.random()>epsilon:
            action = np.argmax(q[s_discrete])
        else:
            action = np.random.randint(0, env.action_space.n)
        if i%1000==0:
            env.render()
        s_new,r,done,info = env.step(action)
        s_discrete_new = discretize(s_new)
        #print(s_discrete+(action,),s_discrete_new+(action,))
        Q_sa = q[s_discrete+(action,)]
        Q_max_next = np.max(q[s_discrete_new])
        q[s_discrete+(action,)] = Q_sa+alpha*(r+Q_max_next-Q_sa)
        s_discrete = s_discrete_new
    epsilon = epsilon*0.995