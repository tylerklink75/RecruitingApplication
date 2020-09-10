using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Models.Coach_Models
{
    public class CoachDetail
    {
        public int CoachId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionCoach { get; set; }
        public bool AreRecruting { get; set; }

    }
}
