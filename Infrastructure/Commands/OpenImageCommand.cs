using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels;
using Chatyx.Views.Windows;
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
            ShowImageWindow wnd = new(((e as MouseEventArgs).Source as Image).Source);
            wnd.Show();
        }

        public override bool CanExecute(object e) => true;
    }
}
