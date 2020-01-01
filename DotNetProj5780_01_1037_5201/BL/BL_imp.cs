using System;
using System.Collections.Generic;
using BE;
using DAL;

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
                    throw new BlExeptionIdalreadyExist();
                }
            }
            else
                throw new BlExeptionDateIncorrect();
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
                throw new BLExeptionIdDoesnotexist();
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
                throw new BlExeptionIdalreadyExist();
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

                throw new BlExeptionHostingUnitDontExict();
            }
        }

        void UpdateHostingUnit(BE.HostingUnit HU);

        #endregion



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

        void IBL.AddGuestRequest(GuestRequest GR)
        {
            throw new NotImplementedException();
        }

        void IBL.UpdateGuestRequest(DemandStatusTypes status, int key)
        {
            throw new NotImplementedException();
        }

        void IBL.AddHostingUnit(HostingUnit HU)
        {
            throw new NotImplementedException();
        }

        void IBL.DelHostingUnit(HostingUnit HU)
        {
            throw new NotImplementedException();
        }

        void IBL.UpdateHostingUnit(HostingUnit HU)
        {
            throw new NotImplementedException();
        }

        void IBL.AddOrder(Order O)
        {
            throw new NotImplementedException();
        }

        void IBL.UpdateOrder(Order O)
        {
            throw new NotImplementedException();
        }

        IEnumerable<HostingUnit> IBL.GetHostingUnits()
        {
            throw new NotImplementedException();
        }

        IEnumerable<GuestRequest> IBL.GetGuestRequests()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> IBL.GetOrders()
        {
            throw new NotImplementedException();
        }

        IEnumerable<string> IBL.GetBankBranches()
        {
            throw new NotImplementedException();
        }
    }
}
