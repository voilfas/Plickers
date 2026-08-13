namespace PlickersService.Application.Interfaces;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken ct);
}