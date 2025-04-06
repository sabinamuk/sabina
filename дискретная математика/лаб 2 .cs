/******************************************************************************
лаб 2 - 18.02.25 - алгоритм на поиск мин оставного дерева
*******************************************************************************/
using System;
class Program
{
    static int GraphSize = 5;
    static int[,] graph = new int[,] {
        { 0, 10, 0, 0, 20 },
        { 10, 0, 15, 25, 0 },
        { 0, 15, 0, 30, 0 },
        { 0, 25, 30, 0, 5 },
        { 20, 0, 0, 5, 0 }
    };
    static int FindMinKey(int[] key, bool[] inMST)
    {
        int minValue = int.MaxValue, minIndex = -1;
        for (int i = 0; i < GraphSize; i++)
        {
            if (!inMST[i] && key[i] < minValue)
            {
                minValue = key[i];
                minIndex = i;
            }
        }
        return minIndex;
    }
    static void DisplayMST(int[] parent)
    {
        Console.WriteLine("Ребро \tВес");
        int totalWeight = 0;

        for (int i = 1; i < GraphSize; i++)
        {
            int edgeWeight = graph[i, parent[i]];
            Console.WriteLine($"{parent[i]} - {i} \t{edgeWeight}");
            totalWeight += edgeWeight;
        }
        Console.WriteLine($"\nОбщая сумма весов остовного дерева: {totalWeight}");
    }
    static void PrimAlgorithm()
    {
        int[] parent = new int[GraphSize];
        int[] key = new int[GraphSize];
        bool[] inMST = new bool[GraphSize];
        
        for (int i = 0; i < GraphSize; i++)
        {
            key[i] = int.MaxValue;
            inMST[i] = false;
        }
        key[0] = 0;
        parent[0] = -1;
        for (int count = 0; count < GraphSize - 1; count++)
        {
            int u = FindMinKey(key, inMST);
            inMST[u] = true;
            for (int v = 0; v < GraphSize; v++)
            {
                if (graph[u, v] != 0 && !inMST[v] && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
            }
        }
        DisplayMST(parent);
    }
    static void Main()
    {
        PrimAlgorithm();
    }
}