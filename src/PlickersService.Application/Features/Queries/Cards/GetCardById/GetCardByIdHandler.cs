using MediatR;
using PlickersService.Application.DTOsResponse;
using PlickersService.Application.Errors;
using PlickersService.Application.Interfaces.Queries;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Queries.Cards.GetCardById;

public class GetCardByIdHandler : 
    IRequestHandler<GetCardByIdQuery, Result<CardResponse>>
{
    private readonly ICardQuery _cardQuery;

    public GetCardByIdHandler(ICardQuery cardQuery)
    {
        _cardQuery = cardQuery;
    }
    
    public async Task<Result<CardResponse>> Handle(
        GetCardByIdQuery request,
        CancellationToken ct)
    {
        var cardDto = await _cardQuery.GetByIdAsync(request.CardId, ct);
        
        if (cardDto is null)
            return Result<CardResponse>.Failure(ApplicationErrors.Card.NotFound);
        
        return Result<CardResponse>.Success(cardDto);
    }
}