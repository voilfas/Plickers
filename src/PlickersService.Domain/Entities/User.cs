using PlickersService.Domain.Abstract;
using PlickersService.Domain.Results;
using PlickersService.Domain.ValueObjects;

namespace PlickersService.Domain.Entities;

public class User : BaseEntity
{
    public FullName FullName { get; private set; }
    public Email Email { get; private set; }

    #pragma warning disable CS8618
    private User() {}
    #pragma warning restore CS8618

    private User(
        Guid id,
        FullName fullName,
        Email email) :  base(id)
    {
        FullName = fullName;
        Email = email;
    }

    private User(
        FullName fullName,
        Email email)
    {
        FullName = fullName;
        Email = email;
    }

    public static Result<User> Create(FullName fullName, Email email)
    {
        return Result<User>.Success(new User(fullName, email));
    }

    public static Result<User> Create(
        Guid id,
        FullName fullName,
        Email email)
    {
        return Result<User>.Success(new User(id, fullName, email));
    }
    
}