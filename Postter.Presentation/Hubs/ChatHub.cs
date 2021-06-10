using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Postter.Presentation.Hubs
{
    public class ChatHub: Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}