using Chatyx.ViewModels;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
            catch {return Disconnect();}

            Task.Run(() =>
            {
                while (true)
                {
                    Socket client = server.Accept();
                    Task.Run(() =>
                    {
                        try
                        {
                            StringBuilder clientMsg = new();
                            var buff = new byte[256];
                            int bytes = 0;

                            while (true)
                            {
                                do
                                {
                                    bytes = client.Receive(buff);
                                    clientMsg.Append(Encoding.ASCII.GetString(buff, 0, bytes));
                                } while (client.Available > 0);

                                string Massege(Socket s, string msg)
                                {
                                    var dtn = DateTime.Now;
                                    return dtn.ToString("t")
                                    + " from "
                                    + $"[{s.LocalEndPoint}]"
                                    + $" : {msg}";
                                }

                                //Console.WriteLine(Massege(client, clientMsg.ToString()));
                                clientMsg.Clear();

                                client.Send(Encoding.ASCII.GetBytes(Massege(client, "Message received")));
                            }
                        }
                        catch {}
                        finally {client.Close(); }
                    });
                }
            }).ContinueWith((t) => {server.Close();});

            return true;
        }

        private bool StartClient()
        {
            Socket client;

            try
            {
                IPEndPoint eP = new(IP, Port);
                client = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(eP);
            }
            catch {return Disconnect(); }

            StringBuilder serverMsg = new();
            var buff = new byte[256];
            int bytes = 0;

            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        //Console.Write("Message : ");
                        string msg = "Hello World";//Console.ReadLine();

                        if (string.IsNullOrEmpty(msg) is false)
                        {
                            client.Send(Encoding.ASCII.GetBytes(msg));
                            do
                            {
                                bytes = client.Receive(buff);
                                serverMsg.Append(Encoding.ASCII.GetString(buff, 0, bytes));
                            } while (client.Available > 0);

                            //Console.WriteLine(serverMsg);
                            serverMsg.Clear();
                        }
                        //else Console.WriteLine("Massage empty..");
                        //Console.WriteLine();
                    }
                }
                catch {}
                finally {client.Close();}
            });

            return true;
        }
        //-----------------------------------------------------
        private bool Disconnect()
        {
            vm.IsAppDisconnectedParam = true;
            vm.IsAppConnectedParam = false;

            vm.ConnectColorParam.Color = new Color { A = 255, R = 255, G = 69, B = 0 };

            return false;
        }
    }
}
