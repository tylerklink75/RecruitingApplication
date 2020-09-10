using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Models.Coach_Models
{
    public class CoachCreate
    {
        [Required]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "please enter the coaches First Name")]
        [MaxLength(100, ErrorMessage = "Is that the coaches Name?")]

        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage = "please enter the full Last Name for the coach")]
        [MaxLength(100, ErrorMessage = "is that the coaches Last Name?")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Coaching Position")]
        public string PositionCoach { get; set; }


    }
}
