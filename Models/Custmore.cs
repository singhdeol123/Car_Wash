using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Wash.Models
{
    public class Custmore
    {
        [Key]
        // Customer id
        public int Id { get; set; }

        // customer name
        public string Name { get; set; }

        // customer Ph no.
        public int Phone { get; set; }
    }
}
