using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingTimeConverterConsole
{
    public class MenuHelperClass
    {
        public static int MultipleChoice(bool canCancel, params string[] options)
        {
            // Extra Settings to control where the menu will be build and how.
            const int startX = 15;
            const int startY = 8;
            const int optionsPerLine = 1;
            const int spacingPerLine = 14;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();

                // Build the menu
                for (int i = 0; i < options.Length; i++)
                {
                    // Set the current to the position and write the option there.
                    // Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    // If text is selected then make it red.
                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($">{options[i]}<");
                    }
                    else
                    {
                        // Write each option on a new line.
                        Console.WriteLine(options[i]);
                    }
                    // Resets the ConsoleColor to default.
                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                // Get key actions.
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            // When current Selection is higher or equal the max options in each line, then go one down. Otherwise go back to the end.
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            else
                                currentSelection = options.Length - 1;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            // When current Selection plus the max options in each line, are lower than the given options, then go one down. Otherwise go back to the beginning.
                            if (currentSelection + optionsPerLine < options.Length)
                                currentSelection += optionsPerLine;
                            else
                                currentSelection = 0;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            // If user can cancel throw -1 as result.
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }
    }
}
