using Lab1;
using Lab2;
using Lab3;

namespace LabsLibrary
{
    public class RunnerLabs
    {
        public string RunLab1(string inputFilePath)
        {
            try
            {
                if (!File.Exists(inputFilePath))
                {
                    throw new FileNotFoundException($"Файл не знайдено.");
                }

                string input = File.ReadAllText(inputFilePath).Trim();

                if (!int.TryParse(input, out int n))
                {
                    throw new FormatException("Некоректний формат числа у файлі input.txt.");
                }

                if (n < 1 || n > 100)
                {
                    throw new ArgumentOutOfRangeException("Кількість гостей повинна бути в межах від 1 до 100.");
                }

                long result = Derangements.CalculateDerangements(n);

                return result.ToString();
            }
            catch (FileNotFoundException e)
            {
                return $"Помилка: {e.Message}";
            }
            catch (FormatException e)
            {
                return $"Помилка: {e.Message}";
            }
            catch (ArgumentOutOfRangeException e)
            {
                return $"Помилка: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Непередбачувана помилка: {e.Message}";
            }
        }

        public string RunLab2(string inputFilePath)
        {
            try
            {
                if (!File.Exists(inputFilePath))
                {
                    throw new FileNotFoundException($"Файл не знайдено.");
                }

                string[] lines = File.ReadAllLines(inputFilePath);
                string[] firstLine = lines[0].Split(' ');

                int N = int.Parse(firstLine[0]);
                int M = int.Parse(firstLine[1]);

                int[,] matrix = new int[N, M];

                for (int i = 0; i < N; i++)
                {
                    string[] row = lines[i + 1].Split(' ');
                    for (int j = 0; j < M; j++)
                    {
                        matrix[i, j] = int.Parse(row[j]);
                    }
                }

                int result = KadaneUtils.FindMaxSum(matrix, N, M);

                return result.ToString();
            }
            catch (FileNotFoundException e)
            {
                return $"Помилка: {e.Message}";
            }
            catch (FormatException e)
            {
                return $"Помилка: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Непередбачувана помилка: {e.Message}";
            }
        }

        public string RunLab3(string inputFilePath)
        {
            const int INF = int.MaxValue / 2;

            try
            {
                if (!File.Exists(inputFilePath))
                {
                    throw new FileNotFoundException($"Файл не знайдено.");
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

                return result.ToString();
            }
            catch (FileNotFoundException e)
            {
                return $"Помилка: {e.Message}";
            }
            catch (FormatException e)
            {
                return $"Помилка: {e.Message}";
            }
            catch (Exception e)
            {
                return $"Непередбачувана помилка: {e.Message}";
            }
        }
    }
}
