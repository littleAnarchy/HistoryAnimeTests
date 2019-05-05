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
    /// Interaction logic for FinalControl.xaml
    /// </summary>
    public partial class FinalControl : UserControl
    {
        public FinalControl(int score)
        {
            InitializeComponent();

            if (score <= 1)
            {
                Titul.Content = "Вітаємо, ви Лох!";
                Comment.Content = "Вражені вашою невдачею.";
                TitulPhoto.Source = new BitmapImage(new Uri(@"../Resources/57cd9850-9a76-4ba5-8f0b-8f6ece9742fe.png", UriKind.Relative));
            }
            else if (score <= 3)
            {
                Titul.Content = "Вітаємо, ви Майже лох!";
                Comment.Content = "Ну, по крайній мірі, ти старався.";
                TitulPhoto.Source = new BitmapImage(new Uri(@"../Resources/c0cf9c50-e1ea-4dbc-a552-3dbbd202f85f.png", UriKind.Relative));
            }
            else if (score <= 6)
            {
                Titul.Content = "Вітаємо, ви Чайник!";
                Comment.Content = "Ти більш-менш знаєш історію, але дещо все ж варто підівчити.";
                TitulPhoto.Source = new BitmapImage(new Uri(@"../Resources/79f08ded-e54e-4956-b829-4fa39d27fb7b.png", UriKind.Relative));
            }
            else if (score <= 9)
            {
                Titul.Content = "Вітаємо, ви Вор в законі!";
                Comment.Content = "Ти дуже добре знаєш історію і взагалі крутий чувак. Так тримати!";
                TitulPhoto.Source = new BitmapImage(new Uri(@"../Resources/b573672e-37d0-46fa-b7c3-eb2a2bc4855e.png", UriKind.Relative));
            }
            else if (score == 10)
            {
                Titul.Content = "Вітаємо, ви БОГ!";
                Comment.Content = "Молодець. Ти ідеально відповів на всі запитання. Навіть добавити нічого!";
                TitulPhoto.Source = new BitmapImage(new Uri(@"../Resources/722cb2a6-7da3-484a-a95b-16127d2e57cf.png", UriKind.Relative));
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
