using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301.UI
{
    public class MainMenu : BaseMenu
    {
        private string _menu;

        private readonly Dictionary<int, string> _options;

        private int _choice = 0;

        public MainMenu(string menu, bool clearScreen = false) 
        {
            if (clearScreen)
                Console.Clear();
            _options = MenuHelper.GetMenuOptions(menu);
            _menu = menu;
        }

        public void Display()
        {
            DisplayMenu();
            DisplayChoice();
        }

        private void DisplayChoice()
        {
            foreach (var option in _options)
            {
                Console.WriteLine("{0}.{1}", option.Key, option.Value);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter your choice ==> (");
            for (int i = 1; i < _options.Count; i++)
                Console.Write("{0}/", i);
            Console.WriteLine("0)");
        }

        private void DisplayMenu()
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("Welcome to Community Library Movie DVD Management System");
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.WriteLine(_menu);
            Console.WriteLine();
        }

        public override void DoWork()
        {
            Display();
            bool valid = false;
            while (!valid)
            {
                if (!int.TryParse(Console.ReadLine(), out _choice))
                {
                    Console.WriteLine("Invalid input, not a number");
                }
                else
                {
                    if (_choice >= 0 && _choice <= _options.Count)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, number is out of range");
                    }
                }
            }
        }

        public override IMenu GetNextMenu()
        {
            return MenuHelper.GetNextMenu(_menu, _choice);
        }
    }
}
