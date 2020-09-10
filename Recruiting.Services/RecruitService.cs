using Recruiting.Data;
using Recruiting.Models.Coach_Models;
using Recruiting.Models.RecruitModels;
using RecruitingApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Services
{
    public class RecruitService
    {
        private readonly Guid _userId;
        public RecruitService(Guid userId)
        {
            _userId = userId;
        }
        public RecruitService()
        {

        }
        public bool CreateRecruit(RecruitCreate model)
        {
            var entity =
                new Recruit()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    School = model.School,
                    GraduationDate = model.GraduationDate,
                    StarRating = model.StarRating,
                    Position = model.Position,
                    Strengths = model.Strengths,
                    Weaknesses = model.Weaknesses,
                    IsOfferedScholarship = model.IsOfferedScholarship,
                    Comments = model.Comments,
                    SchoolId = model.SchoolId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recruits.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RecruitListItem> GetAllRecruits()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Recruits
                    .Select(
                        e =>
                        new RecruitListItem
                        {
                            RecruitId = e.RecruitId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            GraduationDate = e.GraduationDate,
                            Position = e.Position,
                            School = e.School,
                            StarRating = e.StarRating,
                            Strengths = e.Strengths,
                            Weaknesses = e.Weaknesses,
                            IsOfferedScholarship = e.IsOfferedScholarship,
                            SchoolId = e.SchoolId,



                        });
                return query.ToArray();
            }
        }
        public RecruitDetail GetRecruitbyLastName(string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recruits
                    .Single(e => e.LastName == lastName);
                return new RecruitDetail()
                {
                    RecruitId = entity.RecruitId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    School = entity.School,
                    Position = entity.Position,
                    GraduationDate = entity.GraduationDate,
                    StarRating = entity.StarRating,
                    IsOfferedScholarship = entity.IsOfferedScholarship
                };
            }
        }
        public IEnumerable<Recruit> GetRecruits()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Recruits.ToList();
            }
        }
        public RecruitDetail GetRecruitByPosition(string position)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recruits
                    .Single(e => e.Position == position);
                return new RecruitDetail()
                {
                    RecruitId = entity.RecruitId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    School = entity.School,
                    Position = entity.Position,
                    GraduationDate = entity.GraduationDate,
                    StarRating = entity.StarRating,
                    IsOfferedScholarship = entity.IsOfferedScholarship
                };
            }

        }
        public RecruitDetail GetRecruitById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recruits
                    .Single(e => e.RecruitId == id);
                    return new RecruitDetail
                    {
                        RecruitId = entity.RecruitId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        School = entity.School,
                        Position = entity.Position,
                        GraduationDate = entity.GraduationDate,
                        StarRating = entity.StarRating,
                        IsOfferedScholarship = entity.IsOfferedScholarship
                    };
            }
        }
        public RecruitDetail GetRecruitByGraduation(string graduationDate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recruits
                   .Single(e => e.GraduationDate == graduationDate);
                return new RecruitDetail()
                {
                    RecruitId = entity.RecruitId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    School = entity.School,
                    Position = entity.Position,
                    GraduationDate = entity.GraduationDate,
                    StarRating = entity.StarRating,
                    IsOfferedScholarship = entity.IsOfferedScholarship
                };
            }
        }
        public bool UpdateRecruit(RecruitEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recruits
                    .Single(e => e.RecruitId == model.RecruitId);
                entity.RecruitId = model.RecruitId;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Position = model.Position;
                entity.School = model.School;
                entity.StarRating = model.StarRating;
                entity.Strengths = model.Strengths;
                entity.GraduationDate = model.GraduationDate;
                entity.Weaknesses = model.Weaknesses;
                entity.IsOfferedScholarship = model.IsOfferedScholarship;
                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteRecruit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Recruits
                    .Single(e => e.RecruitId == id);
                ctx.Recruits.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
