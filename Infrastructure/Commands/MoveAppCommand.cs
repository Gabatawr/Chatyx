using System.Windows;
using System.Windows.Input;
using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.Infrastructure.Commands
{
    class MoveAppCommand : Command
    {
        public override void Execute(object p) => Application.Current.MainWindow?.DragMove();
        public override bool CanExecute(object p)
            => ((p as MouseEventArgs).Source as FrameworkElement) == Application.Current.MainWindow;
    }
}
