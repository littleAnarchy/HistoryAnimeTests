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

namespace HistoryTestsApp.WindowControls
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : UserControl
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void OnStart(object sender, EventArgs args)
        {
            FrameContentController.Instance.SetMainWindowFrameContent(new LoginControl());
        }
    }
}
