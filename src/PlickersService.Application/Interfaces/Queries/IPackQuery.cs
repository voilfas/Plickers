using PlickersService.Application.DTOsResponse;

namespace PlickersService.Application.Interfaces.Queries;

public interface IPackQuery
{
    Task<PackResponse?> GetByIdAsync(Guid id, CancellationToken ct); 
}