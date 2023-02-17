using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace LivingTimeConverterUI.Pages
{
    public partial class ResultPage : Page
    {
        public static readonly DependencyProperty ConverterListProperty = DependencyProperty.Register(
            nameof(ConverterList), typeof(ObservableCollection<ConverterList>), typeof(ResultPage),
            new PropertyMetadata(default(ObservableCollection<ConverterList>)));

        public static readonly DependencyProperty RefreshTimeProperty = DependencyProperty.Register(
            nameof(RefreshTime), typeof(int), typeof(ResultPage), new PropertyMetadata(default(int)));

        private readonly DateTime _birthDate;
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        public ResultPage(DateTime validBirthday)
        {
            InitializeComponent();
            _birthDate = validBirthday;
            Init();
        }

        public ObservableCollection<ConverterList> ConverterList
        {
            get => (ObservableCollection<ConverterList>)GetValue(ConverterListProperty);
            set => SetValue(ConverterListProperty, value);
        }

        public int RefreshTime
        {
            get => (int)GetValue(RefreshTimeProperty);
            set => SetValue(RefreshTimeProperty, value);
        }

        // Method to initialize the page, the timer and the converter list
        private void Init()
        {
            // ReSharper disable once InvalidXmlDocComment
            /// Converter Ids:
            /// 1: ToSeconds
            /// 2: ToMinutes
            /// 3: ToHours
            /// 4: ToDays
            /// 5: ToWeeks
            /// 6: ToMonths
            /// 7: ToYears
            /// 8: ToDecades
            /// 9: ToCenturies
            /// 10: ToMillenniums

            ConverterList = new ObservableCollection<ConverterList>();

            ConverterList.Add(new ConverterList
            {
                ConverterId = 1, Name = "Seconds", Value = DateTime.Now.Subtract(_birthDate).TotalSeconds.ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 2, Name = "Minutes", Value = DateTime.Now.Subtract(_birthDate).TotalMinutes.ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 3, Name = "Hours", Value = DateTime.Now.Subtract(_birthDate).TotalHours.ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 4, Name = "Days", Value = DateTime.Now.Subtract(_birthDate).TotalDays.ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 5, Name = "Weeks", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 7).ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 6, Name = "Months", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 30).ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 7, Name = "Years", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 365).ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 8, Name = "Decades",
                Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 3650).ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 9, Name = "Centuries",
                Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 36500).ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 10, Name = "Millenniums",
                Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 365000).ToString()
            });

            RefreshTime = 5;
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += TimerOnTick;
            _timer.Start();
        }

        // ReCalculate the values every 5 seconds.
        private void TimerOnTick(object sender, EventArgs e)
        {
            RefreshTime--;
            if (RefreshTime != 0) return;
            _timer.Stop();
            ConverterList.Clear();

            ConverterList.Add(new ConverterList
            {
                ConverterId = 1, Name = "Seconds", Value = DateTime.Now.Subtract(_birthDate).TotalSeconds.ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 2, Name = "Minutes", Value = DateTime.Now.Subtract(_birthDate).TotalMinutes.ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 3, Name = "Hours", Value = DateTime.Now.Subtract(_birthDate).TotalHours.ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 4, Name = "Days",
                Value = DateTime.Now.Subtract(_birthDate).TotalDays.ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 5, Name = "Weeks",
                Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 7).ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 6, Name = "Months",
                Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 30).ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 7, Name = "Years",
                Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 365).ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 8, Name = "Decades",
                Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 3650).ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 9, Name = "Centuries",
                Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 36500).ToString()
            });

            ConverterList.Add(new ConverterList
            {
                ConverterId = 10, Name = "Millenniums",
                Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 365000).ToString()
            });
            // Update the UI
            ConverterList = ConverterList;
            _timer.Start();
            RefreshTime = 5;
        }

        // Method to disable the function to select an item in the list.
        private void ConvertList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConverterListUi.SelectedItem = null;
        }

        // Method to let the user scroll when hovering over the list.
        private void ConverterListUi_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
                ScrollViewer.LineDown();
            else
                ScrollViewer.LineUp();
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            ConverterList.Clear();
            NavigationService?.Navigate(new SetupPage());
        }
    }

    // Class to create a list of converters.
    public class ConverterList
    {
        public int ConverterId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}