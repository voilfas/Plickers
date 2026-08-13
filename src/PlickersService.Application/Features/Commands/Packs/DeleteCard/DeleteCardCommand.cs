using MediatR;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Packs.DeleteCard;

public record DeleteCardCommand(
    Guid CardId,
    Guid PackId)
    : IRequest<Result>;