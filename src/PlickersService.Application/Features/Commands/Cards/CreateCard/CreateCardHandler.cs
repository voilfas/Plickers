using MediatR;
using PlickersService.Application.Interfaces;
using PlickersService.Application.Interfaces.Commands;
using PlickersService.Domain.Entities;
using PlickersService.Domain.Results;
using PlickersService.Domain.ValueObjects;

namespace PlickersService.Application.Features.Cards.CreateCard;

public class CreateCardHandler :
    IRequestHandler<CreateCardCommand, Result<Guid>>
{
    private readonly ICardRepository _repository;
    private readonly IUnitOfWork _unit;

    public CreateCardHandler(
        ICardRepository repository,
        IUnitOfWork unit)
    {
        _repository = repository;
        _unit = unit;
    }
    
    public async Task<Result<Guid>> Handle(
        CreateCardCommand request,
        CancellationToken ct)
    {
        var answersResult = request.Answers
            .Select(dto => Answer.Create(
                dto.Value,
                dto.IsCorrect))
            .ToList();

        if (answersResult.Any(res => res.IsFailure))
        {
            var firstError = answersResult.First(res => res.IsFailure);
            return Result<Guid>.Failure(firstError.Error);
        }
        
        var listAnswer = answersResult
            .Select(r => r.Value)
            .ToList();
        
        var cardResult = Card.Create(
            request.CardName,
            request.Question,
            request.PicturePath,
            listAnswer);

        if (cardResult.IsFailure)
            return Result<Guid>.Failure(cardResult.Error);
        
        var card = cardResult.Value;

        await _repository.AddAsync(card, ct);
        await _unit.SaveAsync(ct);
        
        return Result<Guid>.Success(card.Id);
    }
}