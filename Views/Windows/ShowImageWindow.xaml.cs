using Chatyx.ViewModels;
using System;
using System.Windows;
using System.Windows.Media;

namespace Chatyx.Views.Windows
{
    public partial class ShowImageWindow : Window
    {
        public ShowImageWindow(ImageSource imageSource)
        {
            InitializeComponent();
            var vm = DataContext as ShowImageWindowViewModel;

            vm.OpenImageParam = imageSource;

            vm.CloseAction = new Action(Close);
            vm.MoveAction = new Action(DragMove);
        }
    }
}
