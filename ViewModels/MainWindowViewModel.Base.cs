using System.Net;
using System.Windows;
using System.Windows.Data;
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
            BindingOperations.EnableCollectionSynchronization(MessageItems, MessageItemsBlock);

            ShowConnectPanelParam = true;
            ShowLoginPanelParam = false;
            ShowChatBoxPanelParam = false;

            AppMode = new AppModeService(this);
            Connect = new ConnectionService(this);

            IPParam = IPAddress.Loopback.ToString();
            PortParam = 8180.ToString();

            LoginParam = "Admin";
            PasswordParam = "admin";

            _IsClientModeParam = AppMode.Current == AppModeService.Modes.Client;
        }
    }
}
