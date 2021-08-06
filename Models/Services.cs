using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Wash.Models
{
    public class Services
    {
        [Key]
        // service id
        public int Id { get; set; }

        // detail of services display here
        public string TypeofServices { get; set; }

        // Price of service provider
        public int Price { get; set; }
       
    }
}
