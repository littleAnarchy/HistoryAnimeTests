using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryTestsApp
{
    public class PlayerController
    {
        private static PlayerController _instance;
        public static PlayerController Instance
        {
            get { return _instance ?? (_instance = new PlayerController()); }
        }

        public string PlayerName = "User";

        private PlayerController()
        {
        }
    }
}
