using System;
using System.Windows;
using System.Windows.Controls;
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
        }

        private void OnDialogEnd(object sender, EventArgs args)
        {
            Layout.Children.Clear();
            _gameViewModel = new GameViewModel(_type);
            _gameViewModel.GameEnded += OnGameEnded;
            Layout.Children.Add(new GameIntarfaceControl(_gameViewModel));

            MainGrid.RowDefinitions[0].Height = new GridLength(0.5, GridUnitType.Star);
            MainGrid.RowDefinitions[1].Height = new GridLength(0.5, GridUnitType.Star);
        }

        private void OnGameEnded(object sender, int score)
        {
            FrameContentController.Instance.SetMainWindowFrameContent(new FinalControl());
        }
    }
}
