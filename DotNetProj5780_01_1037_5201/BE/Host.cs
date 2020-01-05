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
        /// Bank accoount number
        /// is the bank account reeady to use
        /// </summary>
        public int HostKey {  set; get; }
        public string FirstName {  set; get; }
        public string LastName {  set; get; }
        public string PhoneNumber {  set; get; }
        public string Email {  set; get; }
        public BankAccount BankBranchDetails {  set; get; }
        public int AccountNumber {  set; get; }
        public bool CollectionClearance {  set; get; }

        public override string ToString()
        {
            string host = "";

            //ToDo

            return host;
        }

    }
}
