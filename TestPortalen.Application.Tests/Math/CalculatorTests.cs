using FluentAssertions;
using FluentAssertions.Execution;
using TestPortalen.Application.Math;
using TestPortalen.Application.Math.Models;

namespace TestPortalen.Application.Tests.Math;

public class CalculatorTests
{
    [Fact]
    public void Add_TwoIntegers_ShouldReturnSumOfIntegers()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Add(10, 21);

        // Assert
        result.Should().Be(31);
    }

    [Theory]
    [InlineData(-1, 2, 1)]
    [InlineData(2, 2, 4)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 0, -1)]
    [InlineData(-1, -1, -2)]
    public void Add_TwoIntegers_ShouldReturnSum(int value1, int value2, int expected)
    {
        // Act
        var calculator = new Calculator();

        // Arrange
        var result = calculator.Add(value1, value2);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Multiply_TwoIntegers_ShouldSetProductAndReturnCorrectSummary()
    {
        // Act
        var calculator = new Calculator();

        // Arrange
        var result = calculator.Multiply(3, 11);

        // Assert
        using (new AssertionScope())
        {
            calculator.Product.Should().Be(33);
            result.Should().Be("Multipliceringen gav: 33");
        }
    }

    [Fact]
    public void MultiplyToProduct_TwoIntegers_ShouldReturnCorrectProduct()
    {
        // Act
        var calculator = new Calculator();
        var expected = new Product
        {
            ProductInteger = 33,
            ProductString = "Multipliceringen gav: 33"
        };

        // Arrange
        var result = calculator.MultiplyToProduct(3, 11);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}