using System;
using System.Collections.Generic;
using System.Text;


namespace EstateAgency.App.Data
{
    public class Unit
    {
        public int Codice { get; set; }

        public short Superficie { get; set; }

        public byte NumVani { get; set; }
        public short AnnoFab { get; set; }
        public decimal Prezzo { get; set; }
        
        public int OwnerId { get; set; }
        
        public DateTime DataIns { get; set; }
        public int Status { get; set; }
        public int Tipo { get; set; }
    }
}
