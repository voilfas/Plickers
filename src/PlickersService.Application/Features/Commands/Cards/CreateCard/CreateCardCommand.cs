using MediatR;
using PlickersService.Application.DTOsResponse;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Cards.CreateCard;

public record CreateCardCommand(
    string CardName,
    string Question,
    string? PicturePath,
    IReadOnlyCollection<CreateAnswerResponse> Answers) 
    :  IRequest<Result<Guid>>;