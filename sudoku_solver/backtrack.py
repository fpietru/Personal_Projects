#
# Sudoku Solver
# Author: Franciszek Pietrusiak
#
import numpy as np

def read():
    board = np.zeros((9, 9))
    for i in range(9):
        line = input()
        for j in range(9):
            if line[j] != '.':
                board[i, j] = int(line[j])
    return board

def check(board, i, j, x):
    for k in range(9):
        if board[i, k] == x or board[k, j] == x:
            return False
    si = 3 * (i // 3)
    sj = 3 * (j // 3)
    for k1 in range(si, si+3):
        for k2 in range(sj, sj+3):
            if board[k1, k2] == x:
                return False
    return True

def find_not_filled(board):
    for i in range(9):
        for j in range(9):
            if board[i, j] == 0:
                return (i, j)
    return (-1,-1)


def solve(board):
    i, j = find_not_filled(board)

    if i == -1 and j == -1:
        print(board)
        return True

    for x in range(1,10):
        if check(board, i, j, x):
            board[i, j] = x
            if solve(board):
                return True
            board[i, j] = 0
 
    return False

board = read()
print(board)
solve(board)