using System;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {

            BE.Guest G = new BE.Guest();
            BE.Host H = new BE.Host();
            BE.HostingUnit HU=new BE.HostingUnit();
            BE.GuestRequest GR = new BE.GuestRequest();
            BE.Order O = new BE.Order();
            

            BL.BL_imp bl;

            bl.AddGuestRequest();


            Console.WriteLine("aaaaaaaaaaa working ok");
            Console.ReadKey();
        }
    }

    /*
     * 
        void AddGuestRequest(BE.GuestRequest GR);

        void UpdateGuestRequest(BE.DemandStatusTypes status, int key);

        void AddHostingUnit(BE.HostingUnit HU);

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
        /// 
        //void UpdateOrder(BE.Order O);
        void UpdateOrder(BE.OrderStatusTypes status, int key);
        IEnumerable<BE.HostingUnit> AvailableInDates(DateTime date, int VacationLen);
        int DaysPassed(DateTime date1, DateTime date2);

        int DaysPassed(DateTime date1);

        IEnumerable<BE.Order> OrdersFromDays(int numOfDays);

        IEnumerable<BE.GuestRequest> GuestRequestRequirements(Func<BE.GuestRequest,bool> req);

        int NumOfGuestOrders(BE.GuestRequest gr);
        int NumOfHostingUnits(BE.Host host);
        int NumOfHUClosedOrders(BE.HostingUnit hu);

        IEnumerable<IEnumerable<BE.GuestRequest>> GroupGRByArea();

        IEnumerable<IEnumerable<BE.GuestRequest>> GroupByVactionNum();

        IEnumerable<IEnumerable<BE.Host>> GroupByHUNum();

        IEnumerable<IEnumerable<BE.HostingUnit>> GroupHUByArea();



        //get data
        IEnumerable<BE.HostingUnit> GetHostingUnits();
        IEnumerable<BE.GuestRequest> GetGuestRequests();
        IEnumerable<BE.Order> GetOrders();
        IEnumerable<string> GetBankBranches();
     */
}
