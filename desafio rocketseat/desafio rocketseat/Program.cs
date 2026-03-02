using System;
using desafio_rocketseat.models;

while (true)
{
    Console.Clear();
    Console.WriteLine("================ MENU ================");
    Console.WriteLine("Escolha uma questão (1 a 6) ou 0 para sair:");
    Console.WriteLine("1 - Mensagem de Boas-vindas");
    Console.WriteLine("2 - Nome e Sobrenome");
    Console.WriteLine("3 - Calculadora");
    Console.WriteLine("4 - Contador de caracteres");
    Console.WriteLine("5 - Validar Placa");
    Console.WriteLine("6 - Formato de Data/Hora");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("======================================");
    Console.Write("Opção: ");

    var input = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(input) || input == "0") 
    {
        Console.WriteLine("Encerrando o programa...");
        break;
    }

    try
    {
        Console.Clear();
        Questions question = input.ToQuestion();
        question.LaunchQuestion();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}
