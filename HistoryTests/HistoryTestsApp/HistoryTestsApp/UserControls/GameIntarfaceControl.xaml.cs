using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HistoryTestsApp.ViewModels;

namespace HistoryTestsApp.UserControls
{
    /// <summary>
    /// Interaction logic for GameIntarfaceControl.xaml
    /// </summary>
    public partial class GameIntarfaceControl : UserControl
    {
        private readonly GameViewModel _viewModel;

        private readonly Timer _timer;
        private bool _isLastAnswerTrue;
        private int _currentFlash;
        private int _flashCount = 6;

        public GameIntarfaceControl(GameViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            _viewModel = viewModel;
            Help.DataContext = viewModel;
            viewModel.HelpFrameVisibleChanged += Help.ShowHide;
            Help.Initialize(viewModel);
            Help.HelpShowingEnded += viewModel.OnHelpShovingEnded;
            viewModel.AnswerPushed += OnRunAnimation;

            _timer = new Timer {Interval = 700};
            _timer.Elapsed += TimerOnElapsed;
        }

        private void OnRunAnimation(object sender, bool answer)
        {
            _isLastAnswerTrue = answer;
            _timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (_currentFlash == _flashCount)
                {
                    _timer.Stop();
                    _currentFlash = 0;

                    Button1.Foreground = Brushes.White;
                    Button2.Foreground = Brushes.White;
                    Button3.Foreground = Brushes.White;
                    Button4.Foreground = Brushes.White;

                    Button1.FontSize = 32;
                    Button2.FontSize = 32;
                    Button3.FontSize = 32;
                    Button4.FontSize = 32;

                    Button1.FontWeight = FontWeights.Normal;
                    Button2.FontWeight = FontWeights.Normal;
                    Button3.FontWeight = FontWeights.Normal;
                    Button4.FontWeight = FontWeights.Normal;

                    _viewModel.Next();
                    return;
                }

                if (_currentFlash % 2 == 0)
                {
                    if (_isLastAnswerTrue)
                    {
                        if (_viewModel.SelectedAnswerIndexes[0])
                        {
                            Button1.Foreground = Brushes.Green;
                            Button1.FontSize = 48;
                            Button1.FontWeight = FontWeights.Bold;
                        }

                        if (_viewModel.SelectedAnswerIndexes[1])
                        {
                            Button2.Foreground = Brushes.Green;
                            Button2.FontSize = 48;
                            Button2.FontWeight = FontWeights.Bold;
                        }

                        if (_viewModel.SelectedAnswerIndexes[2])
                        {
                            Button3.Foreground = Brushes.Green;
                            Button3.FontSize = 48;
                            Button3.FontWeight = FontWeights.Bold;
                        }

                        if (_viewModel.SelectedAnswerIndexes[3])
                        {
                            Button4.Foreground = Brushes.Green;
                            Button4.FontSize = 48;
                            Button4.FontWeight = FontWeights.Bold;
                        }
                    }
                    else
                    {
                        if (_viewModel.SelectedAnswerIndexes[0])
                        {
                            Button1.Foreground = Brushes.Red;
                            Button1.FontSize = 48;
                            Button1.FontWeight = FontWeights.Bold;
                        }

                        if (_viewModel.SelectedAnswerIndexes[1])
                        {
                            Button2.Foreground = Brushes.Red;
                            Button2.FontSize = 48;
                            Button2.FontWeight = FontWeights.Bold;
                        }

                        if (_viewModel.SelectedAnswerIndexes[2])
                        {
                            Button3.Foreground = Brushes.Red;
                            Button3.FontSize = 48;
                            Button3.FontWeight = FontWeights.Bold;
                        }

                        if (_viewModel.SelectedAnswerIndexes[3])
                        {
                            Button4.Foreground = Brushes.Red;
                            Button4.FontSize = 48;
                            Button4.FontWeight = FontWeights.Bold;
                        }
                    }
                }
                else
                {
                    Button1.Foreground = Brushes.White;
                    Button2.Foreground = Brushes.White;
                    Button3.Foreground = Brushes.White;
                    Button4.Foreground = Brushes.White;

                    Button1.FontSize = 32;
                    Button2.FontSize = 32;
                    Button3.FontSize = 32;
                    Button4.FontSize = 32;

                    Button1.FontWeight = FontWeights.Normal;
                    Button2.FontWeight = FontWeights.Normal;
                    Button3.FontWeight = FontWeights.Normal;
                    Button4.FontWeight = FontWeights.Normal;
                }
            });
            _currentFlash++;
        }
    }
}
