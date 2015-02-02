using System;
using Microsoft.AspNet.SignalR.Client;

namespace SignalR02.WinClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var hubConnection = new HubConnection(url: "http://localhost:1073/signalr");
            var chat = hubConnection.CreateHubProxy(hubName: "chat");

            chat.On<string>("hello", msg => {
                Console.WriteLine(msg);
            });

            hubConnection.Start().Wait();

            chat.Invoke<string>("sendMessage", "Hello!");

            Console.WriteLine("Press a key to terminate the client...");
            Console.Read();
        }
    }
}