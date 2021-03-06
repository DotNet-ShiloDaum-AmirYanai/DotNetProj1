﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BL
{
    public class BL_imp : IBL
    {
        readonly DAL.IDAL dal= DAL.FactoryDal.GetDal();

        DAL.IDAL Dal { get=>dal; }

        #region Guest Request functions
        public void AddGuestRequest(BE.GuestRequest GR)
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

        public void UpdateGuestRequest(BE.DemandStatusTypes status, int key)
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
        public void AddHostingUnit(BE.HostingUnit HU)
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

        public void DelHostingUnit(BE.HostingUnit HU)
        {
            List<BE.Order> orders = DS.DataSource.DSOrders.FindAll(order => order.HostingUnitKey == HU.HostingUnitKey);

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

        public void UpdateHostingUnit(BE.HostingUnit HU)
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
        public void AddOrder(BE.Order O)
        {
            int HUKey = DS.DataSource.DSHostingUnits.FindIndex(t => t.HostingUnitKey == O.HostingUnitKey);
            if (HUKey < 0)
                throw new BLExceptionHostingUnitDoesNotExist();
            BE.HostingUnit HU = DS.DataSource.DSHostingUnits[HUKey];
            int GRKey = DS.DataSource.DSGuestRequests.FindIndex(t => t.GuestRequestKey == O.GuestRequestKey);
            if (GRKey < 0)
                throw new BLExceptionGuestRequestDoesNotExist();
            BE.GuestRequest GR = DS.DataSource.DSGuestRequests[GRKey];

            if (!Available(GR.EntryDate, GR.ReleaseDate, HU))
                throw new BLExceptionTheOrderDateAreOccupied();

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
                    BE.GuestRequest GR = DS.DataSource.DSGuestRequests.Find(t => t.GuestRequestKey == O.GuestRequestKey);
                    int days = DaysPassed(GR.EntryDate, GR.ReleaseDate);

                    double fee = days * BE.Configuration.Fee;
                    GR.Totalcomission = fee;
                    
                    if (!Available(GR.EntryDate, GR.ReleaseDate, HU))
                        throw new BLExceptionTheOrderDateAreOccupied();

                    FillDates(GR.EntryDate, GR.ReleaseDate, HU);

                    UpdateGuestRequest(BE.DemandStatusTypes.DealClosed, GR.GuestRequestKey);
                }
            }
            else
                throw new BLExceptionTheOrderIsClose();

        }

        #endregion

        #region getters
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
        #endregion


        public IEnumerable<BE.HostingUnit> AvailableInDates(DateTime date, int len)
        {
            var availables = from HU in GetHostingUnits()
            where Available(date,len, HU)
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


        #region groups function
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

        #endregion

        #region help function

        public bool Available(DateTime start, int len, BE.HostingUnit HU)
        {
            DateTime end = start.AddDays(len);
            return Available(start, end, HU);
        }

        public bool Available(DateTime start, DateTime end, BE.HostingUnit HU)
        {
            bool available = true;
            for (DateTime d = start; d < end; d = d.AddDays(1))
            {
                if (HU.Calendar[d.Month, d.Day])
                {
                    available = false;
                    break;
                }
            }
            return available;
        }

        public void FillDates(DateTime start, int len, BE.HostingUnit HU)
        {
            DateTime end = start.AddDays(len);
            FillDates(start, end, HU);
        }

        public void FillDates(DateTime start, DateTime end, BE.HostingUnit HU)
        {
            for (DateTime d = start; d < end; d = d.AddDays(1))
            {
                HU.Calendar[d.Month, d.Day] = true;
            }
        }

        private bool ValidateEmail(string emailAddress)
        {
            var regex = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@"
                             + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

            bool isValid = Regex.IsMatch(emailAddress, regex, RegexOptions.IgnoreCase);
            return isValid;
        }

        #endregion
    }
}
