using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Models.Coach_Models
{
  public class CoachListItem
    {
        [Display(Name ="coach Id")]
        public int CoachId { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Display(Name ="Coaching Position")]
        public string PositionCoach { get; set; }
    }
}
