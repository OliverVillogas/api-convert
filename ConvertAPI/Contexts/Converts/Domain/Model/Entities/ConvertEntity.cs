using ConvertAPI.Contexts.Converts.Domain.Model.ValueObjects;
using ConvertAPI.Contexts.Shared.Domain.Model.Entities;

namespace ConvertAPI.Contexts.Converts.Domain.Model.Entities;

public class ConvertEntity : BaseEntity
{
    protected ConvertEntity() { }

    public ConvertEntity(double kilograms)
    {
        if (kilograms <= 0)
            throw new ArgumentException("Kilograms must be positive", nameof(kilograms));

        Result = new ConvertResult(kilograms);
    }

    public ConvertResult Result { get; private set; } = null!;
}