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
        }

        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(BirthdayBox.Text))
            {
                MessageBox.Show("Please enter your birthday");
            }
            else if (DateTime.TryParse(BirthdayBox.Text, out DateTime birthday))
            {
                if (birthday > DateTime.Now)
                {
                    MessageBox.Show("Please enter a valid birthday");
                }
                else
                {
                    NavigationService?.Navigate(new ResultPage(birthday));
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid birthday");
                return;
            }
        }
    }
}