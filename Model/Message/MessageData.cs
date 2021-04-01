using Chatyx.ViewModels;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chatyx.Model.Message
{
    [Serializable]
    public class MessageData
    {
        //-----------------------------------------------------
        public string Time { get; init; } = " " + DateTime.Now.ToString("t");
        //-----------------------------------------------------
        public string SenderName { get; } = ((MainWindowViewModel)Application.Current.MainWindow.DataContext).LoginParam;
        //-----------------------------------------------------
        public string? Text { get; init; }
        public byte[]? Image { get; init; }
        //-----------------------------------------------------
    }
}