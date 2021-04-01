using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Model.Message;
using Chatyx.ViewModels;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace Chatyx.Infrastructure.Commands
{
    class SendMessageImageCommand : AppCommand
    {
        private readonly MainWindowViewModel vm;
        public SendMessageImageCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Command(object e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Open image";
            op.Filter = "PNG (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                MessageData msg;
                using (MemoryStream ms = new())
                {
                    var b = new Bitmap(op.FileName);
                    b.Save(ms, ImageFormat.Png);

                    msg = new() { Image = ms.ToArray() };
                }
                vm.Connect.SendMessage(msg);
                vm.Connect.ViewMessage(msg);
            }
        }

        public override bool CanExecute(object e) => true;
    }
}
