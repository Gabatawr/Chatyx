using Chatyx.Model;
using Chatyx.ViewModels;
using System;
using System.Net;
using System.Net.Sockets;
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
        public abstract void SendMessage(string msg);
        //-----------------------------------------------------
        private MainWindowViewModel vm = (MainWindowViewModel)Application.Current.MainWindow.DataContext;
        protected MainWindowViewModel ViewModel => vm;
        //-----------------------------------------------------
        protected void MessageListener(Socket connect)
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
                        lock (ViewModel.MessageItemsBlock)
                            ViewModel.MessageItems.Add(new MessageModel(msgBuilder.ToString()));
                        msgBuilder.Clear();
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
        protected virtual void MessageListenerCatch(Socket connect) { }
        protected virtual void MessageListenerFinally(Socket connect) => connect.Close();
        //-----------------------------------------------------
    }
}
