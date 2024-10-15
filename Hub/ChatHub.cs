using Microsoft.AspNetCore.SignalR;

namespace TheVoiceOfCustomer
{
    public class ChatHub : Hub
    {
        // Basic notification without parameters
        public async Task SendNotification()
        {
            Console.WriteLine("HELLOOOOOOOO");
            await Clients.Others.SendAsync("ReceiveNotification", null);
        }

        // Notification with a user-defined message
        public async Task SendNotification2(string message)
        {
            await Clients.Others.SendAsync("ReceiveNotification", $"{message} This is Alpha-6. Permission to land?");
        }
    }
}