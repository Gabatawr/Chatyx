using Chatyx.Infrastructure.Commands;
using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels;
using System;
using System.Windows;
using System.Windows.Media;

namespace Chatyx.Model.Message
{
    public class MessageViev
    {
        //-----------------------------------------------------
        public HorizontalAlignment Alignment { get; init; } = HorizontalAlignment.Left;
        public SolidColorBrush Background { get; init; } = Brushes.Black;
        public SolidColorBrush Foreground { get; init; } = Brushes.White;
        //-----------------------------------------------------
        public MessageData Message { get; private set; }
        //-----------------------------------------------------
        public MessageViev(MessageData message) => Message = message;
        //-----------------------------------------------------
        #region Command : OpenImageCommand

        private AppCommand _OpenImageCommand;
        public AppCommand OpenImageCommand
        {
            get => _OpenImageCommand ??= new OpenImageCommand((MainWindowViewModel)Application.Current.MainWindow.DataContext);
            set => _OpenImageCommand = value;
        }

        #endregion Command : OpenImageCommand
    }
}
