using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class CardItem
    {
        public int Id { get; set; }
        public int Quntity { get; set; }
        public int TotalCost { get; set; }
        // one to one with customer 
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
