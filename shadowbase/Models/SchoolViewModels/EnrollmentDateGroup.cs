using System;
using System.ComponentModel.DataAnnotations;

namespace shadowbase.Models.SchoolViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? BidDate { get; set; }

        public int ClientCount { get; set; }
    }
}