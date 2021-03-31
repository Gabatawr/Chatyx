﻿using System;
using System.Windows.Input;

namespace Chatyx.Infrastructure.Commands.Base
{
    public abstract class AppCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract void Command(object e);
        public abstract bool CanExecute(object e);
        public void Execute(object e)
        {
            if (CanExecute(e)) Command(e);
        }
    }
}
