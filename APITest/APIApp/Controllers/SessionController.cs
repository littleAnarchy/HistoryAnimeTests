using IntenseLab.Framework;
using IntenseLab.Framework.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIApp.Controllers
{
    public class SessionController
    {
        private static SessionController _instance;

        public IntenseLabSession Session { get; set; }

        public static SessionController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SessionController();
                return _instance;
            }
        }

        private SessionController()
        { }

        public void Initialize()
        {
            Session = new IntenseLabSession(DeviceType.Desktop);
            Session.Initialize(DesktopInitializationStrategy.Default);
        }

        public void Connect(string userName, string password, string domain, int port)
        {
            Task.Run(() => Session.TryConnect(userName, password, domain, port));
        }
    }
}
