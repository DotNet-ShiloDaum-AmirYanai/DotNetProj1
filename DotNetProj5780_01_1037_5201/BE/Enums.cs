using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public enum HostingUnitTypes { BoardingHouse, HostingRoom, HotelRoom, Tent,other}
    public enum AreaTypes { North,South,Center,Jerusalem,other}
    public enum OrderStatusTypes { NotHandled,EmailSent,CloseNotAnswered, AnsweredClose, other}
    public enum DemandStatusTypes { Open,DealClosed,Expired,other}
    public enum RequirementTypes { Yes,Maybe,No,other }
}
