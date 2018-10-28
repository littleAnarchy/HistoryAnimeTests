using AdminApp.ViewModels;
using System.Windows;

namespace AdminApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainGrid.DataContext = new MainViewModel();
        }
    }
}
