using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Guest
    {
        /// <summary>
        /// guest first and last name
        /// guest's email
        /// guest's ID=primary key
        /// </summary>
        public string FirstName {  set; get; }
        public string LastName {  set; get; }
        public string Email {  set; get; }
        public int ID {  set; get; }

    }
}
