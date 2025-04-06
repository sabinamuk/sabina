/******************************************************************************\
Лаб 4 - 04.03.2025 - Алгоритм дейкстры
*******************************************************************************/
using System;
using System.Collections.Generic;
class Program
{
    public static void CalculateShortestPath(int[,] graph, int start, int destination)
    {
        int vertexCount = graph.GetLength(0);
        int[] distances = new int[vertexCount];
        bool[] visited = new bool[vertexCount];
        int[] previousVertices = new int[vertexCount];
        Array.Fill(distances, int.MaxValue);
        Array.Fill(previousVertices, -1);
        distances[start] = 0;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            int currentVertex = FindMinDistance(distances, visited);
            if (currentVertex == -1) break;
            visited[currentVertex] = true;
            for (int neighbor = 0; neighbor < vertexCount; neighbor++)
            {
                if (!visited[neighbor] && graph[currentVertex, neighbor] > 0 &&
                    distances[currentVertex] != int.MaxValue &&
                    distances[currentVertex] + graph[currentVertex, neighbor] < distances[neighbor])
                {
                    distances[neighbor] = distances[currentVertex] + graph[currentVertex, neighbor];
                    previousVertices[neighbor] = currentVertex;
                }
            }
        }
        DisplayPath(distances, previousVertices, start, destination);
    }
    static int FindMinDistance(int[] distances, bool[] visited)
    {
        int minDistance = int.MaxValue, vertex = -1;

        for (int i = 0; i < distances.Length; i++)
        {
            if (!visited[i] && distances[i] < minDistance)
            {
                minDistance = distances[i];
                vertex = i;
            }
        }
        return vertex;
    }
    static void DisplayPath(int[] distances, int[] previousVertices, int start, int destination)
    {
        if (distances[destination] == int.MaxValue)
        {
            Console.WriteLine("Путь не существует.");
            return;
        }
        Console.WriteLine($"Минимальное расстояние от вершины {start} до вершины {destination}: {distances[destination]}");
        Stack<int> path = new Stack<int>();
        for (int at = destination; at != -1; at = previousVertices[at])
            path.Push(at);
        Console.Write("Путь: ");
        while (path.Count > 0)
        {
            Console.Write(path.Pop());
            if (path.Count > 0)
                Console.Write(" → ");
        }
        Console.WriteLine();
    }
    static void Main()
    {
        int[,] graph = new int[,]
        {
            { 0, 10, 0, 0, 0 },
            { 0, 0, 3, 0, 0 },
            { 0, 0, 0, 7, 0 },
            { 0, 0, 0, 0, 5 },
            { 0, 0, 0, 0, 0 },
        };
        Console.Write("Введите начальную вершину: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("Введите конечную вершину: ");
        int end = int.Parse(Console.ReadLine());
        CalculateShortestPath(graph, start, end);
    }
}