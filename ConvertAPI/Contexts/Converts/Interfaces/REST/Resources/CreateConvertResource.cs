namespace ConvertAPI.Contexts.Converts.Interfaces.REST.Resources;

public record CreateConvertResource(double Kilograms);

public record ConvertResource(
    double Kilograms,
    double Pounds
);