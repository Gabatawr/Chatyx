using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Infrastructure.Services;
using Chatyx.Infrastructure.Services.Connection;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class ConnectCommand : AppCommand
    {
        private readonly MainWindowViewModel vm;
        public ConnectCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Command(object e)
        {
            if (vm.Connect.Start())
                vm.AppConnected();
            else
                vm.AppDisconnected();
        }

        public override bool CanExecute(object e) => vm.AppMode != null;
    }
}
