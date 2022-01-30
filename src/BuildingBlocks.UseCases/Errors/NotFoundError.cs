namespace BuildingBlocks.UseCases.Errors;

public class NotFoundError : AppError
{
    public NotFoundError(string? identifier) : base("Not found error", ErrorType.NotFound)
    {
        Identifier = identifier;
    }

    public string? Identifier { get; }
}