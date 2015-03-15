using Escalade.Domain;
using Escalade.Domain.Extentions;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Escalade.Web.Public.Models
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            Countries = GetCountries();
            Genders = GetGenders();
        }

        private ICollection<SelectListItem> GetCountries()
        {
            Collection<SelectListItem> countries = new Collection<SelectListItem>();
            countries.Add(new SelectListItem() { Value = "", Text = "Select Your Country", Selected = true });

            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = country.GetName();
                selectListItem.Value = ((int)country).ToString();
                countries.Add(selectListItem);
            }

            return countries;
        }

        private ICollection<SelectListItem> GetGenders()
        {
            Collection<SelectListItem> genders = new Collection<SelectListItem>();
            genders.Add(new SelectListItem() { Value = "", Text = "Select Your Gender", Selected = true });
            genders.Add(new SelectListItem() { Value = ((int)Gender.Male).ToString(), Text = "Male"});
            genders.Add(new SelectListItem() { Value = ((int)Gender.Female).ToString(), Text = "Female" });
            genders.Add(new SelectListItem() { Value = ((int)Gender.Unspecified).ToString(), Text = "Don't want to say" });
            return genders;
        }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public Gender SelectedGender { get; set; }
        [Required]
        public ICollection<SelectListItem> Genders { get; }
        [Required]
        [Display(Name = "Country")]
        public Country SelectedCountry { get; set; }
        [Required]
        public ICollection<SelectListItem> Countries { get; }

        internal ApplicationUser CreateUser()
        {
            return new ApplicationUser(Username) { Email = EmailAddress };
        }
    }
}