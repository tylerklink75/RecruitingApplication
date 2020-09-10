using Recruiting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Models.SchoolModels
{
    public class SchoolDetail
    {
        [Display(Name = "School Id")]
        public int SchoolId { get; set; }
        [Display(Name = "High School")]
        public string SchoolName { get; set; }
        [Display(Name = "School's Region")]
        public Region Region { get; set; }
        [Display(Name ="City")]
        public string City { get; set; }
        [Display(Name ="State")]
        public string State { get; set; }
    }
}
