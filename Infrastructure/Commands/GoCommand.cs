using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class GoCommand : Command
    {
        private readonly MainWindowViewModel vm;
        public GoCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Execute(object e)
        {

        }

        public override bool CanExecute(object e)
        {
            return true;
        }
    }
}
