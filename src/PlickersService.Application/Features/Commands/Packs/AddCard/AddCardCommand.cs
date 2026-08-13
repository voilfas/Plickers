using MediatR;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Packs.AddCard;

public record AddCardCommand(
    Guid PackId,
    Guid CardId) :  IRequest<Result>;