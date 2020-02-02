using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationLayer.Models.Offices
{
    public class CreateOfficeViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        [Required]
        public bool Headquarters { get; set; }
        public int CompanyID { get; set; }
        public List<SelectListItem> Companies { get; set; } = new List<SelectListItem>();
    }
}
