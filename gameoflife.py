import sys
def gameOfLife(board) -> None:
    m,n = len(board),len(board[0])
    for i in range(m):
        for j in range(n):
            c = 0
            for x in range(max(0,i-1),min(m,i+2)):
                for y in range(max(0,j-1),min(n,j+2)):
                    if not (x==i and y==j):
                        c += board[x][y]&1
            if c==3 and (board[i][j])==0:
                board[i][j] += 2
            elif (c==2 or c==3) and (board[i][j])==1:
                board[i][j] += 2
    for i in range(m):
        for j in range(n):
            board[i][j] >>= 1

from random import random as rand
h,w,p = 50,50,0.5 # h,w: size of grid, p: probability of life at init
m = [[None]*w for _ in range(h)]
for i in range(h):
    for j in range(w):
        r = rand()
        m[i][j] = 0 if r<p else 1

BLACK = (0, 0, 0)
WHITE = (222, 222, 100)
blockSize = 5 #Set the size of the grid block
WINDOW_HEIGHT = blockSize*h
WINDOW_WIDTH = blockSize*w
TICK = 0.1

import time
import pygame
def main():
    global SCREEN, CLOCK
    pygame.init()
    SCREEN = pygame.display.set_mode((WINDOW_WIDTH, WINDOW_HEIGHT))
    CLOCK = pygame.time.Clock()
    SCREEN.fill(BLACK)
    pygame.display.set_caption("game of life")
    isDraw = False
    drawGrid()

    while True:
        drawGrid()
        gameOfLife(m)
        time.sleep(TICK)
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                sys.exit()

        pygame.display.update()

def clear():
    pygame.draw.rect(SCREEN, BLACK, pygame.Rect(0,0,WINDOW_WIDTH,WINDOW_HEIGHT),0)

def drawGrid():
    for x in range(0, WINDOW_WIDTH, blockSize):
        for y in range(0, WINDOW_HEIGHT, blockSize):
            rect = pygame.Rect(x, y, blockSize, blockSize)
            if m[int(x/blockSize)][int(y/blockSize)]==1:
                pygame.draw.rect(SCREEN, WHITE, rect)
            else:
                pygame.draw.rect(SCREEN, BLACK, rect)

main()