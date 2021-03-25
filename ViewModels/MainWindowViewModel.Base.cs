using System.Net;
using System.Windows;
using Chatyx.Infrastructure.Services;
using Chatyx.Model;
using Chatyx.ViewModels.Base;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {
        public AppModeService AppMode { get; }
        public ConnectionService Connect { get; }
        public MainWindowViewModel()
        {
            ShowConnectPanelParam = true;
            ShowLoginPanelParam = false;
            ShowChatBoxPanelParam = false;

            
                MessageModel m1 = new MessageModel("Message 1");
                MessageModel m2 = new MessageModel("Message 2", true);
                MessageModel m3 = new MessageModel("Message 3");
                MessageModel m4 = new MessageModel("Message 4", true);
                MessageModel m5 = new MessageModel("Message 5", true);
                MessageItems.Add(m1);
                MessageItems.Add(m2);
                MessageItems.Add(m3);
                MessageItems.Add(m4);
                MessageItems.Add(m5);
            

            AppMode = new AppModeService(this);
            Connect = new ConnectionService(this);

            //IPParam = IPAddress.Loopback.ToString();
            //PortParam = 8180.ToString();

            _IsClientModeParam = AppMode.Current == AppModeService.Modes.Client;
        }
    }
}
