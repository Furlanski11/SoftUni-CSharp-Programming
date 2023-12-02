using System;
using System.Linq;


int size = int.Parse(Console.ReadLine());
string[,] matrix = new string[size, size];
string carNumber = (Console.ReadLine());
int firstTunnelRow = 0;
int firstTunnelCol = 0;
bool isFirstTunnelFound = false;

int secondTunnelRow = 0;
int secondTunnelCol = 0;
for (int row = 0; row < size; row++)
{
    string[] rowData = Console.ReadLine().Split(" ");

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = rowData[col];
    }
}

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        if (matrix[row, col] == "T" && !isFirstTunnelFound) 
        {
            firstTunnelRow = row;
            firstTunnelCol = col;
            isFirstTunnelFound= true;
        }
        else if (matrix[row, col] == "T")
        {
            secondTunnelRow = row;
            secondTunnelCol = col;
        }
    }
}

int carRow = 0;
int carCol = 0;
int kms = 0;
string command = string.Empty;
bool isFinished = false;
while ((command = Console.ReadLine()) != "End")
{
    if(command == "left")
    {
        carCol--;

    }
    if (command == "right")
    {
        carCol++;

    }
    if (command == "up")
    {
        carRow--;

    }
    if (command == "down")
    {
        carRow++;

    }

    if (matrix[carRow, carCol] == ".")
    {
        kms += 10;
    }

    if (matrix[carRow,carCol] == "T")
    {
        matrix[carRow, carCol] = ".";
        if (carRow == firstTunnelRow && carCol == firstTunnelCol)
        {
            carCol = secondTunnelCol;
            carRow = secondTunnelRow;
        }
        else
        {
            carCol = firstTunnelCol;
            carRow = firstTunnelRow;
        }
        matrix[carRow, carCol] = ".";
        kms+= 30;
    }
    if (matrix[carRow, carCol] == "F")
    {
        isFinished = true;
        kms += 10;
        break;
    }
}

matrix[carRow, carCol] = "C";

if (isFinished)
{
    Console.WriteLine($"Racing car {carNumber} finished the stage!");
}
else
{
    Console.WriteLine($"Racing car {carNumber} DNF.");
}

Console.WriteLine($"Distance covered {kms} km.");

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