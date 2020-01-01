using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;


namespace DAL
{
    sealed class Dal_imp : IDAL
    {
        private static readonly Dal_imp instance = new Dal_imp();

        public static Dal_imp Instance { get => instance; }

        static Dal_imp() {}

        public void AddGuestRequest(GuestRequest GR)
        {
            if (GR.GuestRequestKey != 0)
            {
                if (!GuestValidate(GR))
                    throw new DalExeptionIdalreadyExist();
            }
            else
            {
                GR.GuestRequestKey = BE.Configuration.getGRKey();
            }
            DS.DataSource.DSGuestRequests.Add(GR.Copy());
        }
        private bool GuestValidate(GuestRequest GR)
        {
            bool exists = false;
            foreach (GuestRequest item in DS.DataSource.DSGuestRequests)
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
        public void AddHostingUnit(HostingUnit HU)
        {
            if (HU.HostingUnitKey != 0)
            {
                if (!HUValidate(HU))
                    throw new DalExeptionIdalreadyExist();
            }
            else
            {
                HU.HostingUnitKey = BE.Configuration.getHUKey();
            }
            DS.DataSource.DSHostingUnits.Add(HU.Copy());
        }
        private bool HUValidate(HostingUnit HU)
        {
            int count = (from item in DS.DataSource.DSHostingUnits
                         where item.HostingUnitKey == HU.HostingUnitKey
                         select item).Count();
            return count == 0 ? true : false;
        }
        public void AddOrder(Order O)
        {
            if (!OrderValidate(O))
                throw new ArgumentException("This Order already exsist");
            DS.DataSource.DSOrders.Add(O.Copy());
        }
        private bool OrderValidate(Order O)
        {
            bool exists = false;
            foreach (Order item in DS.DataSource.DSOrders)
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

        public void DelHostingUnit(HostingUnit HU)
        {
            bool flag = DS.DataSource.DSHostingUnits.Remove(HU);
            if (!flag)
                throw new DalExeptionHostingUnitDoesNotExist();
        }

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

        public IEnumerable<GuestRequest> GetGuestRequests()
        {
            return (from GuestRequest in DS.DataSource.DSGuestRequests
                   select GuestRequest.Copy()).ToList();
        }

        public IEnumerable<HostingUnit> GetHostingUnits()
        {
            return from HostingUnit in DS.DataSource.DSHostingUnits
                   select HostingUnit.Copy();
        }

        public IEnumerable<Order> GetOrders()
        {
            return from DSOrders in DS.DataSource.DSOrders
                   select DSOrders.Copy();
        }
        #endregion

        public void UpdateGuestRequest(DemandStatusTypes status, int key)
        {
            if (key < 10000000)
                throw new DalExceptionInValidKey();
            var GR = from GuestRequest in DS.DataSource.DSGuestRequests
                     where GuestRequest.GuestRequestKey == key
                     select GuestRequest;
            int count= DS.DataSource.DSGuestRequests.RemoveAll(t=> t.GuestRequestKey== key);
            if (count == 0)
                throw new DalExeptionIdDoesnotexist();
            GR.ToList()[0].Status = status;
            AddGuestRequest(GR.ToList()[0]);
        }

        public void UpdateHostingUnit(HostingUnit HU)
        {
            int count = DS.DataSource.DSHostingUnits.RemoveAll(t => t.HostingUnitKey == HU.HostingUnitKey);
            if (count == 0)
                throw new DalExeptionHUDoesnotexist();
            AddHostingUnit(HU);
        }

        public void UpdateOrder(Order O)
        {
            throw new NotImplementedException();
        }
    }
}
