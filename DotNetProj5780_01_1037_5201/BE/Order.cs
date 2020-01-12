using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    [Serializable]
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
        public int HostingUnitKey {  set; get; }
        //?
        public HostingUnit ItsHostingUnit {  set; get; }
        public int GuestRequestKey {  set; get; }
        public GuestRequest ItsGuestRequest {  set; get; }
        public int OrderKey {  set; get; }
        public OrderStatusTypes OrderStatus { set; get; }
        public DateTime CreateDate {  set; get; }
        public DateTime CreateOrderDate {  set; get; }
        public override string ToString()
        {
            string order = "";

            //ToDo

            return order;
        }
    }
}
