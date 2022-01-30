namespace BuildingBlocks.UseCases.Errors;

public class ValidationError : AppError
{
    public ValidationError(string code, string message) : base(message, ErrorType.Validation)
    {
        Code = code;
    }

    public string Code { get; }
}