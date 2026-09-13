using System.Net.Sockets;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WeText;

public class Daemon
{
    private readonly string _socketPath;

    public Daemon(string socketPath)
    {
        _socketPath = socketPath;
    }
    
    public async Task Start()
    {
        if (File.Exists(_socketPath))
        {
            File.Delete(_socketPath);
        }

        var endpoint = new UnixDomainSocketEndPoint(_socketPath);
        
        using var listener = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.Unspecified);
        
        listener.Bind(endpoint);
        listener.Listen(backlog: 5);

        Console.WriteLine($"[Daemon] connexion");

        while (true)
        {
            var clientSocket = await listener.AcceptAsync();
            _ = Task.Run(() => HandleClientAsync(clientSocket));
        }
    }

    private async Task HandleClientAsync(Socket client)
    {
        using var stream = new NetworkStream(client, ownsSocket: true);
        using var reader = new StreamReader(stream, Encoding.UTF8);
        using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

        while (!reader.EndOfStream)
        {
            var messageFromTui = await reader.ReadLineAsync();
            if (string.IsNullOrWhiteSpace(messageFromTui)) continue;

            Console.WriteLine($"[Daemon] : {messageFromTui}");
        }
    }
}