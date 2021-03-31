using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class SendMessageTextCommand : AppCommand
    {
        private readonly MainWindowViewModel vm;
        public SendMessageTextCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Command(object e)
        {
            vm.Connect.SendMessage(vm.MessageTextParam);
        }

        public override bool CanExecute(object e)
            => string.IsNullOrEmpty(vm.MessageTextParam) is false;
    }
}
