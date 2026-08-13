using MediatR;
using PlickersService.Application.DTOsResponse;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Cards.UpdateCard;

public record UpdateCardCommand(
    Guid CardId,
    string NewName,
    string NewQuestion,
    string? NewPicturePath,
    IReadOnlyCollection<CreateAnswerResponse> NewAnswers
    ) : IRequest<Result>;