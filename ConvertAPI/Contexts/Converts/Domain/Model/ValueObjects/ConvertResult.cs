namespace ConvertAPI.Contexts.Converts.Domain.Model.ValueObjects;

/// <summary>
///     Value Object that encapsulates conversion logic
/// </summary>
public record ConvertResult
{
    private const double KilogramsToPoundsRate = 2.20462;

    public ConvertResult(double kilograms)
    {
        if (kilograms <= 0)
            throw new ArgumentException("Kilograms must be positive", nameof(kilograms));

        Kilograms = kilograms;
        Pounds = kilograms * KilogramsToPoundsRate;
    }

    public double Kilograms { get; init; }
    public double Pounds { get; init; }
}