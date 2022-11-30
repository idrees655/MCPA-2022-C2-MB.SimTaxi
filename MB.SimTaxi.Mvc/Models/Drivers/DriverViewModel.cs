using MB.SimTaxi.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Mvc.Models.Drivers
{
    public class DriverViewModel
    {
        public int Id { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int Age
        {
            get
            {
                if(DateOfBirth.HasValue)
                {
                    return DateTime.Now.Year - DateOfBirth.Value.Year;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
