using Chatyx.Infrastructure.Commands;
using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels.Base;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Chatyx.ViewModels
{
    class ShowImageWindowViewModel : ViewModel
    {
        #region ImageSource : OpenImageParam

        private ImageSource _OpenImageParam;
        public ImageSource OpenImageParam
        {
            get => _OpenImageParam;
            set => Set(ref _OpenImageParam, value);
        }

        #endregion ImageSource : OpenImageParam

        #region Command : CloseWindowCommand
        public Action CloseAction { get; set; }

        private AppCommand _CloseWindowCommand;
        public AppCommand CloseWindowCommand
        {
            get => _CloseWindowCommand ?? new ActionCommand
                (
                    param => ExecuteCloseWindowCommand((MouseEventArgs)param)
                );
            set => _CloseWindowCommand = value;
        }
        private void ExecuteCloseWindowCommand(MouseEventArgs e) => CloseAction.Invoke();

        #endregion Command : CloseWindowCommand
        #region Command : MoveWindowCommand
        public Action MoveAction { get; set; }

        private AppCommand _MoveWindowCommand;
        public AppCommand MoveWindowCommand
        {
            get => _MoveWindowCommand ?? new ActionCommand
                (
                    param => ExecuteMoveWindowCommand((MouseEventArgs)param)
                );
            set => _MoveWindowCommand = value;
        }
        private void ExecuteMoveWindowCommand(MouseEventArgs e) => MoveAction.Invoke();

        #endregion Command : MoveWindowCommand
    }
}
