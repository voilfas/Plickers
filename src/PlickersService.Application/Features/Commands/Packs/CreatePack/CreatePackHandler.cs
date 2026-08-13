using MediatR;
using PlickersService.Application.Interfaces;
using PlickersService.Application.Interfaces.Commands;
using PlickersService.Domain.Entities;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Packs.CreatePack;

public class CreatePackHandler : 
    IRequestHandler<CreatePackCommand, Result<Guid>>
{
    private readonly IPackRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePackHandler(
        IPackRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<Result<Guid>> Handle(
        CreatePackCommand request,
        CancellationToken ct)
    {
        var packResult = Pack.Create(
            request.PackName,
            request.Description);
        
        if (packResult.IsFailure)
            return Result<Guid>.Failure(packResult.Error);
        
        var pack = packResult.Value;

        await _repository.AddAsync(pack, ct);

        await _unitOfWork.SaveAsync(ct);
        
        return Result<Guid>.Success(pack.Id);
    }
}