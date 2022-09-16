using System.Globalization;
using System.Timers;
using Timer = System.Timers.Timer;

namespace LivingTimeConverterConsole;

internal class Program
{
    private static readonly Timer _sTimer = new();
    private static DateTime birthDate;

    private static void Main(string[] args)
    {
        Console.WriteLine(
            "Welcome to the LivingTimeConverter. This is a lightweight fun tool to convert youre whole living time in any format you wish.\n" +
            "As an Example, you can convert your living time into years, seconds, months, days and so on...\n" +
            "So lets get started!");

        EnterBirthDate:
        Console.WriteLine("Please enter your birthdate:");
        var birthDateInput = Console.ReadLine() ?? "";
        // Checking if the entered Birthdate is valid and matches the format.
        var dateFormats = new[] { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy", "dd MM yyyy", "ddMMyyyy" };
        if (!DateTime.TryParseExact(birthDateInput, dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None,
                out birthDate))
        {
            Console.Clear();
            Console.WriteLine("Invalid Date Format. Please try again and use one of these formats: dd.MM.yyyy, dd-MM-yyyy, dd/MM/yyyy, dd MM yyyy, ddMMyyyy\n");
            goto EnterBirthDate;
        }
        // Check if the birthday is in the future
        if (birthDate > DateTime.Now)
        {
            Console.Clear();
            Console.WriteLine("Your birthday cannot be in the future!\n");
            goto EnterBirthDate;
        }

        // Create a timer that will refresh the output every 5 seconds.
        _sTimer.Interval = 5000;
        _sTimer.AutoReset = true;
        _sTimer.Elapsed += TimerElapsed;
        TimerElapsed(null, null);
        _sTimer.Start();

        // Program will run until the user presses the "ESCAPE" key or when pressing "ENTER" key program will be return to EnterBirthDate.
        var key = ConsoleKey.NoName;
        while (key != ConsoleKey.Escape)
        {
            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                _sTimer.Stop();
                goto EnterBirthDate;
            }
        }
    }

    private static void TimerElapsed(object? sender, ElapsedEventArgs e)
    {
        // Converting the BirthDate into different formats.
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
        Console.WriteLine("Refreshing every 5 seconds. Press ENTER to enter another Birthdate or press ESCAPE to exit.");
    }
}