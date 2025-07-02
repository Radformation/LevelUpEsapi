using System.Windows;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public partial class NewMetricDialog : Window
    {
        public NewMetricDialog()
        {
            InitializeComponent();
        }

        private void NewMetricDialog_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Make sure the text box is focused when the dialog is shown
            MetricTextBox.Focus();
        }

        private void AddMetricButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
