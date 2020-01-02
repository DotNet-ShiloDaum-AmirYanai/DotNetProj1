using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DALException : Exception
    {
        public DALException() { }
    }
    public class DALExceptionIdalreadyExist : DALException
    {
        public DALExceptionIdalreadyExist() { }
    }
    public class DALExceptionIdDoesnotexist : DALException
    {
        public DALExceptionIdDoesnotexist() { }
    }
    public class DALExceptionHUDoesnotexist : DALException
    {
        public DALExceptionHUDoesnotexist() { }
    }
    public class DALExceptionInValidKey : DALException
    {
        public DALExceptionInValidKey() { }
    }
    public class DALExceptionHostingUnitDoesNotExist : DALException
    {
        public DALExceptionHostingUnitDoesNotExist() { }
    }
}