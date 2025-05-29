/******************************************************************************
Лаб 16 - 23.05.25 - Алгоритм Форда-Фалкерсона
*******************************************************************************/
using System;
using System.Collections.Generic;
class FordFulkerson
{
    static bool FindWay(int[,] graph, int begin, int end, Dictionary<int, int> previous)
    {
        bool[] busyVertex = new bool[graph.GetLength(0)];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(begin);

        while (queue.Count > 0)
        {
            int currVertex = queue.Dequeue();
            busyVertex[currVertex] = true;

            int maxCapacity = int.MinValue;
            int? maxCapacityVertex = null;

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (!busyVertex[i] && graph[currVertex, i] > 0)
                {
                    if (graph[currVertex, i] > maxCapacity)
                    {
                        maxCapacity = graph[currVertex, i];
                        maxCapacityVertex = i;
                    }
                }
            }
            if (maxCapacityVertex == null)
                break;
            previous[maxCapacityVertex.Value] = currVertex;

            if (maxCapacityVertex == end)
                return true;
            queue.Enqueue(maxCapacityVertex.Value);
        }
        return false;
    }
    static int FordFulkersonAlgorithm(int[,] graph, int begin, int end)
    {
        int maxFlow = 0;
        int size = graph.GetLength(0);
        Dictionary<int, int> previous = new Dictionary<int, int>();
        for (int i = 0; i < size; i++)
            previous[i] = -1;

        while (FindWay(graph, begin, end, previous))
        {
            int currFlow = int.MaxValue;
            int currVertex = end;
            while (currVertex != begin)
            {
                currFlow = Math.Min(currFlow, graph[previous[currVertex], currVertex]);
                currVertex = previous[currVertex];
            }
            maxFlow += currFlow;
            currVertex = end;

            while (currVertex != begin)
            {
                int changeVertex = previous[currVertex];
                graph[changeVertex, currVertex] -= currFlow;
                graph[currVertex, changeVertex] += currFlow;
                currVertex = changeVertex;
            }
            for (int i = 0; i < size; i++)
                previous[i] = -1;
        }
        return maxFlow;
    }
    static void Main(string[] args)
    {
        int[,] graph = {
        {0, 30, 0, 0},
        {0, 0, 5, 0},
        {0, 0, 0, 30},
        {0, 0, 0, 0}
    };
        Console.WriteLine("Максимальный поток: " + FordFulkersonAlgorithm(graph, 0, 3));
    }
}