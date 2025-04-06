/******************************************************************************
лаб 1 - 14.02.25 - алгоритм на поиск компонет связности
*******************************************************************************/
using System;
class Program
{
    static void Main()
    {
        int[,] adjacency = new int[10, 10]
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
        int size = adjacency.GetLength(0);
        int[] componentId = new int[size];
        int labelCounter = 1;
        for (int current = 0; current < size; current++)
        {
            int minLabel = int.MaxValue;
            
            for (int neighbor = 0; neighbor < current; neighbor++)
            {
                if (adjacency[current, neighbor] == 1)
                {
                    minLabel = Math.Min(minLabel, componentId[neighbor]);
                }
            }
            if (minLabel == int.MaxValue)
            {
                componentId[current] = labelCounter++;
            }
            else
            {
                componentId[current] = minLabel;
                for (int neighbor = 0; neighbor < current; neighbor++)
                {
                    if (adjacency[current, neighbor] == 1 && componentId[neighbor] > minLabel)
                    {
                        componentId[neighbor] = minLabel;
                    }
                }
            }
        }
        Console.WriteLine("Информация о связных компонентах:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Звено {i + 1} принадлежит компоненте {componentId[i]}");
        }
        int maxComponent = 0;
        foreach (int comp in componentId)
        {
            if (comp > maxComponent)
                maxComponent = comp;
        }
        Console.WriteLine($"\nНайдено компонент связности: {maxComponent}");
    }
}