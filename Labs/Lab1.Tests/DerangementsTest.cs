namespace Lab1.Tests;

public class DerangementsTest
{
    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 9)]
    [InlineData(5, 44)]
    [InlineData(6, 265)]
    public void CalculateDerangements_ValidInput_ReturnsCorrectResult(int n, long expected)
    {
        // Act
        long result = Derangements.CalculateDerangements(n);

        // Assert
        Assert.Equal(expected, result);
    }

}
