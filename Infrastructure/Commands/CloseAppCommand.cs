using System.Windows;
using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.Infrastructure.Commands
{
    class CloseAppCommand : Command
    {
        public override void Execute(object p) => Application.Current.Shutdown();
        public override bool CanExecute(object p) => true;
    }
}
