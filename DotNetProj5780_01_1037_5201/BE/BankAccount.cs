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
        public int BankNumber { set; get; }
        public string BankName {  set; get; }
        public int BranchNumber {  set; get; }
        public string BranchAddress {  set; get; }
        public string BranchCity {  set; get; }
        public int BankAccountNumber {  set; get; }

        public override string ToString()
        {
            string bankAccount = "";

            //ToDo

            return bankAccount;
        }

    }
}
