
using System.Windows;
using TestTask.My;

namespace TestTask
{
    public partial class InputPanel : Window
    {
        public InputPanel(ApplicationViewModel applicationView)
        {
            InitializeComponent();
            DataContext = applicationView;
        }
    }
}
