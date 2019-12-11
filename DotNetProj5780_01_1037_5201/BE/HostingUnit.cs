using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class HostingUnit
    {
        /// <summary>
        /// key of hosting unit
        /// the owner
        /// owner's name
        /// availability dates
        /// unit's type
        /// unit's area
        /// </summary>
        public int HostingUnitKey { private set; get; }
        public Host Owner { private set; get; }
        public string OwnerName { private set; get; }
        public bool[,] Calendar { private set; get; } = new bool[12, 31];

        public HostingUnitTypes UnitType { private set; get; } = HostingUnitTypes.other;
        public AreaTypes UnitAreaType { private set; get; } = AreaTypes.other;


        public override string ToString()
        {
            string hostingUnit = "";

            //ToDo

            return hostingUnit;
        }
    }
}
