using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Data
{
    public class Recruit
    {
        [Key]
        public int RecruitId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string GraduationDate { get; set; }
        public decimal StarRating { get; set; }
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public bool IsOfferedScholarship { get; set; }
        public string Comments { get; set; }
        public int SchoolId { get; set; }
        [ForeignKey(nameof(SchoolId))]
        public virtual School School { get; set; }
    }
}
