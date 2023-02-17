using System.Windows;
using LivingTimeConverterUI.Pages;

namespace LivingTimeConverterUI
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new SetupPage());
        }
    }
}