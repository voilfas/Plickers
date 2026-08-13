using PlickersService.Domain.Entities;

namespace PlickersService.Application.Interfaces.Commands;

public interface IPackRepository
{
    Task AddAsync(Pack pack, CancellationToken ct);
    
    Task<Pack> GetByIdWithCardsAsync(Guid cardId, CancellationToken ct);
}