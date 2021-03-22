using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Infrastructure.Services;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class GoCommand : Command
    {
        private readonly MainWindowViewModel vm;
        public GoCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Execute(object e)
        {
            if (vm.Connect.TryConnect(vm.AppMode.Current))
                vm.AppConnected();
            else
                vm.AppDisconnected();
        }

        public override bool CanExecute(object e)
        {
            return vm.AppMode.Current == AppModeService.Modes.Client
                && vm.AppMode.Current == AppModeService.Modes.Server;
        }
    }
}
