using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public int PhoneNumber { get; set; }
        //one to one 
        public Payment payment { get; set; }
        public CardItem CardItems { get; set; }
    }
}
