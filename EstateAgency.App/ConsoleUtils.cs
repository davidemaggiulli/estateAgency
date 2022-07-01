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
            new ConsoleColumn("Sup", 5, ConsoleColumnAlign.Right),
            new ConsoleColumn("Vani", 6, ConsoleColumnAlign.Right),
            new ConsoleColumn("Anno.Fab", 6, ConsoleColumnAlign.Right),
            new ConsoleColumn("Prezzo", 8, ConsoleColumnAlign.Right),
            new ConsoleColumn("Proprietario", 20, ConsoleColumnAlign.Right),
            new ConsoleColumn("Stato", 10, ConsoleColumnAlign.Right),
            new ConsoleColumn("Data Inserimento", 10, ConsoleColumnAlign.Right)

        };
    }
}
