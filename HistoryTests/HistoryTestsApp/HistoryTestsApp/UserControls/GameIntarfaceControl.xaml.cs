using System.Windows.Controls;
using HistoryTestsApp.ViewModels;

namespace HistoryTestsApp.UserControls
{
    /// <summary>
    /// Interaction logic for GameIntarfaceControl.xaml
    /// </summary>
    public partial class GameIntarfaceControl : UserControl
    {
        public GameIntarfaceControl(GameViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
