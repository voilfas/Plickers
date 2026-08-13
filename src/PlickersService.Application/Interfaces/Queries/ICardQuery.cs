using PlickersService.Application.DTOsResponse;

namespace PlickersService.Application.Interfaces.Queries;

public interface ICardQuery
{
    Task<CardResponse?> GetByIdAsync(Guid cardId, CancellationToken ct);
}