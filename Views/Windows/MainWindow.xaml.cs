using Chatyx.ViewModels;
using System.Windows;

namespace Chatyx.Views.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
