using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class LoginCommand : AppCommand
    {
        private readonly MainWindowViewModel vm;
        public LoginCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Command(object e)
        {
            // TODO: LoginService
            if (vm.LoginParam == "Admin" && vm.PasswordParam == "admin")
                vm.AppLoginON();
            else vm.AppLoginOFF();
        }

        public override bool CanExecute(object e) => true;
    }
}
