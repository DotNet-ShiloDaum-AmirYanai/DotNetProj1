using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    interface IBL
    {
        /// <summary>
        /// add a guest requests
        /// </summary>
        /// <param name="GR">the Guest request</param>
        void AddGuestRequest(BE.GuestRequest GR);
        /// <summary>
        /// update a guest requests
        /// </summary>
        /// <param name="GR">the Guest request</param>
        void UpdateGuestRequest(DemandStatusTypes status, int key);

        /// <summary>
        /// add a hosting unit
        /// </summary>
        /// <param name="HU">hosting unit</param>
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
