using FluentResults;

namespace BuildingBlocks.UseCases.Errors;

public class AppError : Error
{
    protected AppError(string message, ErrorType errorType) : base(message)
    {
        ErrorType = errorType;
    }

    public ErrorType ErrorType { get; }
}