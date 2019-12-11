using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Order
    {
        /// <summary>
        /// hosting unit key
        /// reference to its hosting unit
        /// guest request key
        /// reference to the guest request
        /// order key
        /// order status
        /// date of the creation of the order
        /// date of the email that was sent to user
        /// </summary>
        public int HostingUnitKey { private set; get; }
        //?
        public HostingUnit ItsHostingUnit { private set; get; }
        public int GuestRequestKey { private set; get; }
        public GuestRequest ItsGuestRequest { private set; get; }
        public int OrderKey { private set; get; }
        public OrderStatusTypes OrderStatus { private set; get; }
        public DateTime CreateDate { private set; get; }
        public DateTime CreateOrderDate { private set; get; }
        public override string ToString()
        {
            string order = "";

            //ToDo

            return order;
        }
    }
}
