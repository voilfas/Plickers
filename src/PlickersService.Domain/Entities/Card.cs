using PlickersService.Domain.Abstract;
using PlickersService.Domain.Errors;
using PlickersService.Domain.Results;
using PlickersService.Domain.ValueObjects;

namespace PlickersService.Domain.Entities;

public class Card : BaseEntity
{
    public string CardName { get; private set; }
    public string Question { get; private set; }
    public string? PicturePath { get; private set; }

    private readonly List<Answer> _answers = new List<Answer>();
    public IReadOnlyCollection<Answer> Answers => _answers;
    
    #pragma warning disable CS8618
    private Card() { }
    #pragma warning restore CS8618
    
    private Card(
        string cardName,
        string question,
        string? picturePath,
        IEnumerable<Answer> answers)
    {
        CardName = cardName;
        Question = question;
        PicturePath = picturePath;
        _answers = answers.ToList();
    }

    public static Result<Card> Create(
        string cardName,
        string question,
        string? picturePath,
        List<Answer>? answers)
    {
        if (string.IsNullOrWhiteSpace(cardName))
            return Result<Card>.Failure(DomainErrors.Card.EmptyName);

        if (cardName.Length is < 3 or > 25)
            return Result<Card>.Failure(DomainErrors.Card.InvalidName);
        
        if (string.IsNullOrWhiteSpace(question))
            return Result<Card>.Failure(DomainErrors.Card.EmptyQuestion);
        
        if (question.Length is < 2 or > 250)
            return Result<Card>.Failure(DomainErrors.Card.InvalidQuestion);

        if (answers is null || answers.Count is < 2 or > 4)
            return Result<Card>.Failure(DomainErrors.Card.InvalidLengthAnswers);

        if (answers.Count(a => a.IsCorrect) != 1)
            return Result<Card>.Failure(DomainErrors.Card.MustHaveExactlyOneCorrectAnswer);
        
        return Result<Card>.Success(new Card(cardName, question, picturePath, answers));
    }

    public Result UpdateCardDetails(string newName, string newQuestion, string? newPicturePath, List<Answer> newAnswers)
    {
        var validationResult = Create(newName, newQuestion, newPicturePath, newAnswers);
        if (validationResult.IsFailure)
            return Result.Failure(validationResult.Error!);

        CardName = newName;
        Question = newQuestion;
        PicturePath = newPicturePath;
        
        _answers.Clear();
        _answers.AddRange(newAnswers);
        
        return Result.Success();
    }
}