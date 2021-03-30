using Chatyx.Model;
using Chatyx.ViewModels;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace Chatyx.Infrastructure.Services.Connection.Base
{
    internal abstract class AppConnectionService
    {
        //-----------------------------------------------------
        public Socket Server { get; set; }
        public IPAddress IP { get; set; }
        public UInt16 Port { get; set; }
        //-----------------------------------------------------
        public abstract void SendMessage(string msg);
        //-----------------------------------------------------
        protected abstract bool Start();
        //-----------------------------------------------------
        protected MainWindowViewModel ViewModel() => (MainWindowViewModel)Application.Current.MainWindow.DataContext;
        //-----------------------------------------------------
        protected virtual void MessageListener(object obj)
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
                            lock (ViewModel().MessageItemsBlock)
                                ViewModel().MessageItems.Add(new MessageModel(msgBuilder.ToString()));
                            msgBuilder.Clear();
                        }
                    }
                }
                catch { MessageListenerCatch(connect); }
                finally { MessageListenerFinally(connect); }
            }
        }
        protected virtual void MessageListenerCatch(Socket connect) { }
        protected virtual void MessageListenerFinally(Socket connect) => connect.Close();
        //-----------------------------------------------------
    }
}
