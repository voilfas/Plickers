using PlickersService.Domain.Abstract;
using PlickersService.Domain.Errors;
using PlickersService.Domain.Results;

namespace PlickersService.Domain.Entities;

public class Pack : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    private readonly List<Card> _cards = [];
    public IReadOnlyCollection<Card> Cards => _cards;

    #pragma warning disable CS8618
    private Pack(){}
    #pragma warning restore CS8618
    
    private Pack(
        string name,
        string? description)
    {
        Name = name;
        Description = description;
    }

    public static Result<Pack> Create(
        string name,
        string? description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result<Pack>.Failure(DomainErrors.Pack.EmptyName);

        return name.Length is < 1 or > 30
            ? Result<Pack>.Failure(DomainErrors.Pack.InvalidName)
            : Result<Pack>.Success(new Pack(name, description));
    }

    public Result AddCard(Card? card)
    {
        if (card is null)
            return Result.Failure(DomainErrors.Pack.EmptyCard);

        if (_cards.Any(c => c.Id == card.Id))
            return Result.Failure(DomainErrors.Pack.CardExists);
        
        _cards.Add(card);
        
        return Result.Success();
    }

    public Result DeleteCard(Card? card)
    {
        if (card is null)
            return Result.Failure(DomainErrors.Pack.EmptyCard);
        
        if (_cards.Any(c => c.Id == card.Id))
            return Result.Failure(DomainErrors.Pack.CardExists);
        
        _cards.Remove(card);
        
        return Result.Success();
    }
}