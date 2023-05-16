using TestPortalen.Application.Math.Models;

namespace TestPortalen.Application.Math;

public class Calculator
{
    public int Product { get; set; }

    public int Add(int value1, int value2)
    {
        return value1 + value2;
    }

    public string Multiply(int value1, int value2)
    {
        Product = value1 * value2;

        return $"Multipliceringen gav: {Product}";
    }

    public Product MultiplyToProduct(int value1, int value2)
    {
        Product = value1 * value2;

        return new Product
        {
            ProductInteger = Product,
            ProductString = $"Multipliceringen gav: {Product}"
        };
    }
}