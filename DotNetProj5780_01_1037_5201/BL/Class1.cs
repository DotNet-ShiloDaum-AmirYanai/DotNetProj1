using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BL
{
    class Class1: IBL
    {
        DAL.IDAL dal = DAL.FactoryDal.GetDal();


        #region Guest Request functions
        void AddGuestRequest(BE.GuestRequest GR)
        {
            if (!ValidateEmail(GR.GuestPersonalDetails.Email))
                throw new BLExceptionTheEmailIsInvalid();

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

        private bool ValidateEmail(string emailAddress)
        {
            var regex = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"  + "@"
                             + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

            bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            return isValid;
        }


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
            List<BE.Order> orders= DS.DataSource.DSOrders.FindAll(order => order.HostingUnitKey == HU.HostingUnitKey);

            // maybe we need to check more statuses
            int check = orders.FindIndex(order => order.OrderStatus == BE.OrderStatusTypes.NotHandled || order.OrderStatus == BE.OrderStatusTypes.EmailSent);
            if (check > 0)
                throw new BLExceptionTheHostUnitHasOpenOrders();
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
            BE.HostingUnit HU = DS.DataSource.DSHostingUnits.Find(t => t.HostingUnitKey == O.HostingUnitKey);
            BE.GuestRequest GR = DS.DataSource.DSGuestRequests.Find(t => t.GuestRequestKey == O.GuestRequestKey);

            for (int month = GR.EntryDate.Month; month <= GR.ReleaseDate.Month; month++)
            {
                for (int day = GR.EntryDate.Day; (day < 31) || (month == GR.ReleaseDate.Month && day > GR.ReleaseDate.Day); day++)
                {
                    if (HU.Calendar[month, day] != false)
                        throw new BLExceptionTheOrderDateAreOccupied();
                }
            }

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
                BE.HostingUnit HU = DS.DataSource.DSHostingUnits.Find(t => t.HostingUnitKey == O.HostingUnitKey);
                if (status == BE.OrderStatusTypes.EmailSent)
                {   
                    if (HU.Owner.CollectionClearance != true)
                        throw new BLExceptionNoSignedAuthorization();
                    
                    //send an email
                }

                if (status == BE.OrderStatusTypes.AnsweredClose)
                {
                    BE.GuestRequest GR= DS.DataSource.DSGuestRequests.Find(t => t.GuestRequestKey == O.GuestRequestKey);    
                    int days = DaysPassed(GR.EntryDate, GR.ReleaseDate);
                   //we need to done the fee funtions
                    double fee = days * BE.Configuration.Fee;

                    for (int month = GR.EntryDate.Month; month <= GR.ReleaseDate.Month; month++)
                    {
                        for (int day = GR.EntryDate.Day; (day < 31) || (month== GR.ReleaseDate.Month && day> GR.ReleaseDate.Day) ; day++)
                        {
                            HU.Calendar[month, day] = true;
                        }
                    } 

                    UpdateGuestRequest(BE.DemandStatusTypes.DealClosed, GR.GuestRequestKey);
                }
            }
            else
                throw new BLExceptionTheOrderIsClose();
           
        }
        #endregion
    }
}
