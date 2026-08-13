namespace PlickersService.Application.DTOsResponse;

public record CardResponse(
    Guid Id,
    string Name,
    string Question,
    string? PicturePath,
    List<CreateAnswerResponse> Answers
    );