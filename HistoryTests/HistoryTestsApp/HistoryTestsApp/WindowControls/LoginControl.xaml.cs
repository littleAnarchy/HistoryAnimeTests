using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HistoryTestsApp.ViewModels;

namespace HistoryTestsApp.WindowControls
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        private LoginViewModel _viewModel;

        public LoginControl()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
            _viewModel.LoginFinished += OnLoginFinished;
            DataContext = _viewModel;
        }

        private void OnLoginFinished(object sender, EventArgs args)
        {
            FrameContentController.Instance.SetMainWindowFrameContent(new MainMenuControl());
        }
    }
}
