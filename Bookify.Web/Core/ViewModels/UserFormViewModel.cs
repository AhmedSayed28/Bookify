using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookify.Web.Core.ViewModels
{
    public class UserFormViewModel
    {
        public string Id { get; set; } = null!;

        [MaxLength(20,ErrorMessage = Errors.MaxLength)]
        public string UserName { get; set; } = null!;

        [MaxLength(50, ErrorMessage = Errors.MaxLength) , Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;

        [MaxLength(100, ErrorMessage = Errors.MaxLength), Display(Name = "Email Adress"), EmailAddress]
        public string Email { get; set; } = null!;
        public bool EmailConfirmed { get; set; }

        [StringLength(100, ErrorMessage = Errors.MaxMinLength, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = Errors.ConfirmPasswordNotMatch)]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Roles")]
        public IList<string> SelectedRoles { get; set; } = new List<string>(); // which selected
        public IEnumerable<SelectListItem>? Roles { get; set; } // represent all roles in dropDown List
    }
}
