using PlickersService.Domain.Results;

namespace PlickersService.Domain.Errors;

public static class DomainErrors
{
    public static class Card
    {
        public static readonly Error EmptyName = 
            new Error(
                "Card.EmptyName",
                "Card name can't be empty");
        
        public static readonly Error InvalidName = 
            new Error(
                "Card.InvalidName",
                "Card name should be in range 1 - 25");
        
        public static readonly Error EmptyQuestion = 
            new Error(
                "Card.EmptyQuestion",
                "Card question can't be empty");
        
        public static readonly Error InvalidQuestion = 
            new Error(
                "Card.InvalidQuestion",
                "Card question should be in range 2 - 250");
        
        public static readonly Error InvalidLengthAnswers = 
            new Error(
                "Card.InvalidLengthAnswers",
                "Answers should be in range 2 - 4");
        
        public static readonly Error MustHaveExactlyOneCorrectAnswer = 
            new Error(
                "Card.MustHaveExactlyOneCorrectAnswer",
                "Answers should contain only one correct");
    }

    public static class Answer
    {
        public static readonly Error EmptyAnswer =
            new Error(
                "Answer.EmptyAnswer",
                "Answer can't be empty");
        
        public static readonly Error InvalidAnswer =
            new Error(
                "Answer.InvalidAnswer",
                "Answer should be in range 1 - 100");
    }

    public static class Pack
    {
        public static readonly Error EmptyName =
            new Error(
                "Pack.EmptyName",
                "Pack name can't be empty");
        
        public static readonly Error InvalidName =
            new Error(
                "Pack.InvalidName",
                "Pack name should be in range 1 - 30");
        
        public static readonly Error EmptyCard =
            new Error(
                "Pack.EmptyCard",
                "Can't add empty card in pack");
        
        public static readonly Error CardExists =
            new Error(
                "Pack.CardExists",
                "This card already exists");
    }

    public static class User
    {
        public static readonly Error EmptyEmail =
            new Error(
                "User.EmptyEmail",
                "Can't add empty email in user");
        
        public static readonly Error InvalidEmailLength =
            new Error(
                "User.InvalidEmailLength",
                "Email length should be in range 1 - 100 and should contain '.'");
        
        public static readonly Error InvalidEmailFormat =
            new Error(
                "User.InvalidEmailFormat",
                "Email doesn't correct format");
        
        public static readonly Error EmptyFirstName =
            new Error(
                "User.EmptyFirstName",
                "First name can't be empty");
        
        public static readonly Error InvalidFirstNameLength =
            new Error(
                "User.InvalidFirstNameLength",
                "First name length should be in range 2 - 30");
        
        public static readonly Error EmptyLastName =
            new Error(
                "User.EmptyLastName",
                "Last name can't be empty");
        
        public static readonly Error InvalidLastNameLength =
            new Error(
                "User.InvalidLastNameLength",
                "Last name length should be in range 2 - 30");
        
        public static readonly Error EmptyMiddleName =
            new Error(
                "User.EmptyMiddleName",
                "Middle name can't be empty");
        
        public static readonly Error InvalidMiddleNameLength =
            new Error(
                "User.InvalidMiddleNameLength",
                "Middle name length should be in range 2 - 30");
    }
}