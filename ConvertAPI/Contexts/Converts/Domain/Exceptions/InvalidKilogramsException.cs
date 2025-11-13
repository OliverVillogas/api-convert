namespace ConvertAPI.Contexts.Converts.Domain.Exceptions;

public class InvalidKilogramsException : Exception
{
    public InvalidKilogramsException(double value)
        : base($"The value '{value}' is invalid. Kilograms must be a positive number greater than 0.")
    {
        Value = value;
    }

    public double Value { get; }
}