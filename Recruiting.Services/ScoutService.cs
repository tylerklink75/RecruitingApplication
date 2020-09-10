using Recruiting.Data;
using Recruiting.Models.SchoolModels;
using Recruiting.Models.ScoutModels;
using RecruitingApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Services
{
    public class ScoutService
    {
        private readonly Guid _userID;
        public ScoutService(Guid userId)
        {
            _userID = userId;
        }
        public ScoutService()
        {

        }
        public bool CreateScout(ScoutCreate model)
        {
            var entity =
                new Scouts()
                {
                    ScoutId = model.ScoutId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RegionRecruiting = model.RegionRecruiting,
                    RecruitId = model.RecruitId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Scouts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ScoutListItem>GetAllScouts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                {
                    var query =
                        ctx
                        .Scouts
                        .Select(
                            e =>
                            new ScoutListItem
                            {
                                ScoutId = e.ScoutId,
                                FirstName = e.FirstName,
                                LastName=e.LastName,
                                RecruitId=e.RecruitId,
                                RegionRecruiting=e.RegionRecruiting,
                                Recruit=e.Recruit,



                            });
                    return query.ToArray();
                    
                }
            }
        }
        public ScoutDetail GetScoutByName(string firstName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Scouts
                    .Single(e => e.FirstName == firstName);
                return new ScoutDetail
                {
                    ScoutId = entity.ScoutId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    RecruitId = entity.RecruitId

                };
            }
        }
        public ScoutDetail GetScoutById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Scouts
                    .Single(e => e.ScoutId == id);
                return new ScoutDetail
                {
                    ScoutId = entity.ScoutId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    RecruitId = entity.RecruitId,
                    RegionRecruiting = entity.RegionRecruiting,
                };
            }
        }
        public ScoutDetail GetScoutByLastName(string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Scouts
                    .Single(e => e.LastName == lastName);
                return new ScoutDetail
                {
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    RecruitId = entity.RecruitId,



                };
            }
        }
        public bool UpdateScouts(ScoutEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Scouts
                    .Single(e => e.ScoutId == model.ScoutId);
                entity.ScoutId = model.ScoutId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.RegionRecruiting = model.RegionRecruiting;
                entity.RecruitId = model.RecruitId;
                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteScouts(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Scouts
                    .Single(e => e.ScoutId == id);
                ctx.Scouts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
            
    
