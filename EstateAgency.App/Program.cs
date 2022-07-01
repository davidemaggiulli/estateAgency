using EstateAgency.Lib;
using System;

namespace EstateAgency.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleApp app = new ConsoleApp("Estate Agency");

            var client = new EstateAgencyClient();
            app.AddMenuItem("1", "Elenco immobili", () => client.ListAllUnits() , 1);

            app.Run();
        }
    }
}
