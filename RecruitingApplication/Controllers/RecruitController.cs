using Microsoft.AspNet.Identity;
using Recruiting.Data;
using Recruiting.Models.Coach_Models;
using Recruiting.Models.RecruitModels;
using Recruiting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitingApplication.Controllers
{
    public class RecruitController : Controller
    {
        // GET: Recruit
        public ActionResult Index()
        {
            var UserID = Guid.Parse(User.Identity.GetUserId());
            var service = new RecruitService(UserID);
            var model = service.GetAllRecruits();
            return View(model);
            
        }
        public ActionResult Create()
        {
            List<School> Schools = (new SchoolService()).GetSchools().ToList();
            var query = from s in Schools
                        select new SelectListItem()
                        {
                            Value = s.SchoolId.ToString(),
                            Text = s.SchoolName

                        };
            ViewBag.SchoolId = query.ToList();
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecruitCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateRecruitService();
            if (service.CreateRecruit(model))
            {
                TempData["saveresults"] = "your recruit was added, hope you get him";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "there was an error with this prospect");
            return View(model);
        }


       
        [Route("id")]
        public ActionResult Details(int id)
        {
            var svc = CreateRecruitService();
            var model = svc.GetRecruitById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateRecruitService();
            List<School> Schools = (new SchoolService()).GetSchools().ToList();
            var query = from s in Schools
                        select new SelectListItem()
                        {
                            Value = s.SchoolId.ToString(),
                            Text = s.SchoolName

                        };
            ViewBag.SchoolId = query.ToList();
            var detail = service.GetRecruitById(id);
            var model =
                new RecruitEdit
                {
                    RecruitId = detail.RecruitId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Position = detail.Position,
                    School = detail.School,
                    GraduationDate = detail.GraduationDate,
                    IsOfferedScholarship = detail.IsOfferedScholarship,
                    StarRating = detail.StarRating,
                    Weaknesses = detail.Weaknesses,
                    Strengths = detail.Strengths

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecruitEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RecruitId != id)
            {
                ModelState.AddModelError("", "your recruit can not be added");
                return View(model);
            }
            var service = CreateRecruitService();
            if (service.UpdateRecruit(model))
            {
                TempData["saveresult"] = "your recruit has been updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "prospect was not updated");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateRecruitService();
            var model = svc.GetRecruitById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecruit(int id)
        {
            var service = CreateRecruitService();
            service.DeleteRecruit(id);
            TempData["SaveResult"] = "are you sure you want to remove this recruit";
            return RedirectToAction("index");
        }
        private RecruitService CreateRecruitService()
        {
            var UserID = Guid.Parse(User.Identity.GetUserId());
            var service = new RecruitService(UserID);
            return service;
        }
    }
}