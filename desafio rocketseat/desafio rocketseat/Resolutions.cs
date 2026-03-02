using System.Globalization;
using System.Text.RegularExpressions;
using desafio_rocketseat;
using desafio_rocketseat.models;

public static class Resolutions
{

    public static void ToWelcome()
    {
        string? name = Console.ReadLine();
        Console.WriteLine($"Olá, {name}! Seja muito bem-vindo!");
    }

    public static void SetFullName()
    {
        string? name = Console.ReadLine();
        string? lasName = Console.ReadLine();
        var user =  new User(name, lasName);
        user.SetFullName();
    }

    public static void Calculator()
    {
        
        var value1 = double.Parse(Console.ReadLine() ?? string.Empty);
        var value2 = double.Parse(Console.ReadLine() ?? string.Empty);
        
        if (value1 == 0.0 && value2 == 0.0)
        {
            Console.WriteLine("Nenhum valor informado.");
        }
        
        var calculator  = new Calculator(value1, value2);
        
        Console.WriteLine($"soma:  {calculator.Sum()}");
        Console.WriteLine($"subtracao: {calculator.Subtraction()}");
        Console.WriteLine($"multiplicacao:  {calculator.Multiplication()}");
        Console.WriteLine($"divisao: {calculator.Division()}");
        Console.WriteLine($"media: {calculator.Average()}");
        
    }

    public static void ToAccountantCharacters()
    {
        string? word = Console.ReadLine();
        
        if (word != null)
        {
            string toCleanWord = word.Replace(" ", "").Trim();
            Console.WriteLine($"quantidade de caracteres:{toCleanWord.Length}");
        }
    }

    public static void ToValidateLicensePlate()
    {
        string plate;
        bool isValid = false;
        
        do
        {
            Console.Write("Digite a placa:");
            plate = Console.ReadLine()?.Trim() ?? "";
            
            isValid = Regex.IsMatch(plate, @"^[a-zA-Z]{3}[0-9]{4}$");
        
            if (!isValid)
            {
                Console.WriteLine("Placa inválida! Tente novamente.");
            }
        
        } while (!isValid);
        
        Console.WriteLine($"Placa aceita: {plate.ToUpper()}");

    }

    public static void ToShowFormatsDateTime()
    {
        DateTime now = DateTime.Now;
        CultureInfo culturaBr = new CultureInfo("pt-BR");
    
        Console.WriteLine("--- Exibição de Data e Hora ---" + Environment.NewLine);
    
        Console.WriteLine("1. Formato Completo:");
        Console.WriteLine(now.ToString("dddd, dd 'de' MMMM 'de' yyyy, HH:mm:ss", culturaBr));
        Console.WriteLine();
    
        Console.WriteLine("2. Apenas a Data:");
        Console.WriteLine(now.ToString("dd/MM/yyyy"));
        Console.WriteLine();
    
        Console.WriteLine("3. Apenas a Hora (24h):");
        Console.WriteLine(now.ToString("HH:mm"));
        Console.WriteLine();
    
        Console.WriteLine("4. Mês por Extenso:");
        Console.WriteLine(now.ToString("dd 'de' MMMM 'de' yyyy", culturaBr));
    
        Console.WriteLine(Environment.NewLine + "-------------------------------");
    }
    
}