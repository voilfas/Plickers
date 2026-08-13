using MediatR;
using PlickersService.Application.DTOsResponse;
using PlickersService.Application.Errors;
using PlickersService.Application.Interfaces.Queries;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Queries.Packs.GetPackById;

public class GetPackByIdHandler 
    : IRequestHandler<GetPackByIdQuery, Result<PackResponse>>
{
    private readonly IPackQuery _packQuery;

    public GetPackByIdHandler(IPackQuery packQuery)
    {
        _packQuery = packQuery;
    }
    
    public async Task<Result<PackResponse>> Handle(
        GetPackByIdQuery request,
        CancellationToken ct)
    {
        var packResponseResult = await _packQuery.GetByIdAsync(request.PackId, ct);
        
        if (packResponseResult is null)
            return Result<PackResponse>.Failure(ApplicationErrors.Pack.NotFound);
        
        return Result<PackResponse>.Success(packResponseResult);
    }
}