namespace FuckingCalculator.UserInteraction;

public interface IUserInteractor
{
    void PrintWatermark();
    void ShowMessage(string message);
    string ReadInput();
}