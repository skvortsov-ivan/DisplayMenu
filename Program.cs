using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisplayMenu;

namespace DisplayMenu
{
    //DOES NOT WELCOME ME?????
    internal class Program
    {
        public static void Main()
        {
            List<string> menuoptions = new List<string>
            {
                "Test1",
                "Test2",
                "Test3",
                "Test4"
            };

            List<string> menuoptions2 = new List<string>
            {
                "Test1",
                "Test2"
            };

            int? result = DisplayAndUseMenu.DisplayandUseMenu(menuoptions, "Welcome to the test1 crazy looooooooooooooong");
            Console.WriteLine($"Selected menu option after finishing code: {result}");
            int? result2 = DisplayAndUseMenu.DisplayandUseMenu(menuoptions2, "Welcome to test2");
            Console.WriteLine($"Selected menu option after finishing code: {result}");
        }
    }
}
