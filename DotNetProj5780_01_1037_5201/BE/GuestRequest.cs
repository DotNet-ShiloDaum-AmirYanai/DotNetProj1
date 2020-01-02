using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class GuestRequest
    {
        /// <summary>
        /// the request key
        /// the guest personal data- name and email
        /// the request status
        /// registration dates
        /// entry and release dates
        /// the requested areas and/or subareas
        /// requested unit type
        /// number of residents: adults and children
        /// requested pool, hot tub, garden and children attraction
        /// </summary>
        public int GuestRequestKey { set; get; }
        public Guest GuestPersonalDetails { private set; get; }
        public DemandStatusTypes Status {  set; get; }
        public DateTime RegistrationDate { private set; get; }
        public DateTime EntryDate { private set; get; }
        public DateTime ReleaseDate { private set; get; }
        public List<AreaTypes> Areas { private set; get; }
        public List<string> SunbAreas { private set; get; }
        public HostingUnitTypes Type{private set; get;}
        public int Adults { set; get; }
        public int Children { set; get; }
        public RequirementTypes Pool { private set; get; }
        public RequirementTypes HotTub { private set; get; }
        public RequirementTypes Garden { private set; get; }
        public RequirementTypes ChildrenAttractions { private set; get; }

        public override string ToString()
        {
            string guest = "";

            //ToDo

            return guest;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            else
            {
                GuestRequest other = (GuestRequest)obj;
                if (other.GuestRequestKey == this.GuestRequestKey)
                    return true;
            }
            return false;
        }
    }
}
