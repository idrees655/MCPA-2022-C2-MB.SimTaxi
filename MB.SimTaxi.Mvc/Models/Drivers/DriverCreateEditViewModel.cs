using MB.SimTaxi.Utils.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MB.SimTaxi.Mvc.Models.Drivers
{
    public class DriverCreateEditViewModel
    {
        public int Id { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
