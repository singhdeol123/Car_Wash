using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Wash.Models
{
    public class Booking
    {
        [Key]
        // Booking ID
        public int ID { get; set; }

        //Booking Date
        public DateTime Date { get; set; }

        // Service Id
        public int ServiceId { get; set; }

        // customer Id
        public int CustomerId { get; set; }

        //Services link
        public Services Services { get; set; }
        //Customer link
        public Custmore Custmore { get; set; }
    }
}
