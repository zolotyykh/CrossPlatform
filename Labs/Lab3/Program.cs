namespace Lab3;

using System;
using System.IO;

class Program
{
    const int INF = int.MaxValue / 2;  // Константа для нескінченності

    static void Main()
    {
        try
        {
            // Встановлюємо назви файлів
            string inputFileName = "input.txt";
            string outputFileName = "output.txt";

            // Отримуємо базову директорію виконуваного файлу
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Побудова шляху на три рівні вище для input.txt
            string inputFilePath = Path.Combine(baseDirectory, @"..", @"..", @"..", inputFileName);
            string outputFilePath = Path.Combine(baseDirectory, outputFileName);

            // Нормалізація шляху
            inputFilePath = Path.GetFullPath(inputFilePath);
            outputFilePath = Path.GetFullPath(outputFilePath);

            Console.WriteLine($"Шлях до вхідного файлу: {inputFilePath}");
            Console.WriteLine($"Шлях до вихідного файлу: {outputFilePath}");

            // Перевіряємо, чи існує вхідний файл
            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException($"Файл {inputFileName} не знайдено.");
            }

            // Читаємо вхідні дані
            string[] lines = File.ReadAllLines(inputFilePath);

            // Перша лінія - кількість вершин
            int N = int.Parse(lines[0]);

            // Ініціалізація графа
            int[,] graph = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string[] row = lines[i + 1].Split(' ');
                for (int j = 0; j < N; j++)
                {
                    int value = int.Parse(row[j]);
                    graph[i, j] = (value == -1) ? INF : value;
                }
            }

            // Алгоритм Флойда-Воршелла
            int[,] dist = new int[N, N];
            Array.Copy(graph, dist, graph.Length);

            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (dist[i, k] < INF && dist[k, j] < INF)
                        {
                            dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                        }
                    }
                }
            }

            int result = ShortestPath.FindMaxShortestPath(dist, N);

            // Запис результату у файл
            File.WriteAllText(outputFilePath, result.ToString());

            Console.WriteLine($"Результат успішно записано у файл {outputFileName}");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (FormatException e)
        {
            Console.WriteLine("Помилка: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Непередбачувана помилка: " + e.Message);
        }
    }
}

