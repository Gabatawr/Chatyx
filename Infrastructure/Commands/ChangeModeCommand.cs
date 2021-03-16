using System.Windows;
using System.Windows.Controls;
using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Infrastructure.Services;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class ChangeModeCommand : Command
    {
        private readonly MainWindowViewModel vm;
        public ChangeModeCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Execute(object e)
        {
            if (((Button)((RoutedEventArgs)e).Source).Name == "BtnServerMode"
                && vm.AppMode.Current == AppModeService.Modes.Client)
            {
                vm.AppMode.Current = AppModeService.Modes.Server;
                vm.IsClientModeParam = false;
            }

            else if (((Button)((RoutedEventArgs)e).Source).Name == "BtnClientMode"
                && vm.AppMode.Current == AppModeService.Modes.Server)
            {
                vm.AppMode.Current = AppModeService.Modes.Client;
                vm.IsClientModeParam = true;
            }

            vm.ClientModeParam.Color = vm.AppMode.GetColor(AppModeService.Modes.Client);
            vm.ServerModeParam.Color = vm.AppMode.GetColor(AppModeService.Modes.Server);
        }

        public override bool CanExecute(object e) => true;
    }
}
