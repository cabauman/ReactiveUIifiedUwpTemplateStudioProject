using ReactiveUI;
using Splat;

using Windows.UI.Xaml.Controls;

namespace ReactiveUIifiedUwpTemplateStudioProject
{
    public sealed partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Locator.Current.GetService(typeof(IScreen));
        }
    }
}
