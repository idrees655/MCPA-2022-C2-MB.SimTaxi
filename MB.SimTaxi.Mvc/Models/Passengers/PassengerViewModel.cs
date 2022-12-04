using MB.SimTaxi.Utils.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Mvc.Models.Passengers
{
    public class PassengerViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }


        [Display(Name = "Full Name")]
        [ValidateNever]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
