using System;
using System.Windows;

namespace Chatyx.Model
{
    public class MessageModel
    {
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
