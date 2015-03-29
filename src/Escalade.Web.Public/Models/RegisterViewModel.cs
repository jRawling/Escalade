using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System;
using Escalade.Core;

namespace Escalade.Web.Public.Models
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        { }

        public ICollection<SelectListItem> Genders { get; private set; }

        public ICollection<SelectListItem> Countries { get; private set; }

        public RegisterUserModel User { get; set; }

        public void SetDropdowns(IDictionary<int, string> countries, IDictionary<int, string> genders)
        {
            Countries = GetCountyItems(countries);
            Genders = GetGenderItems(genders);
        }

        private ICollection<SelectListItem> GetCountyItems(IDictionary<int, string> countries)
        {
            Collection<SelectListItem> countryItems = new Collection<SelectListItem>();
            countryItems.Add(new SelectListItem() { Value = "", Text = "Select Your Country", Selected = true });

            foreach (KeyValuePair<int, string> country in countries)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = country.Value;
                selectListItem.Value = country.Key.ToString();
                countryItems.Add(selectListItem);
            }

            return countryItems;
        }

        private ICollection<SelectListItem> GetGenderItems(IDictionary<int, string> genders)
        {
            Collection<SelectListItem> genderItems = new Collection<SelectListItem>();
            genderItems.Add(new SelectListItem() { Value = "", Text = "Select Your Gender", Selected = true });

            foreach (KeyValuePair<int, string> gender in genders)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = gender.Value;
                selectListItem.Value = gender.Key.ToString();
                genderItems.Add(selectListItem);
            }

            return genderItems;
        }
    }

    public class RegisterUserModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        public ApplicationUser MapToApplication()
        {
            return new ApplicationUser(Username)
            {
                Email = EmailAddress,
                FirstName = FirstName,
                LastName = LastName
            };
        }

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
        [Display(Name = "Country")]
        public Country SelectedCountry { get; set; }
    }
}