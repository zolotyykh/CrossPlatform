namespace Lab2;

using System;
using System.Diagnostics;
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

            int result = KadaneUtils.FindMaxSum(matrix, N, M);

            // Запис результату в OUTPUT.TXT
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
