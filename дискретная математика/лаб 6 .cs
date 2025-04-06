/******************************************************************************
лаб 6 - 18.03.25 - Алгоритм Флойда
*******************************************************************************/
using System;
class Program
{
    static void Main(string[] args)
    {
        int[,] graphWeights = {
            { 0, 7, 3, int.MaxValue },
            { int.MaxValue, 0, 1, 6 },
            { 4, int.MaxValue, 0, 2 },
            { int.MaxValue, int.MaxValue, 5, 0 }
        };
        int numVertices = graphWeights.GetLength(0);
        int[,] shortestPaths = new int[numVertices, numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            for (int j = 0; j < numVertices; j++)
            {
                shortestPaths[i, j] = graphWeights[i, j];
            }
        }
        for (int k = 0; k < numVertices; k++)
        {
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (shortestPaths[i, k] != int.MaxValue && shortestPaths[k, j] != int.MaxValue &&
                        shortestPaths[i, j] > shortestPaths[i, k] + shortestPaths[k, j])
                    {
                        shortestPaths[i, j] = shortestPaths[i, k] + shortestPaths[k, j];
                    }
                }
            }
        }
        Console.WriteLine("Результирующая матрица кратчайших путей:");
        for (int i = 0; i < numVertices; i++)
        {
            for (int j = 0; j < numVertices; j++)
            {
                if (shortestPaths[i, j] == int.MaxValue)
                {
                    Console.Write("Нет пути\t");
                }
                else
                {
                    Console.Write(shortestPaths[i, j] + "\t");
                }
            }
            Console.WriteLine();
        }
    }
}
