using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Infrastructure.Services;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class ConnectCommand : AppCommand
    {
        private readonly MainWindowViewModel vm;
        public ConnectCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Command(object e)
        {
            if (vm.Connect.TryConnect(vm.AppMode.Current))
                vm.AppConnected();
            else
                vm.AppDisconnected();
        }

        public override bool CanExecute(object e)
        {
            return vm.AppMode.Current == AppModeService.Modes.Client
                || vm.AppMode.Current == AppModeService.Modes.Server;
        }
    }
}
