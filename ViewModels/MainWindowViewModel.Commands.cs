using System.Collections.Generic;
using Chatyx.Infrastructure.Commands;
using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel
    {
        //--------------------------------------------------------------------
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
        #region Command : ChangeModeCommand

        private Command _ChangeModeCommand;
        public Command ChangeModeCommand
        {
            get => _ChangeModeCommand ??= new ChangeModeCommand(this);
            set => _ChangeModeCommand = value;
        }

        #endregion Command : ChangeModeCommand
        //--------------------------------------------------------------------
    }
}