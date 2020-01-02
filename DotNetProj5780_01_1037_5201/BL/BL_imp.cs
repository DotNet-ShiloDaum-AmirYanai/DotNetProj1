using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class BL_imp : IBL
    {
        readonly DAL.IDAL dal= DAL.FactoryDal.GetDal();

        DAL.IDAL Dal { get=>dal; }

        #region Guest Request functions
        public void AddGuestRequest(BE.GuestRequest GR)
        {
            if (GR.EntryDate < GR.ReleaseDate)
            {
                try
                {
                    Dal.AddGuestRequest(GR);
                }
                catch (DAL.DALExceptionIdalreadyExist)
                {
                    throw new BL.BLExceptionIdalreadyExist();
                }
            }
            else
                throw new BLExceptionDateIncorrect();
        }

        public void UpdateGuestRequest(BE.DemandStatusTypes status, int key)
        {
            try
            {
                Dal.UpdateGuestRequest(status, key);
            }
            catch (DAL.DALExceptionInValidKey)
            {
                throw new BL.BLExceptionInvalidKey();
            }
            catch (DAL.DALExceptionIdDoesnotexist)
            {
                throw new BL.BLExceptionIdDoesNotExist();
            }
        }
        #endregion


        #region Hosting unit functions
        public void AddHostingUnit(BE.HostingUnit HU)
        {
            try
            {
                dal.AddHostingUnit(HU);
            }
            catch(DAL.DALExceptionIdalreadyExist)
            {
                throw new BL.BLExceptionIdalreadyExist();
            }         
        }

        public void DelHostingUnit(BE.HostingUnit HU)
        {

            try
            {
                dal.DelHostingUnit(HU);
            }
            catch (DAL.DALExceptionHostingUnitDoesNotExist)
            {

                throw new BL.BLExceptionHostingUnitDoesNotExist();
            }
        }

        public void UpdateHostingUnit(BE.HostingUnit HU)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Order functions
        void IBL.AddOrder(BE.Order O)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// update an order usually the order status is updated
        /// </summary>
        /// <param name="O">order</param>
        void IBL.UpdateOrder(BE.Order O)
        {
            throw new NotImplementedException();
        }
        #endregion


        //getters
        public IEnumerable<BE.HostingUnit> GetHostingUnits()
        {
            return Dal.GetHostingUnits();
        }
        public IEnumerable<BE.GuestRequest> GetGuestRequests()
        {
            return Dal.GetGuestRequests();
        }
        public IEnumerable<BE.Order> GetOrders()
        {
            return Dal.GetOrders();
        }
        public IEnumerable<string> GetBankBranches()
        {
            return Dal.GetBankBranches();
        }


        public IEnumerable<BE.HostingUnit> AvailableInDates(DateTime date, int len)
        {
            var availables = from HU in GetHostingUnits()
            where HU.Available(date,len)
            select HU;

            return availables;
        }

        public int DaysPassed(DateTime date1, DateTime date2)
        {
            if (date2 < date1)
            {
                throw new BLExceptionDateIncorrect();
            }
            //to check if return all days includes months etc
            return date2.Date.Subtract(date1.Date).Days;
        }
        
        public int DaysPassed(DateTime date1)
        {
            return DaysPassed(date1,DateTime.Now);
        }

       

        public IEnumerable<BE.Order> OrdersFromDays(int numOfDays)
        {
            //creation Date previous to numOfDays ago
            var orders=from ord in GetOrders() where ord.CreateDate.AddDays(numOfDays).Date < DateTime.Now.Date select ord;

            return orders;
        }




        public IEnumerable<BE.GuestRequest> GuestRequestRequirements(Func<BE.GuestRequest,bool> req)
        {
            var requests = from gr in GetGuestRequests() where req(gr) select gr;

            return requests;
        }

        public int NumOfGuestOrders(BE.GuestRequest gr)
        {
            var orders = from ord in GetOrders() where ord.ItsGuestRequest.Equals(gr) select ord;
            return orders.Count();
        }

        public int NumOfHostingUnits(BE.Host host)
        {
            var HUs = from hu in GetHostingUnits() where hu.Owner.Equals(host) select hu;
            return HUs.Count();
        }

        public int NumOfHUClosedOrders(BE.HostingUnit hu)
        {
            var orders = from ord in GetOrders() where ord.ItsHostingUnit.Equals(hu) && ord.OrderStatus==BE.OrderStatusTypes.AnsweredClose select ord;
            return orders.Count();
        }

        public IEnumerable<IEnumerable<BE.GuestRequest>> GroupGRByArea()
        {
            var grs = from gr in GetGuestRequests() group gr by gr.Areas[0];

            return grs;
        }

        public IEnumerable<IEnumerable<BE.GuestRequest>> GroupByVactionNum()
        {
            var grs = from gr in GetGuestRequests() group gr by NumOfGuestOrders(gr);

            return grs;
        }

        public IEnumerable<IEnumerable<BE.Host>> GroupByHUNum()
        {
            var hus = from hu in GetHostingUnits() group hu.Owner by hu.Owner;

            var hosts = from owner in hus group owner.First() by owner.Count();

            return hosts;
        }

        public IEnumerable<IEnumerable<BE.HostingUnit>> GroupHUByArea()
        {
            var HUs = from hu in GetHostingUnits() group hu by hu.UnitAreaType;

            return HUs;
        }
    }
}
