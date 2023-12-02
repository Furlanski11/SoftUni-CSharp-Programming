using System;
using System.Drawing;
using System.Linq;
//100/100 SUCCESS
int matrixSize = int.Parse(Console.ReadLine());

char[,] matrix = new char[matrixSize, matrixSize];

for (int row = 0; row < matrixSize; row++)
{
    string rowData = Console.ReadLine();

    for (int col = 0; col < matrixSize; col++)
    {
        matrix[row, col] = rowData[col];
    }
}

int submarineRow = 0;
int submarineCol = 0;
int enemies = 0;

for (int row = 0; row < matrixSize; row++)
{

    for (int col = 0; col < matrixSize; col++)
    {
        if (matrix[row, col] == 'S')
        {
            submarineRow = row;
            submarineCol = col;
            matrix[row, col] = '-';
        }
        if (matrix[row, col] == 'C')
        {
            enemies++;
        }
    }
}

int lives = 2;

string command = string.Empty;

while (true)
{
    command= Console.ReadLine();

    if(command == "up")
    {
        submarineRow--;
    }
    if (command == "down")
    {
        submarineRow++;
    }
    if (command == "left")
    {
        submarineCol--;
    }
    if (command == "right")
    {
        submarineCol++;
    }

    if (matrix[submarineRow, submarineCol] == '*')
    {
        if(lives > 0)
        {
            lives--;
            matrix[submarineRow, submarineCol] = '-';
        }
        else
        {
            matrix[submarineRow, submarineCol] = 'S';
            Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
            break;
        }
    }
    if(matrix[submarineRow, submarineCol] == 'C')
    {
        matrix[submarineRow, submarineCol] = '-';
        enemies--;
        if(enemies == 0)
        {
            matrix[submarineRow, submarineCol] = 'S';
            Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            break;
        }
    }
}

PrintMatrix(matrix);


static void PrintMatrix<T>(T[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col]);
        }
        Console.WriteLine();
    }
}