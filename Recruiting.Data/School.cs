using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Data
{
    public enum Region { Midwest, West, East, South,}
   public class School
    {

        [Key]
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Region Region { get; set; }

    }
}
