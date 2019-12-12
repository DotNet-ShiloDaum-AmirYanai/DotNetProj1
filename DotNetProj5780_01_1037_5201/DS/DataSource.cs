using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    //store al data source
    public class DataSource
    {
        public static List<BE.GuestRequest> DSGuestRequests { set; get; }
        public static List<BE.Order> DSOrders { set; get; }
        public static List<BE.HostingUnit> DSHostingUnits { set; get; }
    }
}
