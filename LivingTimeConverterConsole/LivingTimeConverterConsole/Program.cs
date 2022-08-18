namespace LivingTimeConverterConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the LivingTimeConverter. This is a lightweight fun tool to convert youre whole living time in any format you wish. \n" +
                "As an Example, you can convert youre living time into years, seconds, months, days and so on... \nSo lets get started!\nNow enter youre Birth-Date:");
            EnterBirthDate:
            string birthDateInput = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(birthDateInput) || !DateTime.TryParse(birthDateInput, out DateTime birthDate))
            {
                Console.WriteLine("Invalid Date Format. Please try again.");
                goto EnterBirthDate;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Alright youre BirthDate is now: {birthDate} Now select one of the Converting options: ");
                Thread.Sleep(1500);
                Menu:
                int selectedClass = MenuHelperClass.MultipleChoice(true, "To Seconds", "To Minutes", "To Hours", "To Days", "To Months", "To Years");
                if (selectedClass == 0)
                {
                    Console.WriteLine(ToSeconds(birthDate));
                    Console.ReadKey();
                    goto Menu;
                }
                else if (selectedClass == 1)
                {
                    Console.WriteLine(ToMinutes(birthDate));
                    Console.ReadKey();
                    goto Menu;
                }
                else if (selectedClass == 2)
                {
                    Console.WriteLine(ToHours(birthDate));
                    Console.ReadKey();
                    goto Menu;
                }
                else if (selectedClass == 3)
                {
                    Console.WriteLine(ToDays(birthDate));
                    Console.ReadKey();
                    goto Menu;
                }
                else if (selectedClass == 4)
                {
                    Console.WriteLine(ToMonths(birthDate));
                    Console.ReadKey();
                    goto Menu;
                }
                else if (selectedClass == 5)
                {
                    Console.WriteLine(ToYears(birthDate));
                    Console.ReadKey();
                    goto Menu;
                }
            }
        }
        
        private static string ToSeconds(DateTime dateTime)
        {
            // Get the seconds betweend the given date and the current date.
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