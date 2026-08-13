using MediatR;
using PlickersService.Application.Errors;
using PlickersService.Application.Interfaces;
using PlickersService.Application.Interfaces.Commands;
using PlickersService.Domain.Results;
using PlickersService.Domain.ValueObjects;

namespace PlickersService.Application.Features.Cards.UpdateCard;

public class UpdateCardHandler : IRequestHandler<UpdateCardCommand, Result>
{
    private readonly ICardRepository _cardRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCardHandler(
        ICardRepository cardRepository,
        IUnitOfWork unitOfWork)
    {
        _cardRepository = cardRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(
        UpdateCardCommand request,
        CancellationToken ct)
    {
        var card = await _cardRepository.GetByIdAsync(
            request.CardId, ct);

        if (card is null)
            return Result.Failure(ApplicationErrors.Card.NotFound);

        var listResultAnswers = request.NewAnswers
            .Select(dto => Answer.Create(
                dto.Value,
                dto.IsCorrect))
            .ToList();

        if (listResultAnswers.Any(a => a.IsFailure))
        {
            var problem = listResultAnswers.First(a => a.IsFailure);
            return Result.Failure(problem.Error);
        }
        
        var answers = listResultAnswers
            .Select(r => r.Value)
            .ToList();
        
        var updateResult = card.UpdateCardDetails(
            request.NewName,
            request.NewQuestion,
            request.NewPicturePath,
            answers);

        if (updateResult.IsFailure)
            return Result.Failure(updateResult.Error);
        
        await _unitOfWork.SaveAsync(ct);
        
        return Result.Success();
    }
}