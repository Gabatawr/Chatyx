using System;
using System.Windows;
using System.Windows.Interop;
using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Infrastructure.Fixers;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel
    {
        //--------------------------------------------------------------------
        #region Event : SourceInitializedEvent

        private Command _SourceInitializedEvent;
        public Command SourceInitializedEvent
            => _SourceInitializedEvent ??= new ActionCommand(exec => WindowSizeFixer.Fix());

        #endregion Event : SourceInitializedEvent
        //--------------------------------------------------------------------
    }
}
