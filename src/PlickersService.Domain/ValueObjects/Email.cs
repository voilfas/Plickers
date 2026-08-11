using System.Net.Mail;
using PlickersService.Domain.Errors;
using PlickersService.Domain.Results;

namespace PlickersService.Domain.ValueObjects;

public record Email
{
    public string Value { get; init; }

    private Email() { } // Для EF Core / сериализации

    private Email(string value)
    {
        Value = value;
    }

    public static Result<Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<Email>.Failure(DomainErrors.User.EmptyEmail);

        string trimmedEmail = value.Trim();

        if (trimmedEmail.Length > 100)
            return Result<Email>.Failure(DomainErrors.User.InvalidEmailLength);
        
        try
        {
            var mailAddress = new MailAddress(trimmedEmail);
            
            if (!mailAddress.Address.Contains('.'))
                return Result<Email>.Failure(DomainErrors.User.InvalidEmailFormat);
        }
        catch (FormatException)
        {
            return Result<Email>.Failure(DomainErrors.User.InvalidEmailFormat);
        }

        return Result<Email>.Success(new Email(trimmedEmail));
    }
}