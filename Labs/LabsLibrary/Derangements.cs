namespace Lab1
{
	public static class Derangements
	{
        public static long CalculateDerangements(int n)
        {
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

            return dp[n];
        }
    }
}

