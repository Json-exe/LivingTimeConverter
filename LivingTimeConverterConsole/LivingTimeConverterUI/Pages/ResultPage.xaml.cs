using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace LivingTimeConverterUI.Pages
{
    public partial class ResultPage : Page
    {
        
        DispatcherTimer timer = new DispatcherTimer();


        public static readonly DependencyProperty AgeInSecondsProperty = DependencyProperty.Register(
            nameof(AgeInSeconds), typeof(string), typeof(ResultPage), new PropertyMetadata(default(string)));

        public string AgeInSeconds
        {
            get { return (string)GetValue(AgeInSecondsProperty); }
            set { SetValue(AgeInSecondsProperty, value); }
        }

        public static readonly DependencyProperty AgeInMinutesProperty = DependencyProperty.Register(
            nameof(AgeInMinutes), typeof(string), typeof(ResultPage), new PropertyMetadata(default(string)));

        public string AgeInMinutes
        {
            get { return (string)GetValue(AgeInMinutesProperty); }
            set { SetValue(AgeInMinutesProperty, value); }
        }

        public static readonly DependencyProperty AgeInHoursProperty = DependencyProperty.Register(
            nameof(AgeInHours), typeof(string), typeof(ResultPage), new PropertyMetadata(default(string)));

        public string AgeInHours
        {
            get { return (string)GetValue(AgeInHoursProperty); }
            set { SetValue(AgeInHoursProperty, value); }
        }

        public static readonly DependencyProperty AgeInDaysProperty = DependencyProperty.Register(
            nameof(AgeInDays), typeof(string), typeof(ResultPage), new PropertyMetadata(default(string)));

        public string AgeInDays
        {
            get { return (string)GetValue(AgeInDaysProperty); }
            set { SetValue(AgeInDaysProperty, value); }
        }

        public static readonly DependencyProperty AgeInWeeksProperty = DependencyProperty.Register(
            nameof(AgeInWeeks), typeof(string), typeof(ResultPage), new PropertyMetadata(default(string)));

        public string AgeInWeeks
        {
            get { return (string)GetValue(AgeInWeeksProperty); }
            set { SetValue(AgeInWeeksProperty, value); }
        }

        public static readonly DependencyProperty AgeInMonthsProperty = DependencyProperty.Register(
            nameof(AgeInMonths), typeof(string), typeof(ResultPage), new PropertyMetadata(default(string)));

        public string AgeInMonths
        {
            get { return (string)GetValue(AgeInMonthsProperty); }
            set { SetValue(AgeInMonthsProperty, value); }
        }

        public static readonly DependencyProperty AgeInYearsProperty = DependencyProperty.Register(
            nameof(AgeInYears), typeof(string), typeof(ResultPage), new PropertyMetadata(default(string)));

        public string AgeInYears
        {
            get { return (string)GetValue(AgeInYearsProperty); }
            set { SetValue(AgeInYearsProperty, value); }
        }

        public static readonly DependencyProperty TimeLeftProperty = DependencyProperty.Register(
            nameof(TimeLeft), typeof(int), typeof(ResultPage), new PropertyMetadata(2));

        public int TimeLeft
        {
            get { return (int)GetValue(TimeLeftProperty); }
            set { SetValue(TimeLeftProperty, value); }
        }
        
        private int _timeLeft = 5;
        private DateTime _birthDate;
        
        public ResultPage(DateTime validBirthday)
        {
            InitializeComponent();
            _birthDate = validBirthday;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerOnTick;
            timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            _timeLeft--;
            if (_timeLeft == 0)
            {
                _timeLeft = 5;
                // ReConvert DateTime
                AgeInSeconds = ToSeconds(_birthDate);
                AgeInMinutes = ToMinutes(_birthDate);
                AgeInHours = ToHours(_birthDate);
                AgeInDays = ToDays(_birthDate);
                AgeInWeeks = ToWeeks(_birthDate);
                AgeInMonths = ToMonths(_birthDate);
                AgeInYears = ToYears(_birthDate);
            }
            else
            {
                TimeLeft = _timeLeft;
            }
        }

        // DateTime converter methods.
        
        private static string ToSeconds(DateTime dateTime)
        {
            // Get the seconds between the given date and the current date.
            TimeSpan differenceInSeconds = DateTime.Now - dateTime;
            return differenceInSeconds.TotalSeconds.ToString();
        }

        private static string ToMinutes(DateTime dateTime)
        {
            TimeSpan difference = DateTime.Now - dateTime;
            return difference.TotalMinutes.ToString();
        }

        private static string ToHours(DateTime dateTime)
        {
            TimeSpan difference = DateTime.Now - dateTime;
            return difference.TotalHours.ToString();
        }

        private static string ToDays(DateTime dateTime)
        {
            TimeSpan difference = DateTime.Now - dateTime;
            return difference.TotalDays.ToString();
        }
        
        private static string ToWeeks(DateTime dateTime)
        {
            TimeSpan difference = DateTime.Now - dateTime;
            return (difference.TotalDays / 7).ToString();
        }

        private static string ToMonths(DateTime dateTime)
        {
            int months = (DateTime.Now.Year - dateTime.Year) * 12;
            return months.ToString();
        }

        private static string ToYears(DateTime dateTime)
        {
            // Get years between two dates
            int years = DateTime.Now.Year - dateTime.Year;
            return years.ToString();
        }
    }
}