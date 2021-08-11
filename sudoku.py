def solveSudoku(board):
    global res
    res = None
    def backtrack(b,index):
        if index==81:
            global res
            res = list(map(list,b))
            return
        elif index>81:
            return
        y,x = index//9,index%9
        if b[y][x]=='.':
            for i in range(1,10):
                if check_col(b,y,x,str(i)) and check_row(b,y,x,str(i)) and check_grid(b,y,x,str(i)):
                    board[y][x] = str(i)
                    backtrack(board,index+1)
                    board[y][x] = '.'
        else:
            backtrack(b,index+1)
    def check_col(b,y,x,num):
        for i in range(9):
            if i!=y and b[i][x]==num:
                return False
        return True
    def check_row(b,y,x,num):
        for i in range(9):
            if i!=x and b[y][i]==num:
                return False
        return True
    def check_grid(b,y,x,num):
        sy,sx = y//3*3,x//3*3
        for i in range(sy,sy+3):
            for j in range(sx,sx+3):
                if (i!=y or j!=x) and b[i][j]==num:
                    return False
        return True
    backtrack(board,0)
    return res

board = []
for i in range(9):
    row = input("input row "+str(i)+" of the sudoku\n")
    board.append(list(row))
print("sudoku before solved")
[print(i) for i in board]
board = solveSudoku(board)
if board==None:
    print("sudoku not solvable")
else:
    print("sudoku after solved")
    [print(i) for i in board]