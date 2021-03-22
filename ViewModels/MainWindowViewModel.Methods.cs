using System.Windows.Media;


namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel
    {
        public void AppConnected()
        {
            IsAppDisconnectedParam = false;
            IsAppConnectedParam = true;

            ConnectColorParam.Color = new Color { A = 255, R = 0, G = 125, B = 255 };
        }
        public void AppDisconnected()
        {
            IsAppDisconnectedParam = true;
            IsAppConnectedParam = false;

            ConnectColorParam.Color = new Color { A = 255, R = 255, G = 69, B = 0 };
        }
    }
}
