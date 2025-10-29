using FuckingCalculator.App;
using FuckingCalculator.UserInteraction;

var fuckingCalculatorApp = 
    new FuckingCalculatorApp(
        new ConsoleUserInteractor(),
        new ExpressionEvaluator()
        );

try
{
    fuckingCalculatorApp.Run();
}
catch (Exception ex)
{
    Console.WriteLine(
        $"\nAn unexpected error has occurred.\n" +
        $"Exception message: {ex.Message}\n");
    Console.WriteLine("Press any key to exit.");
}

Console.ReadKey();