using System;
using System.Windows.Controls;
using System.Windows.Input;
using HistoryTestsApp.ViewModels;

namespace HistoryTestsApp.UserControls
{
    /// <summary>
    /// Interaction logic for DialogControl.xaml
    /// </summary>
    public partial class DialogControl : UserControl
    {
        private readonly DialogViewModel _viewModel;
        private int _index;
        public event EventHandler DialogEnd; 

        public DialogControl(DialogViewModel dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
            _viewModel = dataContext;

            NovelTextBox.PushMessage(_viewModel.AnimeText[_index]);
            _index++;
        }

        private void DialogControl_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (NovelTextBox.IsPushed)
            {
                NovelTextBox.PushMessageImmidiatly(_viewModel.AnimeText[_index - 1]);
                return;
            }

            if (_viewModel.AnimeText.Count <= _index)
            {
                DialogEnd?.Invoke(this, null);
                return;
            }

            NovelTextBox.PushMessage(_viewModel.AnimeText[_index]);
            _index++;
        }
    }
}
