using Recruiting.Data;
using Recruiting.Models.Coach_Models;
using RecruitingApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Services
{
    public class CoachService
    {
        private readonly Guid _userID;
        public CoachService(Guid userId)
        {
            _userID = userId;
        }
        public CoachService()
        {

        }
        public bool CreateCoach(CoachCreate model)
        {
            var entity =
                new Coaches
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PositionCoach = model.PositionCoach,


                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Coaches.Add(entity);
                return ctx.SaveChanges() == 1;
                    
            }
        }
        
        public IEnumerable<CoachListItem> GetAllCoaches()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Coaches
                    .Select(
                        e =>
                        new CoachListItem
                        {
                            CoachId = e.CoachId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            PositionCoach = e.PositionCoach
                        });
                return query.ToArray();

            }
        }
        public CoachDetail GetCoachById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Coaches
                    .Single(e => e.CoachId == id);
                return
                new CoachDetail
                {
                    CoachId = entity.CoachId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    PositionCoach = entity.PositionCoach,
                    AreRecruting = entity.AreRecruiting

                };
            }
        }
        public bool UpdateCoach (CoachEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Coaches
                    .Single(e => e.CoachId == model.CoachId);
                entity.CoachId = model.CoachId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.PositionCoach = model.PositionCoach;
                entity.AreRecruiting = model.AreRecruting;
                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteCoach(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Coaches
                    .Single(e => e.CoachId == id);
                ctx.Coaches.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        
        
    }
    
        
}
