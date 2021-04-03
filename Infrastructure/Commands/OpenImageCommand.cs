﻿using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Views.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chatyx.Infrastructure.Commands
{
    class OpenImageCommand : AppCommand
    {
        public override void Command(object e)
        {
            var images = ((e as MouseEventArgs).Source as ItemsControl).ItemsSource as List<byte[]>;
            ShowImageWindow wnd = new(images);
            wnd.Show();
        }

        public override bool CanExecute(object e) => true;
    }
}
