namespace Lab1;

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

            // Читаємо вхідні дані та перевіряємо їх
            string input = File.ReadAllText(inputFilePath).Trim();

            if (!int.TryParse(input, out int n))
            {
                throw new FormatException("Некоректний формат числа у файлі input.txt.");
            }

            if (n < 1 || n > 100)
            {
                throw new ArgumentOutOfRangeException("Кількість гостей повинна бути в межах від 1 до 100.");
            }

            // Створюємо масив для збереження кількості способів (дерранжментів)
            long[] dp = new long[n + 1];

            // Базові умови
            if (n >= 1) dp[1] = 0; // Для одного гостя нема варіантів
            if (n >= 2) dp[2] = 1; // Для двох гостей є один спосіб

            // Обчислюємо кількість дерранжментів для n гостей
            for (int i = 3; i <= n; i++)
            {
                dp[i] = (i - 1) * (dp[i - 1] + dp[i - 2]);
            }

            // Записуємо результат у файл OUTPUT.TXT
            File.WriteAllText(outputFilePath, dp[n].ToString());

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
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Помилка: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Непередбачувана помилка: " + e.Message);
        }

        Console.ReadLine();
    }
}
