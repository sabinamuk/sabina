/******************************************************************************
Лаба 8 - 01.04.25 - Волновой алгоритм 
*******************************************************************************/
using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        char[,] mazeLayout = new char[,]
        {
            { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' },
            { 'X', '0', '0', 'X', 'X', '0', '0', '0', 'X', 'X' },
            { 'X', '0', '0', '0', '0', 'X', '0', '0', '0', 'X' },
            { 'X', '0', '0', 'X', '0', '0', '0', 'X', 'X', 'X' },
            { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' }
        };
        (int entranceRow, int entranceCol) = (1, 2);
        (int exitRow, int exitCol) = (3, 4);

        int shortestPathLength = FindShortestPathInMaze(mazeLayout, entranceRow, entranceCol, exitRow, exitCol);
        Console.WriteLine(shortestPathLength == -1 ? "Путь не найден." : $"Кратчайший путь: {shortestPathLength} шагов.");
    }
    static int FindShortestPathInMaze(char[,] mazeGrid, int startRow, int startCol, int targetRow, int targetCol)
    {
        int totalRows = mazeGrid.GetLength(0);
        int totalColumns = mazeGrid.GetLength(1);

        int[,] movementDirections = new int[,]
        {
            { -1, 0 },
            { 1, 0 },
            { 0, -1 },
            { 0, 1 }
        };
        Queue<(int row, int column, int pathLength)> pathQueue = new Queue<(int, int, int)>();
        pathQueue.Enqueue((startRow, startCol, 0));

        bool[,] visitedCells = new bool[totalRows, totalColumns];
        visitedCells[startRow, startCol] = true;
        while (pathQueue.Count > 0)
        {
            var (currentRow, currentColumn, currentPathLength) = pathQueue.Dequeue();

            if (currentRow == targetRow && currentColumn == targetCol)
            {
                return currentPathLength;
            }
            for (int directionIndex = 0; directionIndex < movementDirections.GetLength(0); directionIndex++)
            {
                int nextRow = currentRow + movementDirections[directionIndex, 0];
                int nextColumn = currentColumn + movementDirections[directionIndex, 1];

                if (nextRow >= 0 && nextRow < totalRows && 
                    nextColumn >= 0 && nextColumn < totalColumns &&
                    mazeGrid[nextRow, nextColumn] == '0' && 
                    !visitedCells[nextRow, nextColumn])
                {
                    visitedCells[nextRow, nextColumn] = true;
                    pathQueue.Enqueue((nextRow, nextColumn, currentPathLength + 1));
                }
            }
        }
        return -1; 
    }
}