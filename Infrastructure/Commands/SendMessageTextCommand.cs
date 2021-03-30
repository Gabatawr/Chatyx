using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels;
using System.Text;

namespace Chatyx.Infrastructure.Commands
{
    class SendMessageTextCommand : AppCommand
    {
        private readonly MainWindowViewModel vm;
        public SendMessageTextCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Command(object e)
        {
            vm.Connect.Client.Send(Encoding.Unicode.GetBytes(vm.MessageTextParam));
            vm.MessageItems.Add(new(vm.MessageTextParam, true));
            vm.MessageTextParam = string.Empty;
        }

        public override bool CanExecute(object e)
            => string.IsNullOrEmpty(vm.MessageTextParam) is false;
    }
}
