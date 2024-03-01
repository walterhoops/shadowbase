using System;
using System.ComponentModel.DataAnnotations;

namespace shadowbase.Models.SchoolViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? CreationDate { get; set; }

        public int AuctionCount { get; set; }
    }
}