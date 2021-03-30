using System.Collections.Generic;
using Chatyx.Infrastructure.Commands;
using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel
    {
        //---------------------------------------------------------------------
        #region Command : AppCommands

        private Dictionary<string, AppCommand> _AppCommands = new()
        {
            { nameof(MoveAppCommand),     new MoveAppCommand()     },
            { nameof(MinimizeAppCommand), new MinimizeAppCommand() },
            { nameof(CloseAppCommand),    new CloseAppCommand()    }
        };
        public Dictionary<string, AppCommand> AppCommands => _AppCommands;

        #endregion Command : AppCommands
        //---------------------------------------------------------------------
        #region Command : ConnectCommand

        private AppCommand _ConnectCommand;
        public AppCommand ConnectCommand
        {
            get => _ConnectCommand ??= new ConnectCommand(this);
            set => _ConnectCommand = value;
        }

        #endregion Command : ConnectCommand
        //---------------------------------------------------------------------
        #region Command : SendMessageTextCommand

        private AppCommand _SendMessageTextCommand;
        public AppCommand SendMessageTextCommand
        {
            get => _SendMessageTextCommand ??= new SendMessageTextCommand(this);
            set => _SendMessageTextCommand = value;
        }

        #endregion Command : SendMessageTextCommand
        //---------------------------------------------------------------------
        #region Command : ChangeModeCommand

        private AppCommand _ChangeModeCommand;
        public AppCommand ChangeModeCommand
        {
            get => _ChangeModeCommand ??= new ChangeModeCommand(this);
            set => _ChangeModeCommand = value;
        }

        #endregion Command : ChangeModeCommand
        //---------------------------------------------------------------------
        #region Command : LoginCommand

        private AppCommand _LoginCommand;
        public AppCommand LoginCommand
        {
            get => _LoginCommand ??= new LoginCommand(this);
            set => _LoginCommand = value;
        }

        #endregion Command : LoginCommand
        #region Command : RegistrationCommand

        private AppCommand _RegistrationCommand;
        public AppCommand RegistrationCommand
        {
            get => _RegistrationCommand ??= new RegistrationCommand(this);
            set => _RegistrationCommand = value;
        }

        #endregion Command : RegistrationCommand
        //---------------------------------------------------------------------
    }
}