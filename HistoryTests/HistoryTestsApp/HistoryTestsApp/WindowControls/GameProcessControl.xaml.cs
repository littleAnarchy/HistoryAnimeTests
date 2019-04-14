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
            Layout.Children.Add(new GameIntarfaceControl(new GameViewModel(_type)));

            MainGrid.RowDefinitions[0].Height = new GridLength(0.5, GridUnitType.Star);
            MainGrid.RowDefinitions[1].Height = new GridLength(0.5, GridUnitType.Star);
        }
    }
}
