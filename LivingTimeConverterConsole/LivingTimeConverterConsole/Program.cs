using System.Globalization;
using System.Timers;
using Timer = System.Timers.Timer;

namespace LivingTimeConverterConsole
{
    internal class Program
    {
        private static Timer _sTimer = new Timer();
        private static DateTime birthDate;

        static void Main(string[] args)
        {
            Console.WriteLine(
                "Welcome to the LivingTimeConverter. This is a lightweight fun tool to convert youre whole living time in any format you wish. \n" +
                "As an Example, you can convert youre living time into years, seconds, months, days and so on... \nSo lets get started!");
            EnterBirthDate:
            Console.WriteLine("Please enter your birthdate:");
            string birthDateInput = Console.ReadLine() ?? "";
            var dateFormats = new[] { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy", "dd MM yyyy", "ddMMyyyy" };
            if (!DateTime.TryParseExact(birthDateInput, dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out birthDate))
            {
                Console.WriteLine(
                    "Invalid Date Format. Please try again and use one of these formats: dd.MM.yyyy, dd-MM-yyyy, dd/MM/yyyy, dd MM yyyy, ddMMyyyy");
                goto EnterBirthDate;
            }

            _sTimer.Interval = 5000;
            _sTimer.AutoReset = true;
            _sTimer.Elapsed += TimerElapsed;
            TimerElapsed(null, null);
            _sTimer.Start();
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                
            }
            _sTimer.Stop();
            Console.Clear();
            goto EnterBirthDate;
        }

        private static void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine($"You have set this as your Birthdate: {birthDate.ToString("dd-MM-yyyy")}. \n");
            Console.WriteLine($"You have lived {DateTime.Now.Subtract(birthDate).TotalSeconds} seconds.");
            Console.WriteLine($"You have lived {DateTime.Now.Subtract(birthDate).TotalMinutes} minutes.");
            Console.WriteLine($"You have lived {DateTime.Now.Subtract(birthDate).TotalHours} hours.");
            Console.WriteLine($"You have lived {DateTime.Now.Subtract(birthDate).TotalDays} days.");
            Console.WriteLine($"You have lived {DateTime.Now.Subtract(birthDate).TotalDays / 7} weeks.");
            Console.WriteLine($"You have lived {DateTime.Now.Subtract(birthDate).TotalDays / 30} months.");
            Console.WriteLine($"You have lived {DateTime.Now.Subtract(birthDate).TotalDays / 365} years.");
            Console.WriteLine($"You have lived {DateTime.Now.Subtract(birthDate).TotalDays / 365 / 100} centuries.");
            Console.WriteLine($"You have lived {DateTime.Now.Subtract(birthDate).TotalDays / 365 / 1000} millenia. \n");
            Console.WriteLine("Refreshing every 5 seconds. Or press Escape to enter another Birthdate.");
        }

        private static string ToSeconds(DateTime dateTime)
        {
            // Get the seconds between the given date and the current date.
            TimeSpan differenceInSeconds = DateTime.Now - dateTime;
            return differenceInSeconds.TotalSeconds.ToString();
        }

        private static string ToMinutes(DateTime dateTime)
        {
            TimeSpan differnece = DateTime.Now - dateTime;
            return differnece.TotalMinutes.ToString();
        }

        private static string ToHours(DateTime dateTime)
        {
            TimeSpan differnece = DateTime.Now - dateTime;
            return differnece.TotalHours.ToString();
        }

        private static string ToDays(DateTime dateTime)
        {
            TimeSpan differnece = DateTime.Now - dateTime;
            return differnece.TotalDays.ToString();
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