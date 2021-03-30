using Chatyx.Model;
using Chatyx.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatyx.Infrastructure.Services
{
    class ConnectionService
    {
        List<Socket> Clients = new();
        //-----------------------------------------------------
        public Socket Server { get; set; }
        public Socket Client { get; set; }
        //-----------------------------------------------------
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
        private bool StartClient()
        {
            try
            {
                IPEndPoint eP = new(IP, Port);
                Client = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Client.Connect(eP);
            }
            catch { return false; }

            Task.Factory.StartNew(MessageListener, Client);
            return true;
        }
        //-----------------------------------------------------
        private void MessageListener(object obj)
        {
            if (obj is Socket connect)
            {
                StringBuilder msgBuilder = new();
                var buff = new byte[256];

                try
                {
                    while (true)
                    {
                        do
                        {
                            int bytes = connect.Receive(buff);
                            msgBuilder.Append(Encoding.Unicode.GetString(buff, 0, bytes));
                        } while (connect.Available > 0);

                        if (String.IsNullOrEmpty(msgBuilder.ToString()) is false)
                        {
                            lock (vm.MessageItemsBlock)
                                vm.MessageItems.Add(new(msgBuilder.ToString()));
                            msgBuilder.Clear();
                        }
                    }
                }
                catch (Exception e)
                {
                    string s = e.Message;
                    Clients.Remove(connect);
                }
                finally { connect.Close(); }
            }
        }
        //-----------------------------------------------------
        public void ServerSendMessage(string msg)
        {
            foreach (var client in Clients)
                client.Send(Encoding.Unicode.GetBytes(vm.MessageTextParam));

            vm.MessageItems.Add(new(vm.MessageTextParam, true));
            vm.MessageTextParam = string.Empty;
        }
    }
}
