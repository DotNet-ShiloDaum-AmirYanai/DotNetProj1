using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public static class Configuration
    {
        public static float Fee { get; } = 10;
        public static int ExpDays { get; } = 14;
        
        public static int GuestRequestKey = 10000000;
        public static int getGRKey()
        { return GuestRequestKey++; }

        public static int HostingUnitKey = 10000000;
        public static int getHUKey()
        { return HostingUnitKey++; }

    }
  
}
