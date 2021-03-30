using Chatyx.Infrastructure.Services.Connection.Base;
using Chatyx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatyx.Infrastructure.Services.Connection
{
    internal class ClientConnectionService : AppConnectionService
    {
        //-----------------------------------------------------
        protected override bool Start()
        {
            try
            {
                IPEndPoint eP = new(IP, Port);
                Server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Server.Connect(eP);
            }
            catch { return false; }
            finally { Server.Close(); }

            Task.Factory.StartNew(MessageListener, Server);
            return true;
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
