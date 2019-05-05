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
using HistoryTestsApp.Enums;

namespace HistoryTestsApp.WindowControls
{
    /// <summary>
    /// Interaction logic for GameMenuTwo.xaml
    /// </summary>
    public partial class GameMenuTwoControl : UserControl
    {
        public GameMenuTwoControl()
        {
            InitializeComponent();
        }

        private void OnSubject1Open(object sender, RoutedEventArgs e)
        {
            FrameContentController.Instance.SetMainWindowFrameContent(new GameProcessControl(SubjectType.Subject1));
        }

        private void OnSubject2Open(object sender, RoutedEventArgs e)
        {
            FrameContentController.Instance.SetMainWindowFrameContent(new GameProcessControl(SubjectType.Subject2));
        }
        private void OnSubject3Open(object sender, RoutedEventArgs e)
        {
            FrameContentController.Instance.SetMainWindowFrameContent(new GameProcessControl(SubjectType.Subject3));
        }


        private void OnButtonBackClick(object sender, RoutedEventArgs e)
        {
            FrameContentController.Instance.SetMainWindowFrameContent(new MainMenuControl());
        }
    }
}
