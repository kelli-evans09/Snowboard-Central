using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowboardCentral.Models.ViewModels
{
    public class ShopReviewViewModel
    {
        public List<Shop> Shops { get; set; }
        public Shop Shop { get; set; }

        public List<ShopReview> Reviews { get; set; }
        public ShopReview ShopReviews { get; set; }



    }
}
