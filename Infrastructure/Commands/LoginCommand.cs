using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class LoginCommand : Command
    {
        private readonly MainWindowViewModel vm;
        public LoginCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Execute(object e)
        {
            // TODO: LoginService
            if (vm.LoginParam == "Admin" && vm.PasswordParam == "admin")
                vm.AppLoginON();
            else vm.AppLoginOFF();
        }

        public override bool CanExecute(object e)
        {
            return true;
        }
    }
}
