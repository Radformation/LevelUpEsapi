using System.Windows;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public MainViewModel ViewModel => (MainViewModel)DataContext;

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Initialize();
        }
    }
}
