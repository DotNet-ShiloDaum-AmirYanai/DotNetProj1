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
        public static int RunningHostingUnitKey { set; get; } = 10000000;
        public Host Owner { private set; get; }
        public string OwnerName { private set; get; }
        public bool[,] Calendar { private set; get; } = new bool[12, 31];
        public HostingUnitTypes UnitType { private set; get; } = HostingUnitTypes.other;
        public AreaTypes UnitAreaType { private set; get; } = AreaTypes.other;


        public HostingUnit()
        {
            HostingUnitKey = GetNextKey();
            OwnerName = "John Doe";
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    Calendar[i, j] = false;
                }
            }
        }

        public static int GetNextKey()
        {
            int key = ++RunningHostingUnitKey;
            return key;
        }

        public bool Available(DateTime start, int len) 
        {
            DateTime end = start.AddDays(len);
            return Available(start,end);
        }

        public bool Available(DateTime start, DateTime end)
        {
            bool available = true;
            for (DateTime d = start; d < end; d = d.AddDays(1))
            {
                if (Calendar[d.Month, d.Day])
                {
                    available = false;
                    break;
                }
            }
            return available;
        }

        public void FillDates(DateTime start, int len)
        {
            DateTime end = start.AddDays(len);
            FillDates(start, end);
        }

        public void FillDates(DateTime start, DateTime end)
        {
            for (DateTime d = start; d < end; d = d.AddDays(1))
            {
                Calendar[d.Month, d.Day] = true;
            }
        }

        public override string ToString()
        {
            string hostingUnit = "";

            hostingUnit += "Key:" + HostingUnitKey.ToString();

            hostingUnit += "Owner:" + Owner.ToString();

            return hostingUnit;
        }



    }
}
