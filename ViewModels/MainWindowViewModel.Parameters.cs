using Chatyx.Infrastructure.Services;
using System.Windows.Media;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel
    {
        //---------------------------------------------------------------------
        #region string : IPParam

        private string _IPParam;
        public string IPParam
        {
            get => _IPParam;
            set => Set(ref _IPParam, value);
        }

        #endregion string : IPParam
        //--------------------------------------------------------------------
        #region string : PortParam

        private string _PortParam;
        public string PortParam
        {
            get => _PortParam;
            set => Set(ref _PortParam, value);
        }

        #endregion string : PortParam
        //--------------------------------------------------------------------
        #region SolidColorBrush : ConnectColorParam

        private SolidColorBrush _ConnectColorParam;
        public SolidColorBrush ConnectColorParam
        {
            get => _ConnectColorParam ??= new SolidColorBrush(Colors.White);
            set => Set(ref _ConnectColorParam, value);
        }

        #endregion SolidColorBrush : ConnectColorParam
        //--------------------------------------------------------------------
        #region SolidColorBrush : ClientModeParam

        private SolidColorBrush _ClientModeParam;
        public SolidColorBrush ClientModeParam
        {
            get => _ClientModeParam ??= new SolidColorBrush(AppMode.GetColor(AppModeService.Modes.Client));
            set => Set(ref _ClientModeParam, value);
        }

        #endregion SolidColorBrush : ClientModeParam
        //--------------------------------------------------------------------
        #region SolidColorBrush : ServerModeParam

        private SolidColorBrush _ServerModeParam;
        public SolidColorBrush ServerModeParam
        {
            get => _ServerModeParam ??= new SolidColorBrush(AppMode.GetColor(AppModeService.Modes.Server));
            set => Set(ref _ServerModeParam, value);
        }

        #endregion SolidColorBrush : ServerModeParam
        //--------------------------------------------------------------------
        #region SolidColorBrush : IsClientModeParam

        private bool _IsClientModeParam;
        public bool IsClientModeParam
        {
            get => _IsClientModeParam;
            set => Set(ref _IsClientModeParam, value);
        }

        #endregion SolidColorBrush : IsClientModeParam
        //---------------------------------------------------------------------
    }
}
