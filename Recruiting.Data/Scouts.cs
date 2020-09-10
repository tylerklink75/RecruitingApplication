using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Recruiting.Data
{
    public enum RegionRecruiting { Midwest,South,East,West}
    public class Scouts
    {
        [Key]
        public int ScoutId { get; set; }
        public RegionRecruiting RegionRecruiting { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RecruitId { get; set; }
        [ForeignKey(nameof(RecruitId))]
        public virtual Recruit Recruit { get; set; }
        
    }
}
