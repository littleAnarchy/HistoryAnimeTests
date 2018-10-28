using System;
using System.ComponentModel;
using System.Threading;

namespace AdminApp.ViewModels
{
    public class MainViewModel : BasicViewModel
    {
        private readonly Timer _timer;
        private readonly Random _random = new Random();
        private double _num = 5;

        public double Num
        {
            get => _num;
            set
            {
                if (_num == value) return;
                _num = value;
                DoPropertyChanged();
            }
        }
           

        public MainViewModel()
        {
            _timer = new Timer(o => { Num = _random.NextDouble(); }, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1) );
        }
    }
}
