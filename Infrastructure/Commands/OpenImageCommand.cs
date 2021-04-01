using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels;
using Chatyx.Views.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chatyx.Infrastructure.Commands
{
    class OpenImageCommand : AppCommand
    {
        private readonly MainWindowViewModel vm;
        public OpenImageCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Command(object e)
        {
            vm.OpenImageParam = ((e as MouseEventArgs).Source as Image).Source;

            ShowImageWindow wnd = new();
            wnd.Show();
        }

        public override bool CanExecute(object e) => true;
    }
}
