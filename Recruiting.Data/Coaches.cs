using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Data
{
   public  class Coaches
    {
        [Key]
        public int CoachId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionCoach { get; set; }
        public bool AreRecruiting { get; set; }
    }
}
