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
            AppMode = new AppModeService(this);
            _IsClientModeParam = AppMode.Current == AppModeService.Modes.Client;
        }
    }
}
