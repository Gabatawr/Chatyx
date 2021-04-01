using Chatyx.Model;
using Chatyx.Model.Message;
using Chatyx.ViewModels;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;

namespace Chatyx.Infrastructure.Services.Connection.Base
{
    public abstract class AppConnectionService
    {
        //-----------------------------------------------------
        public Socket Server { get; set; }
        //-----------------------------------------------------
        private IPAddress _ip;
        public IPAddress IP 
        {
            get => _ip;
            set
            {
                _ip = value;
                ViewModel.IPParam = _ip.ToString();
            }
        }

        private ushort _port;
        public ushort Port
        {
            get => _port;
            set
            {
                _port = value;
                ViewModel.PortParam = _port.ToString();
            }
        }
        //-----------------------------------------------------
        public abstract bool Start();
        public abstract void SendMessage(MessageData msg);
        //-----------------------------------------------------
        private MainWindowViewModel vm = (MainWindowViewModel)Application.Current.MainWindow.DataContext;
        protected MainWindowViewModel ViewModel => vm;
        //-----------------------------------------------------
        protected void MessageListener(Socket connect)
        {
            var buff = new byte[256];
            try
            {
                while (true)
                {
                    BinaryFormatter bf = new();
                    MessageData msg = null;

                    using (MemoryStream ms = new())
                    {
                        using (NetworkStream ns = new(connect))
                        {
                            int bytes = ns.Read(buff, 0, 256);
                            int lenght = BitConverter.ToInt32(buff);

                            int count = 0;
                            do
                            {
                                bytes = ns.Read(buff, 0, 256);
                                ms.Write(buff, 0, bytes);
                                count += bytes;
                            } while (count < lenght);

                            ms.Position = 0;
                        }

                        if (ms.Length > 0)
                            msg = (MessageData)bf.Deserialize(ms);
                    }

                    if (msg != null)
                    {
                        MessageHandler(msg, connect);

                        lock (ViewModel.MessageItemsBlock)
                            ViewModel.MessageItems.Add(new MessageViev(msg));
                    }
                }
            }
            catch (Exception e)
            {
                string s = e.Message;
                MessageListenerCatch(connect); 
            }
            finally { MessageListenerFinally(connect); }
        }
        protected virtual void MessageHandler(MessageData msg, Socket sender) { }
        protected virtual void MessageListenerCatch(Socket connect) { }
        protected virtual void MessageListenerFinally(Socket connect) => connect.Close();
        //-----------------------------------------------------
        public virtual void ViewMessage(MessageData msg)
        {
            ViewModel.MessageItems.Add(new MessageViev(msg) { Alignment = HorizontalAlignment.Right });
            ViewModel.MessageTextParam = string.Empty;
        }
    }
}
