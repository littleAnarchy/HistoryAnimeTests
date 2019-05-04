using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using APIApp;
using APIApp.Controllers;
using IntenseLab.Framework.Messages;

namespace APITestApp.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DomainPort { get; set; }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new CommandHandler((o => true), OnLogin);
            SessionController.Instance.Initialize();
            SessionController.Instance.Session.OnAuthenticationSuccessResponse.Subscribe(OnAuthenticationSuccessResponse);
            SessionController.Instance.Session.OnAuthenticationFailedResponse.Subscribe(OnAuthenticationFailedResponse);
            SessionController.Instance.Session.MarketDataClient.OnServerStateChanged.Subscribe(
                OnCryptoMarketDataClientStateChanged);
        }

        private void OnLogin(object state)
        {
            try
            {
                var domainPort = DomainPort.Split(':');
                var port = int.Parse(domainPort[1]);
                SessionController.Instance.Connect(UserName, Password, domainPort[0], port);

                SessionController.Instance.Session.MarketDataClient.OnServerStateChanged.Subscribe(
                    OnMarketDataClientStateChanged);

                Window window = new MainWindow();
                window.Show();
                
                LoginFinished?.Invoke(this, null);
            }
            catch
            {
                MessageBox.Show("Fill in all the fields, please.");
            }

        }
        //Todo: Все, что ниже, должно быть не в логинокне, а уже в самой апишке, так ведь?
        private void OnMarketDataClientStateChanged(ServerState state)
        {
            if (state == ServerState.Ready)
            {
                //Todo: delete
                SessionController.Instance.Session.MarketDataClient.Events.OnFullOrderBookCache.Subscribe(
                    OnFullOrderBookCache);
                SessionController.Instance.Session.MarketDataClient.SendMarketDataRequest(new MarketDataRequest()
                {
                    Symbol = "AAPL",
                    DataType = SubscriptionDataType.FullOrderBook,
                    SubscriptionAction = SubscriptionAction.AddSubscription
                });
            }

        }

        private void OnFullOrderBookCache(FullOrderBookCache cache)
        {
            MessageBox.Show("onFullOrderBook Cache");
        }

        private void OnAuthenticationSuccessResponse(AuthenticationSuccessResponse response)
        {
            MessageBox.Show(response.ToString());
        }

        private void OnAuthenticationFailedResponse(AuthenticationFailedResponse response)
        {
            MessageBox.Show(response.ToString());
        }

        private void OnCryptoMarketDataClientStateChanged(ServerState state)
        {
            MessageBox.Show($"Crypto Market Client state: {state}");
        }

        public event EventHandler LoginFinished;
    }
}
