using System;

int size = int.Parse(Console.ReadLine());

char[,] matrix = new char[size, size];
for (int row = 0; row < size; row++)
{
    string rowData = Console.ReadLine();

    for (int col = 0; col < size; col++)
    {
        matrix[row, col] = rowData[col];
    }
}

int currentRow = 0;
int currentCol = 0;

for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        if(matrix[row, col] == 'V')
        {
            currentRow = row;
            currentCol = col;
        }
    }
}







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