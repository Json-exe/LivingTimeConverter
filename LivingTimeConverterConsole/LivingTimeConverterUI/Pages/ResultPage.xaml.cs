using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace LivingTimeConverterUI.Pages
{
    public partial class ResultPage : Page
    {
        
        DispatcherTimer timer = new DispatcherTimer();

        public static readonly DependencyProperty ConverterListProperty = DependencyProperty.Register(
            nameof(ConverterList), typeof(ObservableCollection<ConverterList>), typeof(ResultPage), new PropertyMetadata(default(ObservableCollection<ConverterList>)));

        public ObservableCollection<ConverterList> ConverterList
        {
            get { return (ObservableCollection<ConverterList>)GetValue(ConverterListProperty); }
            set { SetValue(ConverterListProperty, value); }
        }
        
        private int _timeLeft = 5;
        private readonly DateTime _birthDate;
        
        public ResultPage(DateTime validBirthday)
        {
            InitializeComponent();
            _birthDate = validBirthday;
            Init();
        }

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
            ConverterList.Add(new ConverterList{ ConverterId = 1, Name = "Seconds", Value = DateTime.Now.Subtract(_birthDate).TotalSeconds.ToString()});
            ConverterList.Add(new ConverterList{ ConverterId = 2, Name = "Minutes", Value = DateTime.Now.Subtract(_birthDate).TotalMinutes.ToString()});
            ConverterList.Add(new ConverterList{ ConverterId = 3, Name = "Hours", Value = DateTime.Now.Subtract(_birthDate).TotalHours.ToString()});
            ConverterList.Add(new ConverterList{ ConverterId = 4, Name = "Days", Value = DateTime.Now.Subtract(_birthDate).TotalDays.ToString()});
            ConverterList.Add(new ConverterList{ ConverterId = 5, Name = "Weeks", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 7).ToString()});
            ConverterList.Add(new ConverterList{ ConverterId = 6, Name = "Months", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 30).ToString()});
            ConverterList.Add(new ConverterList{ ConverterId = 7, Name = "Years", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 365).ToString()});
            ConverterList.Add(new ConverterList{ ConverterId = 8, Name = "Decades", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 3650).ToString()});
            ConverterList.Add(new ConverterList{ ConverterId = 9, Name = "Centuries", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 36500).ToString()});
            ConverterList.Add(new ConverterList{ ConverterId = 10, Name = "Millenniums", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 365000).ToString()});

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerOnTick;
            timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            _timeLeft--;
            if (_timeLeft == 0)
            {
                timer.Stop();
                ConverterList.Clear();
                ConverterList.Add(new ConverterList{ ConverterId = 1, Name = "Seconds", Value = DateTime.Now.Subtract(_birthDate).TotalSeconds.ToString()});
                ConverterList.Add(new ConverterList{ ConverterId = 2, Name = "Minutes", Value = DateTime.Now.Subtract(_birthDate).TotalMinutes.ToString()});
                ConverterList.Add(new ConverterList{ ConverterId = 3, Name = "Hours", Value = DateTime.Now.Subtract(_birthDate).TotalHours.ToString()});
                ConverterList.Add(new ConverterList{ ConverterId = 4, Name = "Days", Value = DateTime.Now.Subtract(_birthDate).TotalDays.ToString()});
                ConverterList.Add(new ConverterList{ ConverterId = 5, Name = "Weeks", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 7).ToString()});
                ConverterList.Add(new ConverterList{ ConverterId = 6, Name = "Months", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 30).ToString()});
                ConverterList.Add(new ConverterList{ ConverterId = 7, Name = "Years", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 365).ToString()});
                ConverterList.Add(new ConverterList{ ConverterId = 8, Name = "Decades", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 3650).ToString()});
                ConverterList.Add(new ConverterList{ ConverterId = 9, Name = "Centuries", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 36500).ToString()});
                ConverterList.Add(new ConverterList{ ConverterId = 10, Name = "Millenniums", Value = (DateTime.Now.Subtract(_birthDate).TotalDays / 365000).ToString()});
                // Update the UI
                ConverterList = ConverterList;
                timer.Start();
            }
        }
    }
    
    public class ConverterList
    {
        public int ConverterId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}