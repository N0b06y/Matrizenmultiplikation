// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Console.WriteLine("Hello, World!");

var feld0 = new int[,]
{
    {3, 2, 1},
    {1, 0, 2}
};
var feld1 = new int[,]
{
    { 1, 2 },
    { 0, 1 },
    { 4, 0 }
};

// Multiplikatoren
Console.WriteLine("1. Feld: ");
PrintMatrix(feld0);
Console.WriteLine("2. Feld: ");
PrintMatrix(feld1);

var matrixProduct = MatrixProduct(feld0, feld1);

Console.WriteLine("Ergebnismatrix: ");
if (matrixProduct != null) PrintMatrix(matrixProduct);

return;

int[,]? MatrixProduct( int[,] matrix0 , int[,] matrix1)
{
    //Die Breite der ersten Matrix muss der Höhe der zweiten Matrix entsprechen
    return GetWidth(matrix0) != GetHeight(matrix1) ? 
        null : CalculateProduct(matrix0, matrix1);
}

int[,]? CalculateProduct(int[,] matrix0, int[,] matrix1)
{
    // Das Ergebnis hat die Höhe der ersten und die Breite der zweiten Matrix
    var result = new int[
        GetHeight(matrix0),
        GetWidth(matrix1)
    ];
    result = InitMatrix(result);
    //matrix1 = InitMatrix(matrix1);
    
    // Die Breite des Produkts ist die der zweiten Matrix
    for (var i = 0; i < GetWidth(matrix1); i++)
    {
        // Die Höhe des Produkts ist die der ersten Matrix
        for (var j = 0; j < GetHeight(matrix0); j++)
        {
            // Durch die Reihe der ersten Matrix iterieren
            for (var k = 0; k < GetWidth(matrix0); k++)
            {
                
                // Durch die Spalte der zweiten Matrix iterieren
                for (var l = 0; l < GetHeight(matrix1); l++)
                {
                    if (k==l)
                        result[j, i] += matrix0[j, k] * matrix1[l, i];
                }
            }
        }
    }

    return result;
}

int[,] InitMatrix(int[,] matrix)
{
    for (var i = 0; i < GetHeight(matrix); i++)
    {
        for (var j = 0; j < GetWidth(matrix); j++)
        {
            matrix[i, j] = 0;
        }
    }
    return matrix;
}

void PrintMatrix<T>(T[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

int GetHeight(int[,] matrix) => matrix.GetLength(0);
int GetWidth(int[,] matrix) => matrix.GetLength(1);

