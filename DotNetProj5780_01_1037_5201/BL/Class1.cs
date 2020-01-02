using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    class Class1: IBL
    {
        DAL.IDAL dal = DAL.FactoryDal.GetDal();


        #region Guest Request functions
        void AddGuestRequest(BE.GuestRequest GR)
        {
            if (GR.EntryDate < GR.ReleaseDate)
            {
                try
                {
                    dal.AddGuestRequest(GR);
                }
                catch (DAL.DALExceptionIdalreadyExist)
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
            catch (DAL.DALExceptionInValidKey)
            {
                throw new BL.BLExceptionInvalidKey();
            }
            catch (DAL.DALExceptionHUDoesnotexist)
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
            catch (DAL.DALExceptionIdalreadyExist)
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
            catch (DAL.DALExceptionHostingUnitDoesNotExist)
            {
                throw new BL.BLExceptionHostingUnitDoesNotExist();
            }
        }

        void UpdateHostingUnit(BE.HostingUnit HU)
        {

            try
            {
                dal.UpdateHostingUnit(HU);
            }
            catch (DAL.DALExceptionHUDoesnotexist)
            {

                throw new BLExceptionHostingUnitDoesNotExist();
            }
        }

        #endregion

        #region Order functions
        void AddOrder(BE.Order O)
        {

            throw new NotImplementedException();
        }


        public void UpdateOrder(BE.OrderStatusTypes status, int key)
        {
            if (key < 10000000)
                throw new BLExceptionInvalidKey();

            int ind = DS.DataSource.DSOrders.FindIndex(t => t.OrderKey == key);
            if (ind < 0)
                throw new BLExceptionKeyDoesNotExist();
            BE.Order O = DS.DataSource.DSOrders[ind];

            if (O.OrderStatus != BE.OrderStatusTypes.AnsweredClose)
            {  
                if (status == BE.OrderStatusTypes.EmailSent)
                {   
                    BE.HostingUnit owner = DS.DataSource.DSHostingUnits.Find(t => t.HostingUnitKey == O.HostingUnitKey);

                    if (owner.Owner.CollectionClearance != true)
                        throw new BLExceptionNoSignedAuthorization();
                    
                    //send an email
                }

                if (status == BE.OrderStatusTypes.AnsweredClose)
                {
                    
                }
            }
            else
                throw new BLExceptionTheOrderIsClose();
           
        }
        #endregion
    }
}
