using System;
using System.Collections.Generic;
using System.Text;
using EstateAgency.Lib;

namespace EstateAgency.Lib
{
    public class ConsoleColumn
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public ConsoleColumnAlign Alignment { get; set; }

        public ConsoleColumn(string name, int size, ConsoleColumnAlign alignment = ConsoleColumnAlign.Left)
        {
            Name = name;
            Size = size;
            Alignment = alignment;
        }
    }

    public enum ConsoleColumnAlign { 
        Left,

        Right
    }

}
