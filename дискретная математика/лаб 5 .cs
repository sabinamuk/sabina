/******************************************************************************
лаб 5 - 14.03.25- Алгоритм Форда-Беллмана
*******************************************************************************/
using System;
class Program
{
    static void Main()
    {
        int[,] graph = {
            { 0, 5, 0, 0, 9 },
            { 5, 0, 3, 0, 0 },
            { 0, 3, 0, 7, 4 },
            { 0, 0, 7, 0, 2 },
            { 9, 0, 4, 2, 0 }
        };
        int totalVertices = graph.GetLength(0);
        int startVertex = 0;
        BellmanFord(graph, totalVertices, startVertex);
    }
    static void BellmanFord(int[,] graph, int vertices, int source)
    {
        int[] distances = new int[vertices];
        for (int i = 0; i < vertices; i++)
            distances[i] = int.MaxValue;
        distances[source] = 0;
        for (int i = 0; i < vertices - 1; i++)
        {
            for (int u = 0; u < vertices; u++)
            {
                for (int v = 0; v < vertices; v++)
                {
                    if (graph[u, v] > 0 && distances[u] != int.MaxValue)
                    {
                        int potentialDist = distances[u] + graph[u, v];
                        if (potentialDist < distances[v])
                            distances[v] = potentialDist;
                    }
                }
            }
        }
        Console.WriteLine("Кратчайшие расстояния от вершины " + (source + 1) + ":");
        for (int i = 0; i < vertices; i++)
        {
            if (distances[i] == int.MaxValue)
                Console.WriteLine($"Вершина {i + 1}: бесконечность");
            else
                Console.WriteLine($"Вершина {i + 1}: {distances[i]}");
        }
    }
}