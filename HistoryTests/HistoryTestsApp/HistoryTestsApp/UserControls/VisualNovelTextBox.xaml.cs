
using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace HistoryTestsApp.UserControls
{
    /// <summary>
    /// Interaction logic for VisualNovelTextBox.xaml
    /// </summary>
    public partial class VisualNovelTextBox : UserControl
    {
        public bool IsPushed;

        private readonly Timer _timer;
        private string _inputText;
        private int _index;

        public static readonly DependencyProperty OutputIntervalProperty = DependencyProperty.Register(
            nameof(OutputInterval), typeof(double), typeof(VisualNovelTextBox), new PropertyMetadata(40.0));

        public double OutputInterval
        {
            get => (double) GetValue(OutputIntervalProperty);
            set => SetValue(OutputIntervalProperty, value);
        }

        public VisualNovelTextBox()
        {
            InitializeComponent();
            _timer = new Timer(OutputInterval);
            _timer.Elapsed += TimerOnElapsed;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (_inputText.Length == _index)
            {
                _timer.Stop();
                _index = 0;
                IsPushed = false;
                return;
            }

            Dispatcher.Invoke(() => VisualMessage.Text += _inputText[_index]);
            _index++;
        }

        public void PushMessageImmidiatly(string message)
        {
            _timer.Stop();
            _index = 0;
            IsPushed = false;
            VisualMessage.Text = message;
        }

        public void PushMessage(string message)
        {
            IsPushed = true;
            VisualMessage.Text = "";
            _inputText = message;

            _timer.Interval = OutputInterval;
            _timer.Start();
        }
    }
}
