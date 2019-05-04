using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace HistoryTestsApp.ViewModels
{
    public class LoginViewModel : ReactiveObject
    {
        [Reactive]
        public string NickName { get; set; }

        public event EventHandler LoginFinished;

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new CommandHandler(o => true, OnLogin);
        }

        private void OnLogin(object state)
        {
            if (string.IsNullOrEmpty(NickName))
            {
                MessageBox.Show("Будь ласка, введіть ім'я");
                return;
            }

            PlayerController.Instance.PlayerName = NickName;
            LoginFinished?.Invoke(this, null);
        }
    }
}
