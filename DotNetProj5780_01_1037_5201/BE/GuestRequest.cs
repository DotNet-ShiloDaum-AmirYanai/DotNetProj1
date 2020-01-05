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
        public Guest GuestPersonalDetails {  set; get; }
        public DemandStatusTypes Status {  set; get; }
        public DateTime RegistrationDate {  set; get; }
        public DateTime EntryDate {  set; get; }
        public DateTime ReleaseDate {  set; get; }
        public List<AreaTypes> Areas {  set; get; }
        public List<string> SunbAreas {  set; get; }
        public HostingUnitTypes Type{ set; get;}
        public int Adults { set; get; }
        public int Children { set; get; }
        public RequirementTypes Pool {  set; get; }
        public RequirementTypes HotTub {  set; get; }
        public RequirementTypes Garden {  set; get; }
        public RequirementTypes ChildrenAttractions {  set; get; }

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
