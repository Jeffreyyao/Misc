import gym, gym_minesweeper, os

w,h = 16,16

def get_surr(x, y):
    surr = set()
    for i in range(max(0,x-1), min(h,x+2)):
        for j in range(max(0,y-1), min(w,y+2)):
            if not (i==x and j==y):
                surr.add((i,j))
    return surr

def get_surr_unopened(obs, surr):
    res = set()
    for i,j in surr:
        if obs[i][j]==-1: res.add((i,j))
    return res

def get_mines(obs,mines_prev):
    res = set()
    for i in range(w):
        for j in range(h):
            if obs[i][j]!=-1:
                surr = get_surr(i,j)
                surr_unopened = get_surr_unopened(obs,surr)
                if obs[i][j]==len(surr_unopened):
                    res = res.union(surr_unopened)
    return res.union(mines_prev)

def get_mines_in_surr(surr,mines):
    res = set()
    for i,j in surr:
        if (i,j) in mines:
            res.add((i,j))
    return res

def get_actions(obs,mines):
    actions = set()
    for i in range(w):
        for j in range(h):
            if obs[i][j]!=-1:
                surr = get_surr(i,j)
                surr_unopened = get_surr_unopened(obs,surr)
                mines_in_surr = get_mines_in_surr(surr,mines)
                surr_undecided = surr_unopened.difference(mines_in_surr)
                if len(mines_in_surr)==obs[i][j]: # Level 1: unary relation
                    actions = actions.union(surr_undecided)
                
                mines_left = obs[i][j]-len(mines_in_surr)
                for neigh_i,neigh_j in surr:
                    neigh_surr = get_surr(neigh_i,neigh_j)
                    if surr_undecided.issubset(neigh_surr):
                        neigh_surr_unopened = get_surr_unopened(obs,neigh_surr)
                        neigh_mines_in_surr = get_mines_in_surr(neigh_surr,mines)
                        neigh_surr_undecided = neigh_surr_unopened.difference(neigh_mines_in_surr)
                        neigh_mines_left = obs[neigh_i][neigh_j]-len(neigh_mines_in_surr)
                        if neigh_mines_left == mines_left: # level 2: binary relation
                            actions = actions.union(neigh_surr_undecided.difference(surr_undecided))
                        else:
                            diff_undecided = neigh_surr_undecided.difference(surr_undecided)
                            if neigh_mines_left-mines_left==len(diff_undecided):
                                mines = mines.union(diff_undecided)
    return actions, mines

env = gym.make("Minesweeper-v0")
mines = set() # mines labeled by program
env.reset()
obs, reward, done, info = env.step(env.action_space.sample()) # first move
while not done:
    mines = get_mines(obs,mines)
    actions,mines = get_actions(obs,mines)
    print("mines"); print(mines); print("actions"); print(actions)
    if len(actions)==0: break
    for action in actions:
        obs, reward, done, info = env.step(list(action))
        if done and reward<0: print("stepped on a mine"); break
    env.render()
    input("="*os.get_terminal_size().columns)
input("end")