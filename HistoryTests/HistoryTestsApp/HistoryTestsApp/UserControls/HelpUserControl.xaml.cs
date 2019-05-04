using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace HistoryTestsApp.UserControls
{
    /// <summary>
    /// Interaction logic for HelpUserControl.xaml
    /// </summary>
    public partial class HelpUserControl : UserControl
    {
        public static readonly DependencyProperty IsShowProperty = DependencyProperty.Register(
            nameof(IsShow), typeof(bool), typeof(HelpUserControl), new PropertyMetadata(true));

        public bool IsShow
        {
            get => (bool)GetValue(IsShowProperty);
            set => SetValue(IsShowProperty, value);
        }

        public HelpUserControl(GameViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
