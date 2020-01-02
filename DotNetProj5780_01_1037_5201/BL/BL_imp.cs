using System;
using System.Collections.Generic;
using System.Linq;
using BE;

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
            int count = 0;
            if (date2 < date1)
            {
                throw new BLExceptionDateIncorrect();
            }
            for (DateTime date = date1; date < date2; date=date.AddDays(1))
            {
                count++;
            }
            return count;
        }
        
        public int DaysPassed(DateTime date1)
        {
            return DaysPassed(date1,DateTime.Now);
        }

       

        public IEnumerable<BE.Order> OrdersFromDays(int numOfDays)
        {
            throw new NotImplementedException();
        }


        IEnumerable<BE.Order> IBL.OrdersFromDays(int numOfDays)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GuestRequest> GuestRequestRequirements(Delegate req)
        {
            throw new NotImplementedException();
        }

        public int NumOfGuestOrders(GuestRequest gr)
        {
            throw new NotImplementedException();
        }

        public int NumOfHUClosedOrders(HostingUnit hu)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GuestRequest> GroupGRByArea()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GuestRequest> GroupByVactionNum()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Host> GroupByHUNum()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HostingUnit> GroupHUByArea()
        {
            throw new NotImplementedException();
        }
    }
}
