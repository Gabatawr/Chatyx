using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels;
using System.Text;

namespace Chatyx.Infrastructure.Commands
{
    class SendMessageTextCommand : Command
    {
        private readonly MainWindowViewModel vm;
        public SendMessageTextCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Execute(object e)
        {
            vm.Connect.Client.Send(Encoding.Unicode.GetBytes(vm.MessageTextParam));
            vm.MessageItems.Add(new(vm.MessageTextParam, true));
        }

        public override bool CanExecute(object e)
        {
            return string.IsNullOrEmpty(vm.MessageTextParam) is false;
        }
    }
}
