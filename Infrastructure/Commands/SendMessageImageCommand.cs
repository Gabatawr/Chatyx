using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Model;
using Chatyx.ViewModels;
using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Chatyx.Infrastructure.Commands
{
    class SendMessageImageCommand : AppCommand
    {
        private readonly MainWindowViewModel vm;
        public SendMessageImageCommand(MainWindowViewModel vm) => this.vm = vm;

        public override void Command(object e)
        {
            OpenFileDialog ofd = new();
            ofd.Title = "Open image";
            ofd.Filter = "PNG (*.png)|*.png";

            if (ofd.ShowDialog() == true)
            {
                MessageModel msg;
                using (MemoryStream ms = new())
                {
                    var b = new Bitmap(ofd.FileName);
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
