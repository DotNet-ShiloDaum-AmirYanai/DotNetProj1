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
        public string FirstName { private set; get; }
        public string LastName { private set; get; }
        public string Email { private set; get; }
        public int ID { private set; get; }

    }
}
