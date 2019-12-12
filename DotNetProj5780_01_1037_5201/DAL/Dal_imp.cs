using System;
using System.Collections.Generic;
using System.Text;
using BE;

namespace DAL
{
    class Dal_imp : IDal
    {
        public void AddGuestRequest(GuestRequest GR)
        {
            if (GuestValidate(GR))
            {
                DS.DataSource.DSGuestRequests.Add(GR);
            }
        }

        private bool GuestValidate(GuestRequest GR)
        {
            bool exists=false;
            foreach (GuestRequest item in DS.DataSource.DSGuestRequests)
            {
                //this person had a previous Request
                if (GR.GuestPersonalDetails.Equals(GR.GuestPersonalDetails))
                {
                    exists = true;
                }
            }
            //if does not exists
            return !exists;
        }

        public void AddHostingUnit(HostingUnit HU)
        {
            DS.DataSource.DSHostingUnits.Add(HU);
        }

        public void AddOrder(Order O)
        {
            DS.DataSource.DSOrders.Add(O);
        }

        public void DelHostingUnit(HostingUnit HU)
        {
            DS.DataSource.DSHostingUnits.Remove(HU);
        }

        public List<string> GetBankBranches()
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

        public List<GuestRequest> GetGuestRequests()
        {
            return new List<GuestRequest>(DS.DataSource.DSGuestRequests);
        }

        public List<HostingUnit> GetHostingUnits()
        {
            return new List<HostingUnit>(DS.DataSource.DSHostingUnits);
        }

        public List<Order> GetOrders()
        {
            return new List<Order>(DS.DataSource.DSOrders);
        }

        public void UpdateGuestRequest(GuestRequest GR)
        {
            throw new NotImplementedException();
        }

        public void UpdateHostingUnit(HostingUnit HU)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order O)
        {
            throw new NotImplementedException();
        }
    }
}
