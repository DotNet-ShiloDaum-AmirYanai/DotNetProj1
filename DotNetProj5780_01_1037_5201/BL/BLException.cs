using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class BLException : Exception
    {
        public BLException() { }
    }
    public class BLExceptionIdalreadyExist : BLException
    {
        public BLExceptionIdalreadyExist() { }
    }

    public class BLExceptionDateIncorrect : BLException
    {
        public BLExceptionDateIncorrect() { }
    }

    public class BLExceptionInvalidKey : BLException
    {
        public BLExceptionInvalidKey() { }
    }
    public class BLExceptionIdDoesNotExist : BLException
    {
        public BLExceptionIdDoesNotExist() { }
    }
    public class BLExceptionHostingUnitDoesNotExist : BLException
    {
        public BLExceptionHostingUnitDoesNotExist() { }
    }
    public class BLExceptionKeyDoesNotExist : BLException
    {
        public BLExceptionKeyDoesNotExist() { }
    }
    public class BLExceptionNoSignedAuthorization : BLException
    {
        public BLExceptionNoSignedAuthorization() { }
    }
    public class BLExceptionTheOrderIsClose : BLException
    {
        public BLExceptionTheOrderIsClose() { }
    }
    public class BLExceptionTheHostUnitHasOpenOrders : BLException
    {
        public BLExceptionTheHostUnitHasOpenOrders() { }
    }
    public class BLExceptionTheOrderDateAreOccupied : BLException
    {
        public BLExceptionTheOrderDateAreOccupied() { }
    }
    public class BLExceptionTheEmailIsInvalid : BLException
    {
        public BLExceptionTheEmailIsInvalid() { }
    }
    public class BLExceptionGuestRequestDoesNotExist : BLException
    {
        public BLExceptionGuestRequestDoesNotExist() { }
    }


}




