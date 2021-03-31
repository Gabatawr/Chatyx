using Chatyx.Infrastructure.Services.Connection.Base;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatyx.Infrastructure.Services.Connection
{
    public class ClientConnectionService : AppConnectionService
    {
        //-----------------------------------------------------
        public ClientConnectionService()
        {
            Port = 8180;
            IP = IPAddress.Loopback;
        }
        //-----------------------------------------------------
        public override bool Start()
        {
            try
            {
                Server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Server.Connect(new IPEndPoint(IP, Port));
            }
            catch
            { 
                Server.Close();
                return false; 
            }

            Task.Run(() => MessageListener(Server));
            return true;
        }
        //-----------------------------------------------------
        public override void SendMessage(string msg)
        {
            Server.Send(Encoding.Unicode.GetBytes(ViewModel.MessageTextParam));

            ViewModel.MessageItems.Add(new(ViewModel.MessageTextParam, true));
            ViewModel.MessageTextParam = string.Empty;
        }
    }
}
