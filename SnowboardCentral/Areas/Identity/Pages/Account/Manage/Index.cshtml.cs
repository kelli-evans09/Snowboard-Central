using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SnowboardCentral.Models;
using SnowboardCentral.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace SnowboardCentral.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _context = context;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Username")]
            public string NewUserName { get; set; }

            [Display(Name = "Height (inches)")]
            public int Height { get; set; }

            [Display(Name = "Weight (lbs)")]
            public int Weight { get; set; }

            [Display(Name = "Experience Level")]
            public int ExperienceLevelId { get; set; }

            public ExperienceLevel Level { get; set; }

            [Display(Name = "Age")]
            public int Age { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var height = user.Height;
            var weight = user.Weight;
            var experienceLevel = user.Level;
            var age = user.Age;

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                LastName = lastName,
                Height = height,
                Weight = weight,
                Level = experienceLevel,
                Age = age

            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.Height = Input.Height;
            user.Weight = Input.Weight;
            user.ExperienceLevelId = Input.ExperienceLevelId;
            user.Age = Input.Age;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            _context.Update(user);
            await _context.SaveChangesAsync();
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
            }

            //await _signInManager.RefreshSignInAsync(user);
            //StatusMessage = "Your profile has been updated";
            //return RedirectToPage();
        }
    }
