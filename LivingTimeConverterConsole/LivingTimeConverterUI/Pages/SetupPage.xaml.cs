using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace LivingTimeConverterUI.Pages
{
    public partial class SetupPage : Page
    {
        public SetupPage()
        {
            InitializeComponent();
            BirthdayBox.Focus();
        }

        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            var dateFormats = new[] { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy", "dd MM yyyy", "ddMMyyyy" };
            if (DateTime.TryParseExact(BirthdayBox.Text, dateFormats, DateTimeFormatInfo.InvariantInfo,
                    DateTimeStyles.None,
                    out var birthday))
            {
                // Check if the birthday is in the future
                if (birthday > DateTime.Now)
                {
                    MessageBox.Show("Your birthday cannot be in the future!", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                NavigationService?.Navigate(new ResultPage(birthday));
            }
            else
            {
                MessageBox.Show(
                    "Invalid Date Format. Please try again and use one of these formats: dd.MM.yyyy, dd-MM-yyyy, dd/MM/yyyy, dd MM yyyy, ddMMyyyy");
            }
        }
    }
}