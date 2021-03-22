using System.Net;
using System.Windows;
using Chatyx.Infrastructure.Services;
using Chatyx.ViewModels.Base;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {
        public AppModeService AppMode { get; }
        public ConnectionService Connect { get; }
        public MainWindowViewModel()
        {
            IsAppConnectedParam = true;
            IsAppDisconnectedParam = false;

            AppMode = new AppModeService(this);
            Connect = new ConnectionService(this);

            IPParam = IPAddress.Loopback.ToString();
            PortParam = 8180.ToString();

            MassagesListParam.Add("123");
            MassagesListParam.Add("123");
            MassagesListParam.Add("123");
            MassagesListParam.Add("123");

            _IsClientModeParam = AppMode.Current == AppModeService.Modes.Client;
        }
    }
}
