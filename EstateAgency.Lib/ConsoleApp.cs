using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EstateAgency.Lib;

namespace EstateAgency.Lib
{
    public delegate void MenuAction();
    public class ConsoleApp
    {
        public string Title { get; }
        private IList<ConsoleMenuItem> MenuItems { get; }

        public ConsoleApp(string title, bool addDefaultItems = true)
        {
            Title = title;
            MenuItems = new List<ConsoleMenuItem>();
            if (addDefaultItems)
            {
                MenuItems.Add(new ConsoleMenuItem("H", "Help", () =>
                 {
                     Console.WriteLine();
                     foreach(var item in MenuItems.OrderBy(x => x.Order))
                     {
                         Console.WriteLine($"\t{item.Display}\t");
                     }
                     Console.WriteLine();

                 }, 1000));
                MenuItems.Add(new ConsoleMenuItem("Q", "Quit", () =>
                 {
                     Console.WriteLine($"Closing {Title}...");
                     Thread.Sleep(1000);
                     Environment.Exit(0);
                 }, 1001));
            }
        }

        public void AddMenuItem(string code, string description, MenuAction action, int order = 0)
        {
            MenuItems.Add(new ConsoleMenuItem(code, description, action, order));
        }
        public void PrintWelcome()
        {
            int size = 50;
            Console.WriteLine(new String('_', size));
            int padding = (size - Title.Length) / 2;
            Console.WriteLine(Title.PadLeft(size - padding).PadRight(size));
            Console.WriteLine(new String('_', size));

        }

        public void Run()
        {
            PrintWelcome();
            PrintHelp();
            while (true)
            {
                Console.Write("\nScegliere un'opzione:\t");
                string option = Console.ReadLine() ?? string.Empty;
                var item = MenuItems.FirstOrDefault(x => x.Code.Equals(option, StringComparison.InvariantCultureIgnoreCase));
                if(item != null)
                {
                    Console.WriteLine(item.Description);
                    item.Action();
                }
                else
                {
                    Console.WriteLine("Scelta non valida. Riprovare");
                }

            }
        }
        private void PrintHelp()
        {
            var helpItem = MenuItems.FirstOrDefault(x => x.Code.Equals("H", StringComparison.InvariantCultureIgnoreCase));
            if(helpItem != null)
            {
                helpItem.Action();
            }
        }
    }

    public class ConsoleMenuItem
    {
        public string Code { get; }
        public string Description { get; }
        public int Order { get; set; }
        public MenuAction Action { get; }
        public ConsoleMenuItem(string code, string description, MenuAction action, int order)
        {
            Code = code;
            Description = description;
            Action = action;
            Order = order;
        }
        public ConsoleMenuItem(string code, string description, MenuAction action) : this(code, description, action, 0)
        {

        }
        

        public string Display => $"[ {Code} ] - {Description}";
    }
}
