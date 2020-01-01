using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class BLExeptionIdalreadyExist : Exception
    {
        public BLExeptionIdalreadyExist() { }
    }

    public class BLExeptionDateIncorrect : Exception
    {
        public BLExeptionDateIncorrect() { }
    }

    public class BLExeptionInvalidKey : Exception
    {
        public BLExeptionInvalidKey() { }
    }
    public class BLExeptionIdDoesNotExist : Exception
    {
        public BLExeptionIdDoesNotExist() { }
    }
    public class BLExeptionHostingUnitDoesNotExist : Exception
    {
        public BLExeptionHostingUnitDoesNotExist() { }
    }
}

