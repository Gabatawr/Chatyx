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
            { nameof(MaximizeAppCommand), new MaximizeAppCommand() },
            { nameof(CloseAppCommand),    new CloseAppCommand()    }
        };
        public Dictionary<string, Command> AppCommands => _AppCommands;

        #endregion Command : AppCommands
        //--------------------------------------------------------------------
    }
}