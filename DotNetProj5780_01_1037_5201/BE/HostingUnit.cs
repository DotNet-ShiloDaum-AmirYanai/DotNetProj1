using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    [Serializable]
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

        public Host Owner {  set; get; }
        public string OwnerName {  set; get; }
        public bool[,] Calendar {  set; get; } = new bool[12, 31];
        public HostingUnitTypes UnitType {  set; get; } = HostingUnitTypes.other;
        public AreaTypes UnitAreaType {  set; get; } = AreaTypes.other;


        public override string ToString()
        {
            string hostingUnit = "";

            hostingUnit += "Key:" + HostingUnitKey.ToString();

            hostingUnit += "Owner:" + Owner.ToString();

            return hostingUnit;
        }



    }
}
