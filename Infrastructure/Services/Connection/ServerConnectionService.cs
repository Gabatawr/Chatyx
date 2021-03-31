using Chatyx.Infrastructure.Services.Connection.Base;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatyx.Infrastructure.Services.Connection
{
    public class ServerConnectionService : AppConnectionService
    {
        //-----------------------------------------------------
        public ServerConnectionService()
        {
            Port = 8180;
            IP = IPAddress.Loopback;
        }
        private List<Socket> Clients = new();
        //-----------------------------------------------------
        public override bool Start()
        {
            try
            {
                Server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                Server.Bind(new IPEndPoint(IP, Port));
                Server.Listen(1);
            }
            catch
            {
                Server.Close();
                return false;
            }

            Task.Run(ServerConnectWaitHandler);
            return true;
        }
        private void ServerConnectWaitHandler()
        {
            try
            {
                while (true)
                {
                    Socket client = Server.Accept();
                    Clients.Add(client);
                    Task.Run(() => MessageListener(client));
                }
            }
            catch { }
            finally { Server.Close(); }
        }
        //-----------------------------------------------------
        protected override void MessageListenerCatch(Socket connect)
            => Clients.Remove(connect);
        //-----------------------------------------------------
        public override void SendMessage(string msg)
        {
            foreach (var client in Clients)
                client.Send(Encoding.Unicode.GetBytes(ViewModel.MessageTextParam));

            ViewModel.MessageItems.Add(new(ViewModel.MessageTextParam, true));
            ViewModel.MessageTextParam = string.Empty;
        }
    }
}
