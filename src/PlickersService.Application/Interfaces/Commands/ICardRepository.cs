using PlickersService.Domain.Entities;

namespace PlickersService.Application.Interfaces.Commands;

public interface ICardRepository
{
    Task AddAsync(Card card, CancellationToken ct);
    
    Task<Card?> GetByIdAsync(Guid cardId, CancellationToken ct);
}