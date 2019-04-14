using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HistoryTestsApp
{
    public class FrameContentController
    {
        public event EventHandler<UserControl> ChangeFrameContent;

        private static FrameContentController _instance;

        public static FrameContentController Instance => _instance ?? (_instance = new FrameContentController());

        private FrameContentController() {}

        public void SetMainWindowFrameContent(UserControl userControl)
        {
            ChangeFrameContent?.Invoke(this, userControl);
        }
    }
}
