using Chatyx.ViewModels;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatyx.Infrastructure.Services
{
    class ConnectionService
    {
        public IPAddress IP { get; set; }
        public UInt16 Port { get; set; }
        //-----------------------------------------------------
        private MainWindowViewModel vm;
        public ConnectionService(MainWindowViewModel vm) => this.vm = vm;
        //-----------------------------------------------------
        public bool TryConnect(AppModeService.Modes mode)
        {
            return mode == AppModeService.Modes.Server ? StartServer() :
                   mode == AppModeService.Modes.Client ? StartClient() : false;
        }
        //-----------------------------------------------------
        private bool StartServer()
        {
            Socket server;

            try
            {
                IPEndPoint eP = new(IP, Port);
                server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                server.Bind(eP);
                server.Listen(10);
            }
            catch { return false; }

            Task.Factory.StartNew(ServerConnectWaitHandler, server);
            return true;
        }
        private void ServerConnectWaitHandler(object obj)
        {
            if (obj is Socket server)
            {
                try
                { 
                    while (true)
                    {
                        Socket client = server.Accept();
                        Task.Factory.StartNew(MessageListener, client);
                    }
                }
                catch { }
                finally { server.Close(); }
                
            }
        }
        //-----------------------------------------------------
        private bool StartClient()
        {
            Socket server;

            try
            {
                IPEndPoint eP = new(IP, Port);
                server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(eP);
            }
            catch { return false; }

            Task.Factory.StartNew(MessageListener, server);
            return true;
        }
        //-----------------------------------------------------
        private void MessageListener(object obj)
        {
            if (obj is Socket connect)
            {
                StringBuilder msgBuilder = new();
                var buff = new byte[256];
                int bytes = 0;

                try
                {
                    while (true)
                    {
                        do
                        {
                            bytes = connect.Receive(buff);
                            msgBuilder.Append(Encoding.ASCII.GetString(buff, 0, bytes));
                        } while (connect.Available > 0);
                    }
                }
                catch { }
                finally { connect.Close(); }
            }
        }

        //-----------------------------------------------------
    }
}
