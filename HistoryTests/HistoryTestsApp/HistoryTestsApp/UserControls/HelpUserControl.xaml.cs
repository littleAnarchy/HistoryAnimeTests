using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using HistoryTestsApp.Enums;
using HistoryTestsApp.ViewModels;

namespace HistoryTestsApp.UserControls
{
    /// <summary>
    /// Interaction logic for HelpUserControl.xaml
    /// </summary>
    public partial class HelpUserControl : UserControl
    {
        private Timer _timer;
        private double _currentTopMargin;
        private double _topMargin;
        private double _bottomMargin;
        private bool _isMoved;
        private bool _isShow;
        private GameViewModel _viewModel;

        public event EventHandler HelpShowingEnded;

        public void OnHelperInfoChanged(object sender, HelperType type)
        {
            switch (type)
            {
                case HelperType.BomjNikolay:
                    HelperName.Content = "Бомж Ніколай";
                    HelperImage.Source = new BitmapImage(new Uri(@"../Resources/9f14ab62-2be1-4a31-867a-c8ef32fad2e2.png", UriKind.Relative));
                    break;
                case HelperType.OdoklasnikVova:
                    HelperName.Content = "Однокласник Вова";
                    HelperImage.Source = new BitmapImage(new Uri(@"../Resources/358c815b-2a68-4598-b054-9c088627d816.png", UriKind.Relative));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void ShowHide(object sender, bool isShow)
        {
            if (_isMoved) return;
            _isShow = isShow;
            _isMoved = true;
            if (isShow)
            {
                HelpText.PushMessageImmidiatly("");
                _topMargin = 0;
                _bottomMargin = 190;
            }
            else
            {
                _topMargin = ActualHeight;
                _bottomMargin = 200;
            }

            _currentTopMargin = Margin.Top;
            _timer.Start();
        }

        public void Initialize(GameViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.HelperInfoChanged += OnHelperInfoChanged;
            HelpText.IsNormaLineStrategy = true;
        }

        public HelpUserControl()
        {
            InitializeComponent();
            HelpText.TextPushingEnded += OnTextPushingEnded;
            _timer = new Timer(0.005);
            _timer.Elapsed += TimerOnElapsed;
            Margin = new Thickness(0,750,200,250);
            Debug.WriteLine($"Top: {Margin.Top}: Bottom: {Margin.Bottom}");
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if ((int)_currentTopMargin == (int)_topMargin)
                {
                    _timer.Stop();
                    _isMoved = false;
                    System.Diagnostics.Debug.WriteLine("Anime ended");
                    if (_isShow)
                        HelpText.PushMessage(_viewModel.HelpText);
                    else
                        HelpShowingEnded?.Invoke(this, null);
                    return;
                }

                if (_currentTopMargin > _topMargin)
                {
                    _currentTopMargin -= 10;
                }
                else
                {
                    _currentTopMargin += 10;
                }

                Margin = new Thickness(0, _currentTopMargin, 200, _bottomMargin);
                System.Diagnostics.Debug.WriteLine($"Top: {Margin.Top}: Bottom: {Margin.Bottom}");
            });
        }

        private void OnTextPushingEnded(object sender, EventArgs args)
        {
            HelpShowingEnded?.Invoke(this, null);
        }
    }
}
