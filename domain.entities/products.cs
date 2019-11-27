using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain.entities
{
    public class products : baseentity<Guid?> 
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "PriceWithTax is required")]
        public decimal? PriceWithTax { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }
}
