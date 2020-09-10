using Recruiting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Models.SchoolModels
{
 public class SchoolCreate
    {
        [Required]
        [Display(Name = "High School Name")]
        public string SchoolName { get; set; }
        [Required]
        [Display(Name ="City")]
        [MinLength(2,ErrorMessage ="please enter the full city name")]
        [MaxLength(150,ErrorMessage ="the city name appears to be too long")]
        public string City{ get; set; }
        [Required]
        [Display(Name ="Region Located")]
        public Region Region { get; set; }

        public string State { get; set; }
        

    }
}
