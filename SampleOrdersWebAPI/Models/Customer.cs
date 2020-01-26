using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.Models
{
    [Table("Customers")]
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        [Email]
        public string Email { get; set; }

        //public Order[] Orders { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
