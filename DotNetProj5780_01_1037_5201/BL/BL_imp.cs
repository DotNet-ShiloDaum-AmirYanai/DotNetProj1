using System;
using System.Collections.Generic;

namespace BL
{
    public class BL_imp: IBL
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
                catch (DalExeptionIdalreadyExist)
                {
                    throw new BLExeptionIdalreadyExist();
                }
            }
            else
                throw new BLExeptionDateIncorrect();
        }

        void UpdateGuestRequest(DemandStatusTypes status, int key)
        {
            try
            {
                dal.UpdateGuestRequest(status, key);
            }
            catch (DalExceptionInValidKey)
            {
                throw new BlExeptionInvalidKey();
            }
            catch (DalExeptionIdDoesnotexist)
            {
                throw new BLExeptionIdDoesNotExist();
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
            catch(DalExeptionIdalreadyExist)
            {
                throw new BLExeptionIdalreadyExist();
            }         
        }

        void DelHostingUnit(BE.HostingUnit HU)
        {

            try
            {
                dal.DelHostingUnit(HU);
            }
            catch (DalExeptionHostingUnitDoesNotExist)
            {

                throw new BLExeptionHostingUnitDoesNotExist();
            }
        }

        void UpdateHostingUnit(BE.HostingUnit HU);

        #endregion


        #region Order functions
        void AddOrder(BE.Order O);
        /// <summary>
        /// update an order usually the order status is updated
        /// </summary>
        /// <param name="O">order</param>
        void UpdateOrder(BE.Order O);
        #endregion


        //get data
        IEnumerable<BE.HostingUnit> GetHostingUnits();
        IEnumerable<BE.GuestRequest> GetGuestRequests();
        IEnumerable<BE.Order> GetOrders();
        IEnumerable<string> GetBankBranches();

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

    }
}
