using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class BlExeptionIdalreadyExist : Exception
    {
        public BlExeptionIdalreadyExist() { }
    }

    public class BlExeptionDateIncorrect : Exception
    {
        public BlExeptionDateIncorrect() { }
    }

    public class BlExeptionInvalidKey : Exception
    {
        public BlExeptionInvalidKey() { }
    }
    public class BLExeptionIdDoesnotexist : Exception
    {
        public BLExeptionIdDoesnotexist() { }
    }
    public class BlExeptionHostingUnitDoesntExict : Exception
    {
        public BlExeptionHostingUnitDoesntExict() { }
    }
}

