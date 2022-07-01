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
            app.AddMenuItem("2", "Elenco immobili (tipo)", () => client.ListAllUnitsByType(), 2);
            app.AddMenuItem("3", "Elenco immobili (proprietario)", () => client.ListAllUnitsByOwner(), 3);
            app.AddMenuItem("4", "Elenco proprietari", () => client.ListAllOwners(), 4);

            app.AddMenuItem("6", "Inserimento Immobile", () => client.InsertUnit(), 6);
            app.AddMenuItem("7", "Aggiorna anagrafica proprietario", () => client.UpdateOnwer(), 7);
            app.Run();
        }
    }
}
