using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SnowboardCentral.Models
{
    public class Resort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Monday - Friday")]
        public string WeekdayHours { get; set; }

        [Display(Name = "Saturday - Sunday")]
        public string WeekendHours { get; set; }
        public string Description { get; set; }
        public bool Lodging { get; set; }
        public bool RentEquipment { get; set; }
        public string Url { get; set; }
        public string? UrlImage { get; set; }
        public string Reviews { get; set; }

        [Display(Name = "Base Price")]
        public double DailyCost { get; set; }
        public List<ResortReview> ResortReviews { get; set; }
    }
}
