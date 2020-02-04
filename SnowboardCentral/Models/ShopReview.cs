using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SnowboardCentral.Models
{
    public class ShopReview
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public int ShopId { get; set; }
        public int Rating { get; set; }

        [Display(Name = "Username")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Review")]
        public string DetailReview { get; set; }
    }
}
