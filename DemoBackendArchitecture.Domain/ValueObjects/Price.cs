namespace DemoBackendArchitecture.Domain.ValueObjects;

public class Price
{
    public decimal Value { get; }

    public Price(decimal value)
    {
        if(value < 0)
            throw new ArgumentException("Value cannot be negative", nameof(value));
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString("C");
    }
}