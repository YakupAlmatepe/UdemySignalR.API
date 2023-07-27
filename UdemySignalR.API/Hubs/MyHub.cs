using Microsoft.AspNetCore.SignalR;

namespace UdemySignalR.API.Hubs
{
    public class MyHub : Hub
    {

        public static List<string> Names { get; set; } = new List<string>();
        public async Task SendMessage(string name)
        {
              Names.Add(name);//api ayakta kaldığı sürece listeler içinde tutulur
              await   Clients.All.SendAsync("ReceiveName",name);
        }

        public async Task GetMessages() //clientler GetNames metodunu çağırdığında,ReceiveNames metodu tetiklenir ve Names parametresi gönderilir
        {
            await Clients.All.SendAsync("ReceiveName", Names);     
        }
    }
}
