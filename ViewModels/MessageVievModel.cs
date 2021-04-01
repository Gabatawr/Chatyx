using Chatyx.Infrastructure.Commands;
using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Model;
using System.Windows;
using System.Windows.Media;

namespace Chatyx.ViewModels
{
    public class MessageVievModel
    {
        //-----------------------------------------------------
        public HorizontalAlignment Alignment { get; init; } = HorizontalAlignment.Left;
        public SolidColorBrush Background { get; init; } = Brushes.Black;
        public SolidColorBrush Foreground { get; init; } = Brushes.White;
        //-----------------------------------------------------
        public MessageModel Message { get; private set; }
        //-----------------------------------------------------
        public MessageVievModel(MessageModel message) => Message = message;
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
