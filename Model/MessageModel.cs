using System;
using System.Windows;

namespace Chatyx.Model
{
    public class MessageModel
    {
        //[System.Windows.Localizability(System.Windows.LocalizationCategory.None, Readability = System.Windows.Readability.Unreadable)]
        //public enum HorizontalAlignment { Left = 0, Center = 1,  Right = 2, Stretch = 3 }
        public HorizontalAlignment Alignment { get; private set; }

        private DateTime time = DateTime.Now;
        public string Time => time.ToString("T") + " :";

        public string Message { get; private set; }

        public MessageModel(string message, bool isClient = false)
        {
            Alignment = isClient ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            Message = message;
        }
    }
}
