namespace Lab3.Tests;

public class ShortestPathTest
{
    [Fact]
    public void FindMaxShortestPath_SimpleGraph_ReturnsCorrectMaxPath()
    {
        // Arrange
        int[,] dist = {
                { 0, 3, ShortestPath.INF },
                { 3, 0, 1 },
                { ShortestPath.INF, 1, 0 }
            };
        int N = 3;

        // Act
        int result = ShortestPath.FindMaxShortestPath(dist, N);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void FindMaxShortestPath_NoPaths_ReturnsZero()
    {
        // Arrange
        int[,] dist = {
                { 0, ShortestPath.INF, ShortestPath.INF },
                { ShortestPath.INF, 0, ShortestPath.INF },
                { ShortestPath.INF, ShortestPath.INF, 0 }
            };
        int N = 3;

        // Act
        int result = ShortestPath.FindMaxShortestPath(dist, N);

        // Assert
        Assert.Equal(0, result);  // Відсутні шляхи між різними вершинами
    }

    [Fact]
    public void FindMaxShortestPath_AllConnectedGraph_ReturnsCorrectMaxPath()
    {
        // Arrange
        int[,] dist = {
                { 0, 1, 2 },
                { 1, 0, 3 },
                { 2, 3, 0 }
            };
        int N = 3;

        // Act
        int result = ShortestPath.FindMaxShortestPath(dist, N);

        // Assert
        Assert.Equal(3, result);  // Найдовший шлях - 3
    }

    [Fact]
    public void FindMaxShortestPath_LargeGraph_ReturnsCorrectMaxPath()
    {
        // Arrange
        int[,] dist = {
                { 0, 5, 10, ShortestPath.INF },
                { 5, 0, 15, 20 },
                { 10, 15, 0, 25 },
                { ShortestPath.INF, 20, 25, 0 }
            };
        int N = 4;

        // Act
        int result = ShortestPath.FindMaxShortestPath(dist, N);

        // Assert
        Assert.Equal(25, result);  // Найдовший шлях - 25
    }

    [Fact]
    public void FindMaxShortestPath_DisconnectedGraph_ReturnsCorrectMaxPath()
    {
        // Arrange
        int[,] dist = {
                { 0, 7, ShortestPath.INF, ShortestPath.INF },
                { 7, 0, 9, ShortestPath.INF },
                { ShortestPath.INF, 9, 0, 3 },
                { ShortestPath.INF, ShortestPath.INF, 3, 0 }
            };
        int N = 4;

        // Act
        int result = ShortestPath.FindMaxShortestPath(dist, N);

        // Assert
        Assert.Equal(9, result);  // Найдовший шлях - 9
    }
}
