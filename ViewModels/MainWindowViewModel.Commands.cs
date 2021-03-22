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
        #region Command : GoCommand

        private Command _GoCommand;
        public Command GoCommand
        {
            get => _GoCommand ??= new GoCommand(this);
            set => _GoCommand = value;
        }

        #endregion Command : GoCommand
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