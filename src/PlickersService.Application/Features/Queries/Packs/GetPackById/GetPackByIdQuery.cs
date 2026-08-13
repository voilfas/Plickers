using MediatR;
using PlickersService.Application.DTOsResponse;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Queries.Packs.GetPackById;

public record GetPackByIdQuery(
    Guid PackId) : IRequest<Result<PackResponse>>;