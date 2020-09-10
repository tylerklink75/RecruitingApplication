using Recruiting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Models.ScoutModels
{
  public class ScoutCreate
    {
        [Required]
        public int ScoutId { get; set; }
        [Required]
        [Display(Name ="Scouts First Name")]
        [MinLength(1, ErrorMessage = "please enter the name of the scout on your staff")]
        [MaxLength(50, ErrorMessage = "make sure you entered the scouts Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Scouts Last Name")]
        [MinLength(1, ErrorMessage = "please enter the name of the scout on your staff")]
        [MaxLength(50, ErrorMessage = "make sure you entered the scouts Name")]
        public string LastName { get; set; }
        [Display(Name ="Recruiting Region")]
        public RegionRecruiting RegionRecruiting { get; set; }
        public int RecruitId { get; set; }
        public virtual Recruit Recruit { get; set; }

    }
}
