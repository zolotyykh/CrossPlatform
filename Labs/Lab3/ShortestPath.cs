﻿namespace Lab3
{
	public class ShortestPath
	{
        // Константа для нескінченності
        public const int INF = int.MaxValue / 2;

        public static int FindMaxShortestPath(int[,] dist, int N)
        {
            int maxShortestPath = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (dist[i, j] < INF && i != j)
                    {
                        maxShortestPath = Math.Max(maxShortestPath, dist[i, j]);
                    }
                }
            }

            return maxShortestPath;
        }
    }
}
