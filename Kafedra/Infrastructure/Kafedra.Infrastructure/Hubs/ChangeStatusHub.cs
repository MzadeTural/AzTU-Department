using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Infrastructure.Hubs
{
    public class ChangeStatusHub:Hub
    {
        public async Task UpdateStatus(string status,int index)
        {
            await Clients.All.SendAsync("ReceiveStatusUpdate", status,index); // Broadcast the status update to all connected clients
        }
    }
}
