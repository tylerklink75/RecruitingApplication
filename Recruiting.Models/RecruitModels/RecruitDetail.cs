using Recruiting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Models.RecruitModels
{
  public class RecruitDetail
    {
        [Display(Name ="Recruit Id")]
        public int RecruitId { get; set; }
        [Display(Name ="First Name:")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Display(Name ="School:")]
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        [Display(Name ="Position")]
        public string Position { get; set; }
        [Display(Name ="Expected Graduation Year:")]
        public string GraduationDate { get; set; }
        [Display(Name =("Star rating (x.x/5.0)"))]
        public decimal StarRating { get; set; }
        [Display(Name ="Player's Strengths")]
        public string Strengths { get; set; }
        [Display(Name ="Player's Weaknesses")]
        public string Weaknesses { get; set; }
        [Display(Name ="We offered Him a Scholarship")]
        public bool IsOfferedScholarship { get; set; }
        
    }
}
