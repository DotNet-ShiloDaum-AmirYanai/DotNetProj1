using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace DAL
{
   

    class Dal_imp : IDAl
    {
        public void AddGuestRequest(GuestRequest GR)
        {
            if (GR.GuestRequestKey != 0)
            {
                if (!GuestValidate(GR))
                    throw new ArgumentException("This id already exsist");
            }
            else
            {
                GR.GuestRequestKey = BE.Configuration.getGRKey();
            }
            DS.DataSource.DSGuestRequests.Add(GR.Copy());               
        }
        private bool GuestValidate(GuestRequest GR)
        {
            bool exists=false;
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
                    throw new ArgumentException("This Hosting Unit already exsist");
            }
            else
            {
                HU.HostingUnitKey = BE.Configuration.getHUKey();
            }
            DS.DataSource.DSHostingUnits.Add(HU.Copy());
        }
        private bool HUValidate(HostingUnit HU)
        {
            bool exists = false;
            foreach (HostingUnit item in DS.DataSource.DSHostingUnits)
            {
                //this person had a previous Request
                if (item.HostingUnitKey == (HU.HostingUnitKey))
                {
                    exists = true;
                }
            }
            //if does not exists
            return !exists;
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
            bool flag =DS.DataSource.DSHostingUnits.Remove(HU);
            if (!flag)
                throw new ArgumentException("This HostingUnit you try to delete didn't exict");
        }

        public IEnumerable<string> GetBankBranches()
        {
            List<string> branches=new List<string>();
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
            return from GuestRequest in DS.DataSource.DSGuestRequests
                   select GuestRequest.Copy();
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

        public void UpdateGuestRequest(GuestRequest GR)
        {
            throw new NotImplementedException();
        }

        public void UpdateHostingUnit(HostingUnit HU)
        {
            var keys= from item in DS.DataSource.DSHostingUnits
            let key= HU.HostingUnitKey
            where key == item.HostingUnitKey
            select new {_HH= item };
           
            int count = DS.DataSource.DSHostingUnits.Remove( );
        }

        public void UpdateOrder(Order O)
        {
            throw new NotImplementedException();
        }
    }
}
