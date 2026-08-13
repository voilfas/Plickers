namespace PlickersService.Application.DTOsResponse;

public record PackResponse(
    Guid Id,
    string Name,
    string? Description,
    List<CardResponse> Cards
    );