using System;
using System.Collections.Generic;
using System.Text;

namespace EstateAgency.Core.Models
{
    public class Owner
    {
        public int Codice { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public IList<Unit> Units { get; set; }
    }
}
