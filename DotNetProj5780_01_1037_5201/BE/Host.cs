using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Host
    {
        /// <summary>
        /// host identifying key
        /// host's first and last name
        /// host's key number- string to include 0 at start or special chars
        /// host's email address
        /// Bank account details
        /// is the bank account reeady to use
        /// </summary>
        public int HostKey { private set; get; }
        public string FirstName { private set; get; }
        public string LastName { private set; get; }
        public string PhoneNumber { private set; get; }
        public string Email { private set; get; }
        public BankAccount Account { private set; get; }
        public bool CollectionClearance { private set; get; }

        public override string ToString()
        {
            string host = "";

            //ToDo

            return host;
        }

    }
}
