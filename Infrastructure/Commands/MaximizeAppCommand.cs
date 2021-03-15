using System.Windows;
using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.Infrastructure.Commands
{
    class MaximizeAppCommand : Command
    {
        public override void Execute(object p)
        {
            var win = Application.Current.MainWindow;
            win.WindowState = win.WindowState switch
            {
                WindowState.Normal => WindowState.Maximized,
                _ => WindowState.Normal
            };
        }
        public override bool CanExecute(object p) => true;
    }
}
