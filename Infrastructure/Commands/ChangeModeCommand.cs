using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Infrastructure.Services;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class ChangeModeCommand : AppCommand
    {
        private readonly MainWindowViewModel vm;
        public ChangeModeCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Command(object e)
        {
            if (vm.AppMode == null) vm.AppMode = new();

            if (((Button)((RoutedEventArgs)e).Source).Name == "BtnClientMode")
            {
                vm.AppMode.Current = AppModeService.Modes.Client;

                vm.IsClientModeParam = true;
                vm.GoTextParam = "Connect";

                vm.ClientModeParam.Color = AppModeService.EnableColor;
                vm.ServerModeParam.Color = AppModeService.DisableColor;
            }

            else if (((Button)((RoutedEventArgs)e).Source).Name == "BtnServerMode")
            {
                vm.AppMode.Current = AppModeService.Modes.Server;

                vm.IsClientModeParam = false;
                vm.GoTextParam = "Start";

                vm.ClientModeParam.Color = AppModeService.DisableColor;
                vm.ServerModeParam.Color = AppModeService.EnableColor;
            }
        }

        public override bool CanExecute(object e) => true;
    }
}
