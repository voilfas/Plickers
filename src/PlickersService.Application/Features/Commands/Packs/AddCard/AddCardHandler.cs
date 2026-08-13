using MediatR;
using PlickersService.Application.Errors;
using PlickersService.Application.Interfaces;
using PlickersService.Application.Interfaces.Commands;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Packs.AddCard;

public class AddCardHandler :
    IRequestHandler<AddCardCommand, Result>
{
    private readonly ICardRepository _cardRepository;
    private readonly IPackRepository _packRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCardHandler(
        ICardRepository cardRepository,
        IPackRepository packRepository,
        IUnitOfWork unitOfWork)
    {
        _cardRepository = cardRepository;
        _packRepository = packRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(
        AddCardCommand request,
        CancellationToken ct)
    {
        var card = await _cardRepository.GetByIdAsync(request.CardId, ct);
        if (card is null)
            return Result.Failure(ApplicationErrors.Card.NotFound);

        var pack = await _packRepository.GetByIdWithCardsAsync(request.PackId, ct);
        if (pack is null)
            return Result.Failure(ApplicationErrors.Pack.NotFound);
        
        var puckAddResult = pack.AddCard(card);
        if (puckAddResult.IsFailure)
            return Result.Failure(puckAddResult.Error);
        
        await _unitOfWork.SaveAsync(ct);
        
        return Result.Success();
    }
}