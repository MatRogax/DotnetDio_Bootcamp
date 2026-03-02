namespace desafio_rocketseat.models;

public enum Questions
{
    Welcome,
    Concatenation,
    Calculator,
    Accountant,
    LicensePlate,
    FormatedHours
    
}


public static class QuestionsExtensions
{
    public static Questions ToQuestion(this string option)
    {
        return option switch
        {
            "1" => Questions.Welcome,
            "2" => Questions.Concatenation,
            "3" => Questions.Calculator,
            "4" => Questions.Accountant,
            "5" => Questions.LicensePlate,
            "6" => Questions.FormatedHours,
            _ => throw new ArgumentException("Opção inválida.")
        };
    }

    public static void LaunchQuestion(this Questions question)
    {
        Action action = question switch
        {
            Questions.Welcome => Resolutions.ToWelcome,
            Questions.Concatenation => Resolutions.SetFullName,
            Questions.Calculator => Resolutions.Calculator,
            Questions.Accountant => Resolutions.ToAccountantCharacters,
            Questions.LicensePlate => Resolutions.ToValidateLicensePlate,
            Questions.FormatedHours => Resolutions.ToShowFormatsDateTime,
            _ => throw new ArgumentOutOfRangeException(nameof(question), question, null)
        };
        
        action();
    }
}