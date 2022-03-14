using Sample.POO.ApplicationB.ViewModels;
using System.Windows;

namespace Sample.POO.ApplicationB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel vm;

        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;

            this.DataContext = vm;

            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await vm.Init(this.Dispatcher);
        }
    }
}
