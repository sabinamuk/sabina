/******************************************************************************
лаб 1 - 14.02.25 - алгоритм на поиск компонет связности(способ 2)
*******************************************************************************/
using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        int[,] graph = new int[10, 10]
        {
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            { 1, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 1, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 1, 1, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
        };
        int n = graph.GetLength(0);
        bool[] visited = new bool[n];
        List<List<int>> components = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                List<int> component = new List<int>();
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);
                visited[i] = true;
                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    component.Add(node);
                    for (int j = 0; j < n; j++)
                    {
                        if (graph[node, j] == 1 && !visited[j])
                        {
                            visited[j] = true;
                            queue.Enqueue(j);
                        }
                    }
                }
                components.Add(component);
            }
        }
        Console.WriteLine("Компоненты связности:");
        for (int i = 0; i < components.Count; i++)
        {
            Console.Write($"Компонента {i + 1}: ");
            foreach (int v in components[i])
            {
                Console.Write($"{v + 1} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"\nНайдено компонент связности: {components.Count}");
    }
}