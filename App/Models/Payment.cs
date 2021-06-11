using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public String PaymentType { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
