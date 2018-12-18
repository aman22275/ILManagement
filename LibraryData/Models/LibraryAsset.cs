using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class LibraryAsset
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Status Status { get; set; }
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
        public int NumberOfCopies { get; set; }

        //Create sort of foreign keys between LibraryBranch AND LibraryAsset
        public virtual LibraryBranch Location { get; set; }
    }
}
