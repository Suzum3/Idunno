using FuckingCalculator.UserInteraction;
namespace FuckingCalculator.App;

public class FuckingCalculatorApp
{
    private readonly IUserInteractor _userInteractor;
    private readonly ExpressionEvaluator _expressionEvaluator;
    public FuckingCalculatorApp(
        IUserInteractor userInteractor,
        ExpressionEvaluator expressionEvaluator)
    {
        _userInteractor = userInteractor;
        _expressionEvaluator = expressionEvaluator;
    }
    public void Run()
    {
        _userInteractor.PrintWatermark();
        _userInteractor.ShowMessage("Welcome to the FuckingCalculator application!");

        var userInput = _userInteractor.ReadInput();
        var result = _expressionEvaluator.Evaluate(userInput);

        _userInteractor.ShowMessage($"The result is: {result}\n");
        _userInteractor.ShowMessage("Press any key to exit.");
    }
}