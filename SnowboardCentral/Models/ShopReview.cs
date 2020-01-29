using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowboardCentral.Models
{
    public class ShopReview
    {
        public int Id { get; set; }
        public Shop Shop { get; set; }
        public int ShopId { get; set; }
        public int Rating { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public string DetailReview { get; set; }
    }
}
