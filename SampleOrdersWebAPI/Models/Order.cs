using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrdersWebAPI.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        
        public float Price { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}
