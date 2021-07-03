import pygame
import sys
import numpy
import torch

BLACK = (0, 0, 0)
WHITE = (222, 222, 222)
WINDOW_HEIGHT = 420
WINDOW_WIDTH = 420
blockSize = 15 #Set the size of the grid block

rectMap = [[None]*28 for _ in range(28)]
map = [[-1.0]*28 for _ in range(28)]

model = torch.load("firstNN_model")
model.eval()

def main():
    global SCREEN, CLOCK
    pygame.init()
    SCREEN = pygame.display.set_mode((WINDOW_WIDTH, WINDOW_HEIGHT))
    CLOCK = pygame.time.Clock()
    SCREEN.fill(BLACK)
    pygame.display.set_caption("pred:")
    isDraw = False
    drawGrid()

    while True:
        
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                pygame.quit()
                sys.exit()
            elif event.type == pygame.MOUSEBUTTONDOWN:
                isDraw = True
            elif event.type == pygame.MOUSEBUTTONUP:
                isDraw = False
                pred()
            elif event.type == pygame.MOUSEMOTION:
                if isDraw:
                    for i in range(len(rectMap)):
                        for j in range(len(rectMap[i])):
                            if rectMap[i][j]!=None and rectMap[i][j].collidepoint(event.pos):
                                rect = pygame.Rect(i*15, j*15, blockSize, blockSize)
                                map[j][i] = 1.0
                                pygame.draw.rect(SCREEN,WHITE,rect)

                                if j+1!=28:
                                    rect = pygame.Rect(i*15, (j+1)*15, blockSize, blockSize)
                                    map[j+1][i] = 1.0
                                    pygame.draw.rect(SCREEN,WHITE,rect)

                                if i+1!=28:
                                    rect = pygame.Rect((i+1)*15, j*15, blockSize, blockSize)
                                    map[j][i+1] = 1.0
                                    pygame.draw.rect(SCREEN,WHITE,rect)

                                if j+1!=28 and i+1!=28:
                                    rect = pygame.Rect((i+1)*15, (j+1)*15, blockSize, blockSize)
                                    map[j+1][i+1] = 1.0
                                    pygame.draw.rect(SCREEN,WHITE,rect)
            elif event.type == pygame.KEYDOWN:
                clear()
                drawGrid()
                pygame.display.set_caption("pred:")

        pygame.display.update()

def clear():
    pygame.draw.rect(SCREEN, BLACK, pygame.Rect(0,0,WINDOW_WIDTH,WINDOW_HEIGHT),0)

def drawGrid():
    for x in range(0, WINDOW_WIDTH, blockSize):
        for y in range(0, WINDOW_HEIGHT, blockSize):
            rect = pygame.Rect(x, y, blockSize, blockSize)
            rectMap[int(x/blockSize)][int(y/blockSize)] = rect
            pygame.draw.rect(SCREEN, WHITE, rect, 1)
            map[int(x/15)][int(y/15)] = -1.0

def pred():
    test = torch.tensor([[numpy.array(map).tolist()]])
    prediction = model(test).detach().numpy()
    pygame.display.set_caption("pred: "+str(numpy.argmax(numpy.exp(prediction[0]))))


main()