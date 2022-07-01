using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstateAgency.Lib;

namespace EstateAgency.Lib
{
    public static class ConsoleHelpers
    {
        public static string GetData(string message)
        {
            Console.Write(message + ": ");
            var value = Console.ReadLine();
            return value;
        }

        public static string GetData(string message, string initialValue)
        {
            Console.Write(message + $" ({initialValue}): ");
            var value = Console.ReadLine();
            return string.IsNullOrEmpty(value) ? initialValue : value;
        }

        public static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void PrintRow(int size)
        {
            Console.WriteLine(new string('_', size));
        }
        public static void InfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void Exception(Exception exc, string message = "Errore")
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string text = !string.IsNullOrEmpty(message) ? $"{message}: {exc.Message}" : exc.Message;
            Console.WriteLine(text);
            if(exc.InnerException != null)
                ConsoleHelpers.Exception(exc.InnerException, message);
            Console.ResetColor();
        }

        public static void PrintTextInRow(string text, int rowSize, char paddingCharacter = '\0')
        {
            text = $"   {text}   ";
            int padding = (rowSize - text.Length) / 2;
            Console.WriteLine(text.PadLeft(rowSize - padding, paddingCharacter).PadRight(rowSize, paddingCharacter));
        }

        public static void PrintTable(IEnumerable<object> data, IEnumerable<ConsoleColumn> columns, string title = null)
        {
            int size = columns.Sum(x => Math.Abs(x.Size));
            if (!string.IsNullOrEmpty(title))
            {
                PrintRow(size);
                Console.WriteLine(title);
                PrintRow(size);
            }

            var patterns = columns
                .Select((c, i) =>
                {
                    string index = i.ToString();
                    string sizeAlign = c.Size.ToString();
                    if (c.Alignment == ConsoleColumnAlign.Left)
                        sizeAlign = "-" + sizeAlign;
                    return "{" + index + "," + sizeAlign + "}";

                });
            string pattern = string.Join("", patterns);
            Console.WriteLine(pattern, columns.Select(x => x.Name).ToArray());
            foreach (object item in data)
            {
                IList<string> p = new List<string>();
                var properties = item.GetType().GetProperties();
                for (int i = 0; i < columns.Count(); i++)
                {
                    var prop = properties.FirstOrDefault(x => x.Name == columns.ElementAt(i).Name).GetValue(item, null);
                    p.Add(prop.ToString());
                }
                Console.WriteLine(pattern, p.ToArray());
            }
        }
    }
}
