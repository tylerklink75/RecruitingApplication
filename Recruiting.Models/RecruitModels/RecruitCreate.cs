using Recruiting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Models.Coach_Models
{
    public class RecruitCreate
    {
        [Required]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Position:")]
        public string Position { get; set; }
        [Required]
        [Display(Name="Expected Graduation Year:")]
        public string GraduationDate { get; set; }
        [Required]
        [Display(Name ="Player Rating (x.x / 5.0)")]
        public decimal StarRating { get; set; }
        [Required]
        [Display(Name ="Players Strengths")]
        public string Strengths { get; set; }
        [Required]
        [Display(Name ="Players Weaknesses")]
        public string Weaknesses { get; set; }
        [Required]
        [Display(Name ="We offered a Scholarship")]
        public bool IsOfferedScholarship { get; set; }
        public string Comments { get; set; }
        [Display(Name ="School:")]
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}
