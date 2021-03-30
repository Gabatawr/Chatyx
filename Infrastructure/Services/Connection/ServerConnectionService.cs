using Chatyx.Infrastructure.Services.Connection.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatyx.Infrastructure.Services.Connection
{
    internal class ServerConnectionService : AppConnectionService
    {
        private List<Socket> Clients = new();
        //-----------------------------------------------------
        protected override bool Start()
        {
            try
            {
                IPEndPoint eP = new(IP, Port);
                Server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                Server.Bind(eP);
                Server.Listen(1);
            }
            catch { return false; }

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
        public override void SendMessage(string msg)
        {
            Server.Send(Encoding.Unicode.GetBytes(ViewModel().MessageTextParam));

            ViewModel().MessageItems.Add(new(ViewModel().MessageTextParam, true));
            ViewModel().MessageTextParam = string.Empty;
        }
    }
}
