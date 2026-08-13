using MediatR;
using PlickersService.Domain.Results;

namespace PlickersService.Application.Features.Packs.CreatePack;

public record CreatePackCommand(
    string PackName,
    string? Description
    ) : IRequest<Result<Guid>>;