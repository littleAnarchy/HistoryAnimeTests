
using System;
using System.Runtime.InteropServices;
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

        public static readonly DependencyProperty TextWidthProperty = DependencyProperty.Register(nameof(TextWidth), typeof(double), typeof(VisualNovelTextBox), new PropertyMetadata(100.0));

        private bool _isNormalLineStrategy;

        public event EventHandler TextPushingEnded;

        public bool IsNormaLineStrategy
        {
            get => _isNormalLineStrategy;
            set
            {
                if (value)
                {
                    VisualMessage.LineStackingStrategy = LineStackingStrategy.BlockLineHeight;
                    VisualMessage.LineHeight = 30;
                }

                _isNormalLineStrategy = value;
            }
        }

        public double OutputInterval
        {
            get => (double) GetValue(OutputIntervalProperty);
            set => SetValue(OutputIntervalProperty, value);
        }

        public double TextWidth
        {
            get => (double) GetValue(TextWidthProperty);
            set => SetValue(TextWidthProperty, value);
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
                TextPushingEnded?.Invoke(this, null);
                return;
            }

            _timer.Stop();
            Dispatcher.Invoke(() => VisualMessage.Text += _inputText[_index]);
            _index++;
            _timer.Start();
        }

        public void PushMessageImmidiatly(string message)
        {
            _timer.Stop();
            _index = 0;
            IsPushed = false;
            VisualMessage.Text = message;
            TextPushingEnded?.Invoke(this, null);
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
