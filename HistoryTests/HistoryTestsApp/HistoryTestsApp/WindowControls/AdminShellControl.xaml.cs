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
    /// Interaction logic for AdminShellControl.xaml
    /// </summary>
    public partial class AdminShellControl : UserControl
    {
        public AdminShellControl()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Subject1.Content = new AdminControl(SubjectType.Subject1);
            Subject2.Content = new AdminControl(SubjectType.Subject2);
            Subject3.Content = new AdminControl(SubjectType.Subject3);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            FrameContentController.Instance.SetMainWindowFrameContent(new MainMenuControl());
        }
    }
}
