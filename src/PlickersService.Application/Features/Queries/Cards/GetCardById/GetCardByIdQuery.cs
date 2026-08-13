using MediatR;
using PlickersService.Application.DTOsResponse;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Queries.Cards.GetCardById;

public record GetCardByIdQuery(
    Guid CardId
    ) : IRequest<Result<CardResponse>>;