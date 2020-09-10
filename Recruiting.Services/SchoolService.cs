using Recruiting.Data;
using Recruiting.Models.SchoolModels;
using RecruitingApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Services
{
  public class SchoolService
    {
        private readonly Guid _userID;
        public SchoolService(Guid userId)
        {
            _userID = userId;
        }
        public SchoolService()
        {

        }
        public bool CreateSchool(SchoolCreate model)
        {
            var entity =
                new School()
                {
                    SchoolName = model.SchoolName,
                    City = model.City,
                    State = model.State,
                    Region = model.Region
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Schools.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SchoolListItem> GetAllSchools()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Schools
                    .Select(
                        e =>
                        new SchoolListItem
                        {
                            SchoolId = e.SchoolId,
                            SchoolName = e.SchoolName,
                            City = e.City,
                            Region = e.Region,
                            State = e.State

                        });
                return query.ToArray();
            }
        }
        public SchoolDetail GetSchoolByState(string state)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Schools
                    .Single(e => e.State == state);
                return
                    new SchoolDetail
                    {
                        SchoolId = entity.SchoolId,
                        SchoolName = entity.SchoolName,
                        City = entity.City,
                        Region = entity.Region,
                        State=entity.State



                    };

            }

        }
        public IEnumerable<School> GetSchools()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Schools.ToList();
            }
        }
        public SchoolDetail GetSchoolById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Schools
                    .Single(e => e.SchoolId == id);
                return
                    new
                    SchoolDetail
                    {
                        SchoolName = entity.SchoolName,
                        SchoolId = entity.SchoolId,
                        City = entity.City,
                        State = entity.State,
                        Region = entity.Region
                    };
            }
        }

        public SchoolDetail GetSchoolByName(string schoolName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Schools
                    .Single(e => e.SchoolName == schoolName);
                return
                    new
                    SchoolDetail
                    {
                        SchoolName = entity.SchoolName,
                        SchoolId = entity.SchoolId,
                        City = entity.City,
                        State = entity.State,
                        Region = entity.Region
                    };
            }
        }
        public bool UpdateSchool(SchoolEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Schools
                    .Single(e => e.SchoolId == model.SchoolId);
                entity.SchoolId = model.SchoolId;
                entity.SchoolName = model.SchoolName;
                entity.City = model.City;
                entity.State = model.State;
                entity.Region = model.Region;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSchool(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Schools
                    .Single(e => e.SchoolId == id);
                ctx.Schools.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
       
    }
}
