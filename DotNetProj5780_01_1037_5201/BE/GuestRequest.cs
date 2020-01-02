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
        public double Totalcomission { set; get; }
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

       

        public override int GetHashCode()
        {
            var hashCode = 701007377;
            hashCode = hashCode * -1521134295 + GuestRequestKey.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Guest>.Default.GetHashCode(GuestPersonalDetails);
            hashCode = hashCode * -1521134295 + Status.GetHashCode();
            hashCode = hashCode * -1521134295 + RegistrationDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EntryDate.GetHashCode();
            hashCode = hashCode * -1521134295 + ReleaseDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<AreaTypes>>.Default.GetHashCode(Areas);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(SunbAreas);
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + Adults.GetHashCode();
            hashCode = hashCode * -1521134295 + Children.GetHashCode();
            hashCode = hashCode * -1521134295 + Pool.GetHashCode();
            hashCode = hashCode * -1521134295 + HotTub.GetHashCode();
            hashCode = hashCode * -1521134295 + Garden.GetHashCode();
            hashCode = hashCode * -1521134295 + ChildrenAttractions.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            return obj is GuestRequest request &&
                   GuestRequestKey == request.GuestRequestKey;
        }
    }
}
