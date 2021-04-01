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
    }
}
