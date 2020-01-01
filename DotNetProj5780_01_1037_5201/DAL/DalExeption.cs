using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DalExeptionIdalreadyExist : Exception
    {
        public DalExeptionIdalreadyExist() { }
    }
    public class DalExeptionIdDoesnotexist : Exception
    {
        public DalExeptionIdDoesnotexist() { }
    }
    public class DalExeptionHUDoesnotexist : Exception
    {
        public DalExeptionHUDoesnotexist() { }
    }
    public class DalExceptionInValidKey : Exception
    {
        public DalExceptionInValidKey() { }
    }
    public class DalExeptionHostingUnitDoesNotExist : Exception
    {
        public DalExeptionHostingUnitDoesNotExist() { }
    }
}