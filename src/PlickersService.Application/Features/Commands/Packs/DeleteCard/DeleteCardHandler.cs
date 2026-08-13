using MediatR;
using PlickersService.Application.Errors;
using PlickersService.Application.Interfaces;
using PlickersService.Application.Interfaces.Commands;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Packs.DeleteCard;

public class DeleteCardHandler 
    : IRequestHandler<DeleteCardCommand, Result>
{
    private readonly ICardRepository _cardRepository;
    private readonly IPackRepository _packRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCardHandler(
        ICardRepository cardRepository,
        IPackRepository packRepository,
        IUnitOfWork unitOfWork)
    {
        _cardRepository = cardRepository;
        _packRepository = packRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(
        DeleteCardCommand request,
        CancellationToken ct)
    {
        var card = await _cardRepository.GetByIdAsync(request.CardId, ct);
        if (card is null)
            return Result.Failure(ApplicationErrors.Card.NotFound);

        var pack = await _packRepository.GetByIdWithCardsAsync(request.PackId, ct);
        if (pack is null)
            return Result.Failure(ApplicationErrors.Pack.NotFound);

        var packDeleteResult = pack.DeleteCard(card.Id);
        if (packDeleteResult.IsFailure)
            return Result.Failure(packDeleteResult.Error);
        
        await _unitOfWork.SaveAsync(ct);
        
        return Result.Success();
    }
}