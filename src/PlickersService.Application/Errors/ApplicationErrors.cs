using PlickersService.Domain.Results;

namespace PlickersService.Application.Errors;

public static class ApplicationErrors
{
    public static class Card
    {
        public static readonly Error NotFound = 
            new Error("Card.NotFound", "Card not found in db");
    }

    public static class Pack
    {
        public static readonly Error NotFound = 
            new Error("Pack.NotFound", "Pack not found in db");
    }
}