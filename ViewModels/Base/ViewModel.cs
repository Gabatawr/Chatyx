using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chatyx.ViewModels.Base
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propName = null)
        {
            if (Equals(field, value)) return false;
            else
            {
                field = value;
                OnPropertyChanged(propName);

                return true;
            }
        }
    }
}
