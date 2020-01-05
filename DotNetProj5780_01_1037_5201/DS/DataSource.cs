using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    //store al data source
    public static class DataSource
    {
        public static List<BE.GuestRequest> DSGuestRequests { set; get; }
        public static List<BE.Order> DSOrders { set; get; }
        public static List<BE.HostingUnit> DSHostingUnits { set; get; }

        static DataSource()
        {
            #region start GuestRequests

            #endregion

            #region start Orders

            #endregion

            #region start HostingUnits
            BE.Host host1 = new BE.Host
            {
                FirstName = "David",
                LastName = "Cohen",
                PhoneNumber = "+972555555555",
                Email = "DavidCohen@gmail.com",
            };
            BE.Host host2 = new BE.Host
            {
                FirstName = "Binyamin",
                LastName = "Israel",
                PhoneNumber = "+972666666666",
                Email = "BinIs@yahoo.com",
            };

            BE.HostingUnit hostingUnit1 = new BE.HostingUnit
            {
                HostingUnitKey = BE.Configuration.getHUKey(),
                Owner = host1,
                OwnerName = host1.FirstName + " " + host1.LastName,
                UnitType = BE.HostingUnitTypes.HostingRoom,
                UnitAreaType = BE.AreaTypes.Center,

            };
            BE.HostingUnit hostingUnit2 = new BE.HostingUnit
            {
                HostingUnitKey = BE.Configuration.getHUKey(),
                Owner = host1,
                OwnerName = host1.FirstName + " " + host1.LastName,
                UnitType = BE.HostingUnitTypes.HotelRoom,
                UnitAreaType = BE.AreaTypes.Jerusalem,
            };

            BE.HostingUnit hostingUnit3 = new BE.HostingUnit
            {
                HostingUnitKey = BE.Configuration.getHUKey(),
                Owner = host2,
                OwnerName = host2.FirstName + " " + host2.LastName,
                UnitType = BE.HostingUnitTypes.BoardingHouse,
                UnitAreaType = BE.AreaTypes.South,
            };

            BE.HostingUnit hostingUnit4 = new BE.HostingUnit
            {
                HostingUnitKey = BE.Configuration.getHUKey(),
                Owner = host2,
                OwnerName = host2.FirstName + " " + host2.LastName,
                UnitType = BE.HostingUnitTypes.Tent,
                UnitAreaType = BE.AreaTypes.North,
            };
            DSHostingUnits.Add(hostingUnit1);
            DSHostingUnits.Add(hostingUnit2);
            DSHostingUnits.Add(hostingUnit3);
            DSHostingUnits.Add(hostingUnit4);
            #endregion
        }
    }
}
