using System;
using System.Windows;
using APITestApp.ViewModels;

namespace APITestApp
{
    /// <summary>
    /// Interaction logic for EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {
        private readonly LoginViewModel _dataContext;
        
        public EnterWindow()
        {
            InitializeComponent();
            
            _dataContext = new LoginViewModel();
            _dataContext.LoginFinished += ClickOnQuit;
            DataContext = _dataContext;
        }

        private void ClickOnQuit(object sender, EventArgs e)
        {
            Close();
        }
    }
}
