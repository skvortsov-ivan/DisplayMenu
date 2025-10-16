using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DisplayMenu
{
    public class DisplayAndUseMenu
    {
        public static int? DisplayandUseMenu(List<string> menuOptions, string welcomeText)
        {
            //Clear console
            Console.Clear();

            //Default selectedMenuOption is null for error handling
            int? selectedMenuOption = null;

            //Loop until user made a correct choice
            while(selectedMenuOption == null)
            {
                //Error handling:
                if(ValidateUserInput(menuOptions, welcomeText) != true)
                {
                    return selectedMenuOption;
                }

                //Welcome text
                PositionWelcomeTextAndDeviders(welcomeText);

                //Explaining how to navigate to user
                Console.WriteLine("\nUse arrowkeys to navigate. Press Enter to select.\n");

                //Allowing user to access menu
                selectedMenuOption = MenuChoice(menuOptions);
            }
            //Returning selected menu option
            return selectedMenuOption;
        }

        public static int MenuChoice(List<string> menuOptions)
        {
            return MenuInput(menuOptions);
        }

        public static int MenuInput(List<string> menuOptions)
        {
            int currentIndex = 0;
            int menuStartRow = Console.CursorTop;

            while (true)
            {
                ClearMenuArea(menuStartRow, menuOptions.Count);
                Console.SetCursorPosition(0, menuStartRow);
                HighlightCurrectChoice(menuOptions, currentIndex);
                ConsoleKeyInfo key = Console.ReadKey(true);
                
                // Move selection up
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (currentIndex > 0)
                    {
                        currentIndex--;
                    }
                }
                // Move selection down
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (currentIndex < menuOptions.Count)
                    {
                        currentIndex++;
                    }
                }
                // Select current option
                else if (key.Key == ConsoleKey.Enter)
                {
                    return currentIndex;
                }
                continue;

            }
        }

        public static void HighlightCurrectChoice(List<string> menuOptions, int selectedIndex)
        {
            for (int i = 0; i < menuOptions.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.ResetColor();
                }

                //Display menu options and highlight current choice
                if (i == menuOptions.Count - 1)
                {
                    Console.WriteLine($"[{0}]: {menuOptions[i]}");
                }
                else
                {
                    Console.WriteLine($"[{i + 1}]: {menuOptions[i]}");
                }
            }

            Console.ResetColor();
        }

        public static void PositionWelcomeTextAndDeviders(string welcomeText)
        {
            //Calculating padding for the welcome text and applying it
            int leftPadding = (Console.WindowWidth - welcomeText.Length) / 6;
            string paddedText = welcomeText.PadLeft(leftPadding + welcomeText.Length);

            //Default devider length
            int defaultDividerLength = 49;

            //Devider length
            int dividerLength;

            //Threshhold for default divider length
            int defaultDividerLengthThreshhold = 35;

            //Scaling divider if the welcome text exceeds default length
            if (paddedText.Length > defaultDividerLengthThreshhold)
            {
                int threshholdDifference = paddedText.Length - defaultDividerLengthThreshhold;
                dividerLength = defaultDividerLength + threshholdDifference;
            }
            else
            {
                dividerLength = defaultDividerLength;
            }
            
            //Divider string
            string divider = new string('=', dividerLength);

            //Print welcome text and dividers
            Console.WriteLine("\n" + divider);
            Console.WriteLine(paddedText);
            Console.WriteLine(divider);
        }

        public static bool ValidateUserInput(List<string> menuOptions, string welcomeText)
        {
            //Check if menu options exist or if there are 0 options
            if (menuOptions == null || menuOptions.Count == 0 || menuOptions.GetType() != typeof(List<string>))
            {
                Console.WriteLine("\nThere are no menu options, please include a list of menu options\n");
                return false;
            }

            //Check if a welcome text type and if string is empty
            if (welcomeText == null || welcomeText.GetType() != typeof(string) || string.IsNullOrWhiteSpace(welcomeText))
            {
                Console.WriteLine("\nThere is no welcoming text, please try again\n");
                return false;
            }

            menuOptions.Add("Exit menu");
            //Check if menu is too big
            if (menuOptions.Count > 9)
            {
                Console.WriteLine("\nMaximum allowed menu options are 8, please make it shorter\n");
                return false;
            }

            if (welcomeText.Length > Console.WindowWidth)
            {
                Console.WriteLine("Welcome text is too long, please make it shorter");
                return false;
            }
            return true;
        }

        public static void ClearMenuArea(int startRow, int lineCount)
        {
            for (int i = 0; i < lineCount; i++)
            {
                Console.SetCursorPosition(0, startRow + i);
                Console.Write(new string(' ', Console.WindowWidth));
            }
        }
    }
}
