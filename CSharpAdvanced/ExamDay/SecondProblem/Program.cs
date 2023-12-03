using System;

string[] size = Console.ReadLine().Split();
int rows = int.Parse(size[0]);
int cols = int.Parse(size[1]);
char[,] matrix = new char[rows, cols];
int myRow = -1, myCol = -1;
for (int row = 0; row < rows; row++)
{
    string[] input = Console.ReadLine().Split();
    for (int col = 0; col < cols; col++)
    {
        char currentPlace = input[col][0];
        matrix[row, col] = currentPlace;
        if (currentPlace == 'B')
        {
            myRow = row;
            myCol = col;
        }
    }
}


int touchedOpponents = 0;
int moves = 0;
while (true)
{
    string command = Console.ReadLine();
    if (command == "Finish")
    {
        break;
    }
    int currentRow = 0, currentCol = 0;
    switch (command)
    {
        case "up": currentRow = -1; break;
        case "down": currentRow = 1; break;
        case "left": currentCol = -1; break;
        case "right": currentCol = 1; break;
    }
    int newRow = myRow + currentRow;
    int newCol = myCol + currentCol;
    if (newRow < 0)
    {
        newRow = 0;
    }

    if (newRow >= rows)
    {
        newRow = rows - 1;
    }

    if (newCol < 0)
    {
        newCol = 0;
    }

    if (newCol >= cols)
    {
        newCol = cols - 1;
    }

    char newCell = matrix[newRow, newCol];
    if (newCell == 'O')
    {
        continue;
    }
    else if (newCell == 'P')
    {
        touchedOpponents++;
        moves++;
        matrix[myRow, myCol] = '-';
        myRow = newRow;
        myCol = newCol;
        matrix[myRow, myCol] = 'B';
        if (touchedOpponents == 3)
        {
            break;
        }
    }
    else if (newCell == '-')
    {
        moves++;
        matrix[myRow, myCol] = '-';
        myRow = newRow;
        myCol = newCol;
        matrix[myRow, myCol] = 'B';
    }
}


Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {moves}");