using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdminApp.ViewModels
{
    public abstract class BasicViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;

        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Маркер занятости view
        /// </summary>
		public bool IsBusy
        {
            get => _isBusy;
            protected set
            {
                _isBusy = value;
                DoPropertyChanged(nameof(IsBusy));
            }
        }

        protected void DoAllPropertiesChanged()
        {
            DoPropertyChanged(string.Empty);
        }


        protected virtual void DoPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
