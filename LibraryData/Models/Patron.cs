using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class Patron
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String TelephoneNumber { get; set; }

        //Patrons will have some other objects which used as foreign key. 
        //Such as Library Card.
        //##Foreign Key
        /*
         * Virtual is used for lazy load that property data.
        Lazy loading loads a collection from database first time it accessed.
        */

        public virtual LibraryCard LibraryCard { get; set; }
        public virtual LibraryBranch HomeLibraryBranch { get; set; }
    }
}
