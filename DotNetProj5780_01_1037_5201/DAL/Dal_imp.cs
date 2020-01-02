using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAL
{
    sealed class Dal_imp : IDAL
    {
        private static readonly Dal_imp instance = new Dal_imp();

        public static Dal_imp Instance { get => instance; }

        static Dal_imp() {}

        #region Guest Request function
        public void AddGuestRequest(BE.GuestRequest GR)
        {
            if (GR.GuestRequestKey != 0)
            {
                if (!GuestValidate(GR))
                    throw new DALExceptionIdalreadyExist();
            }
            else
            {
                GR.GuestRequestKey = BE.Configuration.getGRKey();
            }
            DS.DataSource.DSGuestRequests.Add(GR.Copy());
        }
        public void UpdateGuestRequest(BE.DemandStatusTypes status, int key)
        {
            if (key < 10000000)
                throw new DALExceptionInValidKey();
            var GR = from GuestRequest in DS.DataSource.DSGuestRequests
                     where GuestRequest.GuestRequestKey == key
                     select GuestRequest;
            int count = DS.DataSource.DSGuestRequests.RemoveAll(t => t.GuestRequestKey == key);
            if (count == 0)
                throw new DALExceptionIdDoesnotexist();
            GR.ToList()[0].Status = status;
            AddGuestRequest(GR.ToList()[0]);
        }
        #endregion

        #region HostingUnit Unit function
        public void AddHostingUnit(BE.HostingUnit HU)
        {
            if (HU.HostingUnitKey != 0)
            {
                if (!HUValidate(HU))
                    throw new DALExceptionIdalreadyExist();
            }
            else
            {
                HU.HostingUnitKey = BE.Configuration.getHUKey();
            }
            DS.DataSource.DSHostingUnits.Add(HU.Copy());
        }
        public void DelHostingUnit(BE.HostingUnit HU)
        {
            bool flag = DS.DataSource.DSHostingUnits.Remove(HU);
            if (!flag)
                throw new DALExceptionHostingUnitDoesNotExist();
        }
        public void UpdateHostingUnit(BE.HostingUnit HU)
        {
            int count = DS.DataSource.DSHostingUnits.RemoveAll(t => t.HostingUnitKey == HU.HostingUnitKey);
            if (count == 0)
                throw new DALExceptionHUDoesnotexist();
            AddHostingUnit(HU);
        }

        #endregion

        #region Order function
        public void AddOrder(BE.Order O)
        {
            if (!OrderValidate(O))
                throw new ArgumentException("This Order already exsist");
            DS.DataSource.DSOrders.Add(O.Copy());
        }
        private bool OrderValidate(BE.Order O)
        {
            bool exists = false;
            foreach (BE.Order item in DS.DataSource.DSOrders)
            {
                //this person had a previous Request
                if (item.HostingUnitKey == (O.HostingUnitKey) && item.GuestRequestKey == (O.GuestRequestKey))
                {
                    exists = true;
                }
            }
            //if does not exists
            return !exists;
        }
        public void UpdateOrder(BE.OrderStatusTypes status, int key)
        {
            if (key < 10000000)
                throw new DALExceptionInValidKey();
            var O = from order in DS.DataSource.DSOrders
                    where order.OrderKey == key
                    select order;
            int count = DS.DataSource.DSOrders.RemoveAll(t => t.OrderKey == key);
            if (count == 0)
                throw new DALExceptionIdDoesnotexist();
            O.ToList()[0].OrderStatus = status;
            AddOrder(O.ToList()[0]);

        }
        #endregion

        #region gets functions
        public IEnumerable<string> GetBankBranches()
        {
            List<string> branches = new List<string>();
            //arbitary data
            branches.Add("Pepper bank: 10, 101");
            branches.Add("Poalim bank: 9, 25");
            branches.Add("Yahav bank: 8, 234");
            branches.Add("International bank: 7, 43");
            branches.Add("Mizrachi bank: 6, 23");
            return branches;
        }

        public IEnumerable<BE.GuestRequest> GetGuestRequests()
        {
            return (from GuestRequest in DS.DataSource.DSGuestRequests
                   select GuestRequest.Copy()).ToList();
        }

        public IEnumerable<BE.HostingUnit> GetHostingUnits()
        {
            return from HostingUnit in DS.DataSource.DSHostingUnits
                   select HostingUnit.Copy();
        }

        public IEnumerable<BE.Order> GetOrders()
        {
            return from DSOrders in DS.DataSource.DSOrders
                   select DSOrders.Copy();
        }
        #endregion

        #region help function
        private bool GuestValidate(BE.GuestRequest GR)
        {
            bool exists = false;
            foreach (BE.GuestRequest item in DS.DataSource.DSGuestRequests)
            {
                //this person had a previous Request
                if (item.GuestPersonalDetails.Equals(GR.GuestPersonalDetails))
                {
                    exists = true;
                }
            }
            //if does not exists
            return !exists;
        }

        private bool HUValidate(BE.HostingUnit HU)
        {
            int count = (from item in DS.DataSource.DSHostingUnits
                         where item.HostingUnitKey == HU.HostingUnitKey
                         select item).Count();
            return count == 0 ? true : false;
        }
        #endregion

      
    }
}
