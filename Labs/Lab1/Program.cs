namespace Lab1;

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            Console.WriteLine(filePath);
            // Читаємо вхідні дані та перевіряємо їх
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл INPUT.TXT не знайдено.");
            }

            string input = File.ReadAllText(filePath).Trim();

            if (!int.TryParse(input, out int n))
            {
                throw new FormatException("Некоректний формат числа у файлі INPUT.TXT.");
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
            File.WriteAllText("OUTPUT.TXT", dp[n].ToString());

            Console.WriteLine("Результат успішно записано у файл OUTPUT.TXT");
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


