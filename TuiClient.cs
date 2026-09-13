using Terminal.Gui;
using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace WeText;

public static class TuiClient
{
    public static void Init()
    {
        Application.Init();

        using Window window = new()
        {
            Title = "WeText"
        };

        Label label = new()
        {
            Text = "Hello, Terminal.Gui v2!",
            X = Pos.Center(),
            Y = Pos.Center()
        };

        window.Add(label);

        Application.Run(window);
        Application.Shutdown();
    }
}