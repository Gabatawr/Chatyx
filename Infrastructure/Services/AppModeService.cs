using System.Windows.Media;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Services
{
    internal class AppModeService
    {
        public enum Modes { Client, Server }
        public Modes Current { get; set; } = Modes.Client;

        public Color GetColor(Modes mode) => Current == mode ? 
                new Color() { A = 255, R = 119, G = 119, B = 119 } // Enable
                : new Color() { A = 255, R = 68, G = 68, B = 68 }; // Disable

        private MainWindowViewModel vm;
        public AppModeService(MainWindowViewModel vm) => this.vm = vm;
    }
}
