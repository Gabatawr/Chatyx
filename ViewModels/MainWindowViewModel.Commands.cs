using System.Collections.Generic;
using System.Windows.Input;
using Chatyx.Infrastructure.Commands;
using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel
    {
        //---------------------------------------------------------------------
        #region Command : AppCommands

        private Dictionary<string, Command> _AppCommands = new()
        {
            { nameof(MoveAppCommand),     new MoveAppCommand()     },
            { nameof(MinimizeAppCommand), new MinimizeAppCommand() },
            { nameof(CloseAppCommand),    new CloseAppCommand()    }
        };
        public Dictionary<string, Command> AppCommands => _AppCommands;

        #endregion Command : AppCommands
        //---------------------------------------------------------------------
        #region Command : ConnectCommand

        private Command _ConnectCommand;
        public Command ConnectCommand
        {
            get => _ConnectCommand ??= new ConnectCommand(this);
            set => _ConnectCommand = value;
        }

        #endregion Command : ConnectCommand
        //---------------------------------------------------------------------
        #region Command : SendMessageTextCommand

        private Command _SendMessageTextCommand;
        public Command SendMessageTextCommand
        {
            get => _SendMessageTextCommand ??= new SendMessageTextCommand(this);
            set => _SendMessageTextCommand = value;
        }

        #endregion Command : SendMessageTextCommand
        //---------------------------------------------------------------------
        #region Command : ChangeModeCommand

        private Command _ChangeModeCommand;
        public Command ChangeModeCommand
        {
            get => _ChangeModeCommand ??= new ChangeModeCommand(this);
            set => _ChangeModeCommand = value;
        }

        #endregion Command : ChangeModeCommand
        //---------------------------------------------------------------------
        #region Command : LoginCommand

        private Command _LoginCommand;
        public Command LoginCommand
        {
            get => _LoginCommand ??= new LoginCommand(this);
            set => _LoginCommand = value;
        }

        #endregion Command : LoginCommand
        #region Command : RegistrationCommand

        private Command _RegistrationCommand;
        public Command RegistrationCommand
        {
            get => _RegistrationCommand ??= new RegistrationCommand(this);
            set => _RegistrationCommand = value;
        }

        #endregion Command : RegistrationCommand
        //---------------------------------------------------------------------
    }
}