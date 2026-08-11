using PlickersService.Domain.Errors;
using PlickersService.Domain.Results;

namespace PlickersService.Domain.ValueObjects;

public record FullName
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string MiddleName { get; init; }
    

    #pragma  warning disable CS8618 // Non-nullable field is uninitialized.
    private FullName() { }
    #pragma warning disable CS8618 // Non-nullable field is uninitialized.

    private FullName(
        string firstName,
        string lastName,
        string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public static Result<FullName> Create(
        string firstName,
        string lastName,
        string middleName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return Result<FullName>.Failure(DomainErrors.User.EmptyFirstName);
        
        var trimmedFirstName = firstName.Trim();
        if (trimmedFirstName.Length is < 2 or > 30)
            return Result<FullName>.Failure(DomainErrors.User.InvalidFirstNameLength);
        
        if (string.IsNullOrWhiteSpace(lastName))
            return Result<FullName>.Failure(DomainErrors.User.EmptyLastName);
        
        var trimmedLastName = lastName.Trim();
        if (trimmedLastName.Length is < 2 or > 30)
            return Result<FullName>.Failure(DomainErrors.User.InvalidLastNameLength);
        
        if (string.IsNullOrWhiteSpace(middleName))
                    return Result<FullName>.Failure(DomainErrors.User.EmptyMiddleName);
        
        var trimmedMiddleName = lastName.Trim();
        if (trimmedMiddleName.Length is < 2 or > 30)
            return Result<FullName>.Failure(DomainErrors.User.InvalidMiddleNameLength);
        

        return Result<FullName>.Success(new FullName(trimmedFirstName, trimmedLastName, trimmedMiddleName));
    }
}