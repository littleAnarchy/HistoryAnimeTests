using System.Windows;
using System.Windows.Controls;

namespace HistoryTestsApp.WindowControls
{
    /// <summary>
    /// Interaction logic for MainMenuControl.xaml
    /// </summary>
    public partial class MainMenuControl : UserControl
    {
        public MainMenuControl()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            FrameContentController.Instance.SetMainWindowFrameContent(new GameMenuTwoControl());
        }

        private void OnEditButtonClick(object sender, RoutedEventArgs e)
        {
            FrameContentController.Instance.SetMainWindowFrameContent(new AdminShellControl());
        }

        private void OnButtonExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
