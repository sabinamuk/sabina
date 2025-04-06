/******************************************************************************
лаб 3 (28.02.25) алгоритм на поиск мостов 
*******************************************************************************/
using System;
using System.Collections.Generic;
class Graph
{
    int vertices;
    List<int>[] adjacencyList;

    public Graph(int[,] matrix)
    {
        vertices = matrix.GetLength(0);
        adjacencyList = new List<int>[vertices];
        for (int i = 0; i < vertices; i++)
            adjacencyList[i] = new List<int>();
        for (int i = 0; i < vertices; i++)
        {
            for (int j = i; j < vertices; j++)
            {
                if (matrix[i, j] != 0)
                {
                    adjacencyList[i].Add(j);
                    adjacencyList[j].Add(i);
                }
            }
        }
    }
    public void FindBridges()
    {
        int[] discoveryTime = new int[vertices];
        int[] lowestTime = new int[vertices];
        bool[] visited = new bool[vertices];
        int[] parent = new int[vertices];

        for (int i = 0; i < vertices; i++)
        {
            discoveryTime[i] = -1;
            lowestTime[i] = -1;
            parent[i] = -1;
        }
        int time = 0;
        for (int i = 0; i < vertices; i++)
        {
            if (!visited[i])
                DFS(i, visited, discoveryTime, lowestTime, parent, ref time);
        }
    }
    private void DFS(int current, bool[] visited, int[] discoveryTime, int[] lowestTime, int[] parent, ref int time)
    {
        visited[current] = true;
        discoveryTime[current] = lowestTime[current] = ++time;

        foreach (int neighbor in adjacencyList[current])
        {
            if (!visited[neighbor])
            {
                parent[neighbor] = current;
                DFS(neighbor, visited, discoveryTime, lowestTime, parent, ref time);

                lowestTime[current] = Math.Min(lowestTime[current], lowestTime[neighbor]);

                if (lowestTime[neighbor] > discoveryTime[current])
                    Console.WriteLine($"Мост: ({current}, {neighbor})");
            }
            else if (neighbor != parent[current])
            {
                lowestTime[current] = Math.Min(lowestTime[current], discoveryTime[neighbor]);
            }
        }
    }
}
class Program
{
    static void Main()
    {
        int[,] graphMatrix = new int[,]
        {
            { 0, 1, 0, 0, 0 },
            { 1, 0, 1, 1, 0 },
            { 0, 1, 0, 0, 0 },
            { 0, 1, 0, 0, 1 },
            { 0, 0, 0, 1, 0 }
        };
        Graph graph = new Graph(graphMatrix);
        Console.WriteLine("Мосты в данном графе:");
        graph.FindBridges();
    }
}