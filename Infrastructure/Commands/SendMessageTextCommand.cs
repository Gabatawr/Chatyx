using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Model.Message;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class SendMessageTextCommand : AppCommand
    {
        private readonly MainWindowViewModel vm;
        public SendMessageTextCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Command(object e)
        {
            MessageData msg = new() { Text = vm.MessageTextParam };
            vm.Connect.SendMessage(msg);
            vm.Connect.ViewMessage(msg);
        }

        public override bool CanExecute(object e)
            => string.IsNullOrEmpty(vm.MessageTextParam) is false;
    }
}
