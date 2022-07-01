using System;
using System.Collections.Generic;
using System.Text;

namespace EstateAgency.Core.Models
{
    public class Unit
    {
        public int Codice { get; set; }

        public short Superficie { get; set; }

        public byte NumVani { get; set; }
        public short AnnoFab { get; set; }
        public decimal Prezzo { get; set; }
        
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        
        public DateTime DataIns { get; set; }
        public UnitStatus Status { get; set; }

        public UnitType Tipo { get; set; }

    }
}
