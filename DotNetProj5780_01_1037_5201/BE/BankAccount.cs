using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class BankAccount
    {
        /// <summary>
        /// number and name of bank
        /// number and name of bank branch
        /// branch city
        /// the personal account number
        /// </summary>
        public int BankNumber {private set; get; }
        public string BankName { private set; get; }
        public int BranchNumber { private set; get; }
        public string BranchAddress { private set; get; }
        public string BranchCity { private set; get; }
        public int BankAccountNumber { private set; get; }

        public override string ToString()
        {
            string bankAccount = "";

            //ToDo

            return bankAccount;
        }

    }
}
