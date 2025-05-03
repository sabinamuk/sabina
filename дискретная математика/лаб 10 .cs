/******************************************************************************
Лаба 10 - 15.04.25 - Алгоритм коммивояжера
*******************************************************************************/
using System;
using System.Linq;
class Program
{
    static void Main()
    {
        int[,] distances = {
            { 0, 10, 15, 20 },
            { 10, 0, 35, 25 },
            { 15, 35, 0, 30 },
            { 20, 25, 30, 0 }
        };
        int[] cities = Enumerable.Range(0, distances.GetLength(0)).ToArray();
        int minDistance = int.MaxValue;
        int[] bestPath = new int[cities.Length];
        Permute(cities, 1, cities.Length - 1, distances, ref minDistance, bestPath);

        Console.WriteLine($"Минимальная длина пути: {minDistance}");
        Console.WriteLine("Оптимальный маршрут: " + string.Join(" - ", bestPath));
    }
    static void Permute(int[] arr, int start, int end, int[,] distances, ref int minDistance, int[] bestPath)
    {
        if (start == end)
        {
            int currentDistance = CalculatePathDistance(arr, distances);
            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
                Array.Copy(arr, bestPath, arr.Length);
            }
        }
        else
        {
            for (int i = start; i <= end; i++)
            {
                Swap(ref arr[start], ref arr[i]);
                Permute(arr, start + 1, end, distances, ref minDistance, bestPath);
                Swap(ref arr[start], ref arr[i]);
            }
        }
    }
    static int CalculatePathDistance(int[] path, int[,] distances)
    {
        int distance = 0;
        for (int i = 0; i < path.Length - 1; i++)
            distance += distances[path[i], path[i + 1]];
        distance += distances[path[^1], path[0]];
        return distance;
    }
    static void Swap(ref int a, ref int b) => (a, b) = (b, a);
}