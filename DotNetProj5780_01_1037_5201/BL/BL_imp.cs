using System;
using BE

namespace BL
{
    public class BL_imp: IBL
    {
        
        void AddGuestRequest(BE.GuestRequest GR)
        {
            
        }


        void UpdateGuestRequest(BE.GuestRequest GR);


        void AddHostingUnit(BE.HostingUnit HU);
        /// <summary>
        /// delete a hosting unit
        /// </summary>
        /// <param name="HU">hosting unit</param>
        void DelHostingUnit(BE.HostingUnit HU);
        /// <summary>
        /// update a hosting unit
        /// </summary>
        /// <param name="HU">hosting unit</param>
        void UpdateHostingUnit(BE.HostingUnit HU);

        /// <summary>
        /// add an order
        /// </summary>
        /// <param name="O">order</param>
        void AddOrder(BE.Order O);
        /// <summary>
        /// update an order usually the order status is updated
        /// </summary>
        /// <param name="O">order</param>
        void UpdateOrder(BE.Order O);



        //get data
        IEnumerable<BE.HostingUnit> GetHostingUnits();
        IEnumerable<BE.GuestRequest> GetGuestRequests();
        IEnumerable<BE.Order> GetOrders();
        IEnumerable<string> GetBankBranches();
    }
}
