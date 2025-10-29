using FuckingCalculator.Extensions;
namespace FuckingCalculator.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintWatermark()
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        ShowMessage("\n--- Powered by Suzume Evil Inc. ---\n");
        Console.ResetColor();
    }

    public string ReadInput()
    {
        string userInput;

        do
        {
            ShowMessage("Please, enter a valid mathematical expression:\n");
            userInput = Console.ReadLine();
        }
        while (!IsValid(userInput));

        return userInput;
    }

    private static bool IsValid(string userInput)
    {
        userInput = userInput.Replace(" ", "");

        if (string.IsNullOrEmpty(userInput))
            return false;

        if (!userInput.All(character => char.IsDigit(character) ||
            "+-*/^()".Contains(character)))
            return false;

        bool containsNumber = userInput.Any(char.IsDigit);
        bool containsOperator = "+-*/^".Any(
            @operator => userInput.Contains(@operator));
        if (!containsNumber || !containsOperator || userInput.Count(char.IsDigit) < 2)
            return false;

        if (userInput.StartsWithAny("+", "-", "*", "/", "^", ")") ||
            userInput.EndsWithAny("+", "-", "*", "/", "^", "("))
            return false;

        int openParentheses = userInput.Count(character => character == '(');
        int closeParentheses = userInput.Count(character => character == ')');
        if (openParentheses != closeParentheses)
            return false;

        return true;
    }
}