using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace HistoryTestsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            FrameContentController.Instance.ChangeFrameContent += OnFrameContentChange;
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        private void Initialize()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\" + Options.QuestionsFolderName))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\" + Options.QuestionsFolderName);
        }

        private void OnFrameContentChange(object sender, UserControl userControl)
        {
            Content.Children.Clear();
            Content.Children.Add(userControl);
        } 

        //private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        //{
        //    NovelTextBox.PushMessage(InputText.Text);
        //}

        //private void OnSetTextInterval(object sender, RoutedEventArgs e)
        //{
        //    var interval = double.Parse(TextInterval.Text);
        //    NovelTextBox.OutputInterval = interval;
        //}
    }
}
