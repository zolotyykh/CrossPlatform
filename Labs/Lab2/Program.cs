namespace Lab2;

using System;
using System.IO;

class Program
{
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

            // Нормалізація шляху (щоб прибрати можливі некоректні символи, як подвійні слеші)
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
            string[] firstLine = lines[0].Split(' ');

            int N = int.Parse(firstLine[0]); // кількість рядків
            int M = int.Parse(firstLine[1]); // кількість стовпців

            // Ініціалізація матриці
            int[,] matrix = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                string[] row = lines[i + 1].Split(' ');
                for (int j = 0; j < M; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }

            // Виклик функції для знаходження максимальної суми підмасиву
            int maxSum = FindMaxSum(matrix, N, M);

            // Запис результату в OUTPUT.TXT
            File.WriteAllText(outputFilePath, maxSum.ToString());

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

    // Функція для знаходження максимальної суми підмасиву
    static int FindMaxSum(int[,] matrix, int N, int M)
    {
        int maxSum = int.MinValue;

        // Переглядаємо всі можливі пари рядків
        for (int top = 0; top < N; top++)
        {
            int[] temp = new int[M];

            for (int bottom = top; bottom < N; bottom++)
            {
                // Накопичуємо значення стовпців між верхнім і нижнім рядками
                for (int i = 0; i < M; i++)
                {
                    temp[i] += matrix[bottom, i];
                }

                // Знаходимо максимальну суму підмасиву в цьому проміжку за допомогою алгоритму Кадане
                maxSum = Math.Max(maxSum, Kadane(temp));
            }
        }

        return maxSum;
    }

    // Алгоритм Кадане для знаходження максимальної суми підмасиву в одномірному масиві
    static int Kadane(int[] arr)
    {
        int maxSoFar = arr[0];
        int maxEndingHere = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            maxEndingHere = Math.Max(arr[i], maxEndingHere + arr[i]);
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);
        }

        return maxSoFar;
    }
}
