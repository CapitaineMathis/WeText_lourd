using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;


namespace WeText;

public class WeText
{
    static void Main(string[] args)
    {
        int terminalWidth;
        int terminalHeight;

        try
        {
            terminalWidth = Console.WindowWidth;
            terminalHeight = Console.WindowHeight;
        }
        catch (IOException)
        {
            // Console dimensions unavailable.
            terminalWidth = 120;
            terminalHeight = 40;
        }
    }
}
