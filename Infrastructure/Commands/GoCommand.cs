using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Infrastructure.Services;
using Chatyx.ViewModels;
using System.Windows.Media;

namespace Chatyx.Infrastructure.Commands
{
    class GoCommand : Command
    {
        private readonly MainWindowViewModel vm;
        public GoCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Execute(object e)
        {
            if (vm.Connect.TryConnect(vm.AppMode.Current))
            {
                vm.IsAppDisconnectedParam = false;
                vm.IsAppConnectedParam = true;

                vm.ConnectColorParam.Color = new Color { A = 255, R = 0, G = 125, B = 255 };
            }
        }

        public override bool CanExecute(object e)
        {
            return vm.AppMode.Current == AppModeService.Modes.Client
                && vm.AppMode.Current == AppModeService.Modes.Server;
        }
    }
}
