using EstateAgency.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstateAgency.App
{
    internal class ConsoleUtils
    {
        internal readonly static List<ConsoleColumn> unitColumns = new List<ConsoleColumn>
        {
            new ConsoleColumn("Codice", 5),
            new ConsoleColumn("Tipo", 10, ConsoleColumnAlign.Right),
            new ConsoleColumn("Superficie", 10, ConsoleColumnAlign.Right),
            new ConsoleColumn("NumVani", 10, ConsoleColumnAlign.Right),
            new ConsoleColumn("AnnoFab", 10, ConsoleColumnAlign.Right),
            new ConsoleColumn("Prezzo", 8, ConsoleColumnAlign.Right),
            new ConsoleColumn("OwnerId", 20, ConsoleColumnAlign.Right),
            new ConsoleColumn("Status", 10, ConsoleColumnAlign.Right),
            new ConsoleColumn("DataIns", 10, ConsoleColumnAlign.Right)

        };

        internal readonly static List<ConsoleColumn> ownerColumns = new List<ConsoleColumn>
        {
            new ConsoleColumn("Codice",5),
            new ConsoleColumn("Nome",20, ConsoleColumnAlign.Right),
            new ConsoleColumn("Cognome",20, ConsoleColumnAlign.Right)
        };
    }
}
