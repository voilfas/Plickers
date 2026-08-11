using PlickersService.Domain.Errors;
using PlickersService.Domain.Results;

namespace PlickersService.Domain.ValueObjects;

public record Answer
{
    public string Value { get; private set; }
    public bool IsCorrect { get; private set; }

    private Answer(
        string value,
        bool isCorrect)
    {
        Value = value;
        IsCorrect = isCorrect;
    }

    public static Result<Answer> Create(
        string value,
        bool isCorrect)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<Answer>.Failure(DomainErrors.Answer.EmptyAnswer);
        
        if (value.Length is < 1 or > 100)
            return Result<Answer>.Failure(DomainErrors.Answer.InvalidAnswer);

        return Result<Answer>.Success(new Answer(value, isCorrect));
    }
}