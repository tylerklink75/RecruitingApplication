﻿using Recruiting.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Models.ScoutModels
{
   public class ScoutEdit
    {
        [Display(Name = "Scout's Id")]
        public int ScoutId { get; set; }
        [Display(Name = "Scouts First Name")]

        public string FirstName { get; set; }

        [Display(Name = "Scouts Last Name")]

        public string LastName { get; set; }
        [Display(Name ="Recruiting Region")]
        public RegionRecruiting RegionRecruiting { get; set; }
        [Display(Name ="Recruit they are Scouting")]
        public int RecruitId { get; set; }
        public virtual Recruit Recruit { get; set; }
    }
}
