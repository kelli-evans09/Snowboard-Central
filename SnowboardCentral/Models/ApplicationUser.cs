using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SnowboardCentral.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Username")]
        public string NewUserName { get; set; }

        [Required]
        [Display(Name = "Height (inches)")]
        public int Height { get; set; }

        [Required]
        [Display(Name = "Weight (lbs)")]
        public int Weight { get; set; }

        [Required]
        [Display(Name = "Experience Level")]
        public int ExperienceLevelId { get; set; }

        public ExperienceLevel Level { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        public List<ShopReview> ShopReviews { get; set; }

        public List<ResortReview> ResortReviews { get; set; }

        public List<FavoriteShop> FavoriteShops { get; set; }

        //public List<FavoriteResort> FavoriteResorts { get; set; }
    }
}
