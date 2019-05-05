using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using HistoryTestsApp.Enums;
using HistoryTestsApp.UserControls;
using HistoryTestsApp.ViewModels;

namespace HistoryTestsApp.WindowControls
{
    /// <summary>
    /// Interaction logic for GameProcessControl.xaml
    /// </summary>
    public partial class GameProcessControl : UserControl
    {
        private readonly SubjectType _type;
        private GameViewModel _gameViewModel;

        public GameProcessControl(SubjectType type)
        {
            _type = type;
            InitializeComponent();
            var dialogControl = new DialogControl(new DialogViewModel(type));
            dialogControl.DialogEnd += OnDialogEnd;
            Layout.Children.Add(dialogControl);


            switch (type)
            {
                case SubjectType.Subject1:
                    Npc.Source = new BitmapImage(new Uri(@"../Resources/c3609ba5-2733-46be-b1da-84cde7a9c275.png", UriKind.Relative));
                    break;
                case SubjectType.Subject2:
                    Npc.Source = new BitmapImage(new Uri(@"../Resources/a5b20250-03dc-4372-8ffe-574433310769.png", UriKind.Relative));
                    break;
                case SubjectType.Subject3:
                    Npc.Source = new BitmapImage(new Uri(@"../Resources/3a091c7b-9dcc-4494-b7db-a709903689e8.png", UriKind.Relative));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void OnDialogEnd(object sender, EventArgs args)
        {
            Npc.HorizontalAlignment = HorizontalAlignment.Left;

            Layout.Children.Clear();
            _gameViewModel = new GameViewModel(_type);
            _gameViewModel.GameEnded += OnGameEnded;
            Layout.Children.Add(new GameIntarfaceControl(_gameViewModel));

            MainGrid.RowDefinitions[0].Height = new GridLength(0.5, GridUnitType.Star);
            MainGrid.RowDefinitions[1].Height = new GridLength(0.5, GridUnitType.Star);
        }

        private void OnGameEnded(object sender, int score)
        {
            FrameContentController.Instance.SetMainWindowFrameContent(new FinalControl(score));
        }
    }
}
