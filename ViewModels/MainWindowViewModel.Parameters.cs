using Chatyx.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Media;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel
    {
        //--------------------------------------------------------------------
        #region string : IPParam

        private string _IPParam;
        public string IPParam
        {
            get => _IPParam;
            set
            {
                if (Set(ref _IPParam, value))
                {
                    IPAddress tmp;
                    if (IPAddress.TryParse(value, out tmp))
                        Connect.IP = tmp;
                    else
                        Set(ref _IPParam, Connect.IP.ToString());
                }
            }
        }

        #endregion string : IPParam
        #region string : PortParam

        private string _PortParam;
        public string PortParam
        {
            get => _PortParam;
            set 
            {
                if (Set(ref _PortParam, value))
                {
                    ushort tmp;
                    if (ushort.TryParse(value, out tmp))
                        Connect.Port = tmp;
                    else
                        Set(ref _PortParam, Connect.Port.ToString());
                }
            }
        }

        #endregion string : PortParam
        //--------------------------------------------------------------------
        #region string : GoTextParam

        private string _GoTextParam = "Connect";
        public string GoTextParam
        {
            get => _GoTextParam;
            set => Set(ref _GoTextParam, value);
        }

        #endregion string : GoTextParam
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
        #region SolidColorBrush : ServerModeParam

        private SolidColorBrush _ServerModeParam;
        public SolidColorBrush ServerModeParam
        {
            get => _ServerModeParam ??= new SolidColorBrush(AppMode.GetColor(AppModeService.Modes.Server));
            set => Set(ref _ServerModeParam, value);
        }

        #endregion SolidColorBrush : ServerModeParam
        //--------------------------------------------------------------------
        #region bool : IsClientModeParam

        private bool _IsClientModeParam;
        public bool IsClientModeParam
        {
            get => _IsClientModeParam;
            set => Set(ref _IsClientModeParam, value);
        }

        #endregion bool : IsClientModeParam
        //--------------------------------------------------------------------
        #region bool : IsAppDisconnectedParam

        private bool _IsAppDisconnectedParam;
        public bool IsAppDisconnectedParam
        {
            get => _IsAppDisconnectedParam;
            set => Set(ref _IsAppDisconnectedParam, value);
        }

        #endregion bool : IsAppDisconnectedParam
        #region bool : IsAppConnectedParam

        private bool _IsAppConnectedParam;
        public bool IsAppConnectedParam
        {
            get => _IsAppConnectedParam;
            set => Set(ref _IsAppConnectedParam, value);
        }

        #endregion bool : IsAppConnectedParam
        //--------------------------------------------------------------------
        #region List<string> : MassagesListParam

        private List<string> _MassagesListParam;
        public List<string> MassagesListParam
        {
            get => _MassagesListParam ??= new();
            set => Set(ref _MassagesListParam, value);
        }

        #endregion List<string> : MassagesListParam
        //--------------------------------------------------------------------
    }
}
