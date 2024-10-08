namespace Lab2.Tests;

public class KadaneTest
{
    // Тести для функції Kadane (одномірний масив)
    [Theory]
    [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]  // Підмасив: [4, -1, 2, 1]
    [InlineData(new int[] { 1, 2, 3, 4 }, 10)]                    // Підмасив: [1, 2, 3, 4]
    [InlineData(new int[] { -1, -2, -3, -4 }, -1)]                // Підмасив: [-1]
    [InlineData(new int[] { 3, -1, 2, -1 }, 4)]                   // Підмасив: [3, -1, 2]
    public void Kadane_ValidInput_ReturnsCorrectMaxSum(int[] arr, int expected)
    {
        // Act
        int result = KadaneUtils.Kadane(arr);

        // Assert
        Assert.Equal(expected, result);
    }

    // Тест для FindMaxSum (двовимірна матриця)
    [Fact]
    public void FindMaxSum_ValidMatrix_ReturnsCorrectMaxSum()
    {
        // Arrange
        int[,] matrix =
        {
                { 1, 2, -1, -4, -20 },
                { -8, -3, 4, 2, 1 },
                { 3, 8, 10, 1, 3 },
                { -4, -1, 1, 7, -6 }
            };
        int N = 4;  // кількість рядків
        int M = 5;  // кількість стовпців
        int expectedMaxSum = 29;  // Підматриця: {{3, 8, 10}, {-4, -1, 1, 7}}

        // Act
        int result = KadaneUtils.FindMaxSum(matrix, N, M);

        // Assert
        Assert.Equal(expectedMaxSum, result);
    }

    [Fact]
    public void FindMaxSum_AllNegativeMatrix_ReturnsMaxElement()
    {
        // Arrange
        int[,] matrix =
        {
                { -5, -7, -9 },
                { -8, -6, -3 },
                { -7, -5, -9 }
            };
        int N = 3;  // кількість рядків
        int M = 3;  // кількість стовпців
        int expectedMaxSum = -3;  // Найменший негативний елемент

        // Act
        int result = KadaneUtils.FindMaxSum(matrix, N, M);

        // Assert
        Assert.Equal(expectedMaxSum, result);
    }

    [Fact]
    public void FindMaxSum_SingleElementMatrix_ReturnsThatElement()
    {
        // Arrange
        int[,] matrix =
        {
                { 42 }
            };
        int N = 1;  // кількість рядків
        int M = 1;  // кількість стовпців
        int expectedMaxSum = 42;

        // Act
        int result = KadaneUtils.FindMaxSum(matrix, N, M);

        // Assert
        Assert.Equal(expectedMaxSum, result);
    }
}
