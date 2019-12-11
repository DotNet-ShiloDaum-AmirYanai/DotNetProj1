using System;
using System.Collections.Generic;
using System.Text;
namespace DAL
{

    interface IDal
    {
        void AddGuestRequest(BE.GuestRequest GR);
        void UpdateGuestRequest(BE.GuestRequest GR);


        void AddHostingUnit(BE.HostingUnit HU);
        void DelHostingUnit(BE.HostingUnit HU);
        void UpdateHostingUnit(BE.HostingUnit HU);

        void AddOrder(BE.Order O);
        void UpdateOrder(BE.Order O);

        List<BE.HostingUnit> GetHostingUnits();
        List<BE.GuestRequest> GetGuestRequests();
        List<BE.Order> GetOrders();
        //maybe string?
        List<int> GetBankBranches();
    }
}
