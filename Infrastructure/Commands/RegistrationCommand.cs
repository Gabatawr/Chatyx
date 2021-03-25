using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class RegistrationCommand : Command
    {
        private readonly MainWindowViewModel vm;
        public RegistrationCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Execute(object e)
        {
            
        }

        public override bool CanExecute(object e)
        {
            return true;
        }
    }
}
