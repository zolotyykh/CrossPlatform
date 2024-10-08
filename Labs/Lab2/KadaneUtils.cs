namespace Lab2
{
	public class KadaneUtils
	{
        // Функція для знаходження максимальної суми підмасиву
        public static int FindMaxSum(int[,] matrix, int N, int M)
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
        public static int Kadane(int[] arr)
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
}

