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
        /// availability dates- false for available
        /// unit's type
        /// unit's area
        /// </summary>
        public int HostingUnitKey { set; get; }
        public Host Owner { private set; get; }
        public string OwnerName { private set; get; }
        public bool[,] Calendar { private set; get; } = new bool[12, 31];
        public HostingUnitTypes UnitType { private set; get; } = HostingUnitTypes.other;
        public AreaTypes UnitAreaType { private set; get; } = AreaTypes.other;

        public bool Available(DateTime start, int len) 
        {
            bool available = true;
            DateTime end = start.AddDays(len);
            for (DateTime d=start; d < end; d=d.AddDays(1))
            {
                if(Calendar[d.Month,d.Day])
                {
                    available = false;
                    break;
                }
            }
            return available;
        }

        public override string ToString()
        {
            string hostingUnit = "";

            //ToDo

            return hostingUnit;
        }
    }
}
