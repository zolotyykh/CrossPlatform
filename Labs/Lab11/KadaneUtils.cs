namespace Lab2
{
	public class KadaneUtils
	{
        public static int FindMaxSum(int[,] matrix, int N, int M)
        {
            int maxSum = int.MinValue;

            for (int top = 0; top < N; top++)
            {
                int[] temp = new int[M];

                for (int bottom = top; bottom < N; bottom++)
                {
                    for (int i = 0; i < M; i++)
                    {
                        temp[i] += matrix[bottom, i];
                    }

                    maxSum = Math.Max(maxSum, Kadane(temp));
                }
            }

            return maxSum;
        }

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

