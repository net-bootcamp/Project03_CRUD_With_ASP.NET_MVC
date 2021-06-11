using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class Furniture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        //many to one category
        public int Category { get; set; }
        public Category Categoris { get; set; }
    }
}
