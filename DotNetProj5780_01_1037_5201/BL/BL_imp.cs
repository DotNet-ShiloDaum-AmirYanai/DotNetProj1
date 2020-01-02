using System;
using System.Collections.Generic;

namespace BL
{
    public class BL_imp : IBL
    {
        DAL.IDAL dal= DAL.FactoryDal.GetDal();

        #region Guest Request functions
        void AddGuestRequest(BE.GuestRequest GR)
        {
            if (GR.EntryDate < GR.ReleaseDate)
            {
                try
                {
                    dal.AddGuestRequest(GR);
                }
                catch (DAL.DalExeptionIdalreadyExist)
                {
                    throw new BL.BLExceptionIdalreadyExist();
                }
            }
            else
                throw new BLExceptionDateIncorrect();
        }

        void UpdateGuestRequest(BE.DemandStatusTypes status, int key)
        {
            try
            {
                dal.UpdateGuestRequest(status, key);
            }
            catch (DAL.DalExceptionInValidKey)
            {
                throw new BL.BLExceptionInvalidKey();
            }
            catch (DAL.DalExeptionIdDoesnotexist)
            {
                throw new BL.BLExceptionIdDoesNotExist();
            }
        }
        #endregion

        #region Hosting unit functions
        void AddHostingUnit(BE.HostingUnit HU)
        {
            try
            {
                dal.AddHostingUnit(HU);
            }
            catch(DAL.DalExeptionIdalreadyExist)
            {
                throw new BL.BLExceptionIdalreadyExist();
            }         
        }

        void DelHostingUnit(BE.HostingUnit HU)
        {

            try
            {
                dal.DelHostingUnit(HU);
            }
            catch (DAL.DalExeptionHostingUnitDoesNotExist)
            {

                throw new BL.BLExceptionHostingUnitDoesNotExist();
            }
        }

        void UpdateHostingUnit(BE.HostingUnit HU)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Order functions
        void AddOrder(BE.Order O)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// update an order usually the order status is updated
        /// </summary>
        /// <param name="O">order</param>
        void UpdateOrder(BE.Order O)
        {
            throw new NotImplementedException();
        }
        #endregion


        //get data
        IEnumerable<BE.HostingUnit> GetHostingUnits()
        {
            throw new NotImplementedException();
        }
        IEnumerable<BE.GuestRequest> GetGuestRequests()
        {
            throw new NotImplementedException();
        }
        IEnumerable<BE.Order> GetOrders()
        {
            throw new NotImplementedException();
        }
        IEnumerable<string> GetBankBranches()
        {
            throw new NotImplementedException();
        }

        void IBL.AddGuestRequest(BE.GuestRequest GR)
        {
            throw new NotImplementedException();
        }

        void IBL.UpdateGuestRequest(BE.DemandStatusTypes status, int key)
        {
            throw new NotImplementedException();
        }

        void IBL.AddHostingUnit(BE.HostingUnit HU)
        {
            throw new NotImplementedException();
        }

        void IBL.DelHostingUnit(BE.HostingUnit HU)
        {
            throw new NotImplementedException();
        }

        void IBL.UpdateHostingUnit(BE.HostingUnit HU)
        {
            throw new NotImplementedException();
        }

        void IBL.AddOrder(BE.Order O)
        {
            throw new NotImplementedException();
        }

        void IBL.UpdateOrder(BE.Order O)
        {
            throw new NotImplementedException();
        }

        IEnumerable<BE.HostingUnit> IBL.GetHostingUnits()
        {
            throw new NotImplementedException();
        }

        IEnumerable<BE.GuestRequest> IBL.GetGuestRequests()
        {
            throw new NotImplementedException();
        }

        IEnumerable<BE.Order> IBL.GetOrders()
        {
            throw new NotImplementedException();
        }

        IEnumerable<string> IBL.GetBankBranches()
        {
            throw new NotImplementedException();
        }

        IEnumerable<BE.HostingUnit> AvailableInDates(DateTime date, int VacationLen)
        {
            throw new NotImplementedException();

        }
        int DaysPassed(DateTime date1, DateTime date2)
        {
            throw new NotImplementedException();
        }
        
        int DaysPassed(DateTime date1)
        {
            return DaysPassed(date1,DateTime.Now);
        }

        IEnumerable<BE.HostingUnit> IBL.AvailableInDates(DateTime date, int VacationLen)
        {
            throw new NotImplementedException();
        }

        int IBL.DaysPassed(DateTime date1, DateTime date2)
        {
            throw new NotImplementedException();
        }

        int IBL.DaysPassed(DateTime date1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BE.Order> OrdersFromDays(int numOfDays)
        {
            throw new NotImplementedException();
        }


        IEnumerable<BE.Order> IBL.OrdersFromDays(int numOfDays)
        {
            throw new NotImplementedException();
        }
    }
}
