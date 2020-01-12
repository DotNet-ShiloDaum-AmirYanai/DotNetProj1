using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    //store al data source
    public static class DataSource
    {
        public static List<BE.GuestRequest> DSGuestRequests;
        public static List<BE.Order> DSOrders { set; get; }
        public static List<BE.HostingUnit> DSHostingUnits { set; get; }


        static DataSource()
        {

            #region start GuestRequests

            DSGuestRequests = new List<BE.GuestRequest>();
            DSHostingUnits = new List<BE.HostingUnit>();
            DSOrders = new List<BE.Order>();
            BE.Guest Guest1 = new BE.Guest
            {
                FirstName = "Amir",
                LastName = "Yanai",
                ID = 666995201,
                Email = "AM@gmail.com",
            };

            BE.GuestRequest GR1 = new BE.GuestRequest
            {
                GuestRequestKey = 11111111,
                Totalcomission = 0,
                GuestPersonalDetails = Guest1,
                Status = BE.DemandStatusTypes.Open,
                RegistrationDate = new DateTime(2020, 1, 1),
                EntryDate = new DateTime(2020, 3, 16),
                ReleaseDate = new DateTime(2020, 4, 25),
                Areas = new List<BE.AreaTypes>() { BE.AreaTypes.Jerusalem, BE.AreaTypes.North },
                SunbAreas = new List<String>() {"Maale Edomim", "Modiin" },
                Type = BE.HostingUnitTypes.BoardingHouse,
                Adults = 1,
                Children = 5,
                Pool = BE.RequirementTypes.Yes,
                HotTub = BE.RequirementTypes.No,
                Garden = BE.RequirementTypes.Yes,
                ChildrenAttractions = BE.RequirementTypes.No
            };

            DSGuestRequests.Add(GR1);
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
