using ShortestPathLibrary;

namespace Lab3
{
    class Program
    {
        const int INF = int.MaxValue / 2;

        static void Main()
        {
            try
            {
                string inputFileName = "input.txt";
                string outputFileName = "output.txt";

                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                string inputFilePath = Path.Combine(baseDirectory, @"..", @"..", @"..", inputFileName);
                string outputFilePath = Path.Combine(baseDirectory, outputFileName);

                inputFilePath = Path.GetFullPath(inputFilePath);
                outputFilePath = Path.GetFullPath(outputFilePath);

                Console.WriteLine($"Шлях до вхідного файлу: {inputFilePath}");
                Console.WriteLine($"Шлях до вихідного файлу: {outputFilePath}");

                if (!File.Exists(inputFilePath))
                {
                    throw new FileNotFoundException($"Файл {inputFileName} не знайдено.");
                }

                string[] lines = File.ReadAllLines(inputFilePath);

                int N = int.Parse(lines[0]);

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
}

