using System.Windows;
using Chatyx.Infrastructure.Services;
using Chatyx.ViewModels.Base;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel : ViewModel
    {
        public AppModeService AppMode { get; }
        public MainWindowViewModel()
        {
            // local
            IPParam = "127.0.0.1";
            PortParam = "8081";

            AppMode = new AppModeService(this);
            _IsClientModeParam = AppMode.Current == AppModeService.Modes.Client;
        }
    }
}
