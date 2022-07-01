using EstateAgency.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstateAgency.App
{
    internal class EstateAgencyClient
    {
        internal void ListAllUnits()
        {
            Console.WriteLine("==== Customers List ====");
            //var customers = _client.GetAllCustomersAsync().Result;
            IList<object> list = new List<object>();
            ConsoleHelpers.PrintTable(list, ConsoleUtils.unitColumns, "Units List");
        }
    }
}
