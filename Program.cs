namespace WeText;

public class WeText
{
    public static async Task Main(string[] args)
    {
        if (args.Length > 0 && args[0].ToLower() == "tui")
        {
            TuiClient.Init();
        }
        else
        {
            var daemon = new Daemon("/tmp/wetext.sock");
            await daemon.Start();
        }
    }
}
