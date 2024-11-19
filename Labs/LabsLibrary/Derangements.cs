namespace Lab1
{
	public static class Derangements
	{
        public static long CalculateDerangements(int n)
        {

            long[] dp = new long[n + 1];

 
            if (n >= 1) dp[1] = 0; 
            if (n >= 2) dp[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                dp[i] = (i - 1) * (dp[i - 1] + dp[i - 2]);
            }

            return dp[n];
        }
    }
}

