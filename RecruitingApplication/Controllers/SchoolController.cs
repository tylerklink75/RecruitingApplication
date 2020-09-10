using Microsoft.AspNet.Identity;
using Recruiting.Models.SchoolModels;
using Recruiting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitingApplication.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index(string sortingOrder)
        {
            var UserID = Guid.Parse(User.Identity.GetUserId());
            var service = new SchoolService(UserID);
            ViewBag.SortingSchoolName = string.IsNullOrEmpty(sortingOrder) ? "SchoolName" : "";
            ViewBag.SortingCity = string.IsNullOrEmpty(sortingOrder) ? "City" : "";
            ViewBag.SortingState = string.IsNullOrEmpty(sortingOrder) ? "State" : "";
           
            var schools = from school in service.GetAllSchools() select school;
            switch (sortingOrder)
            {
                case "SchoolName":
                    schools = schools.OrderBy(school => school.SchoolName);
                    break;
                case "City":
                    schools = schools.OrderBy(school => school.City);
                    break;
                case "State":
                    schools = schools.OrderBy(school => school.State);
                    break;
               
                    
            }
            return View(schools.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateSchoolService();
            if (service.CreateSchool(model))
            {
                TempData["SaveResult"] = "This school was added successfully, good luck on your journey";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "There was an issue with this school");
            return View(model);
        }
        
        [Route("id")]
        public ActionResult Details(int id)
        {
            var svc = CreateSchoolService();
            var model = svc.GetSchoolById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateSchoolService();
            var detail = service.GetSchoolById(id);
            var model =
                new SchoolEdit
                {
                    SchoolId = detail.SchoolId,
                    SchoolName = detail.SchoolName,
                    City = detail.City,
                    State = detail.State,
                   
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int  id, SchoolEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.SchoolId != id)
            {
                ModelState.AddModelError("", "this id does not match a school please enter the correct one");
                return View(model);
            }
            var service = CreateSchoolService();
            if (service.UpdateSchool(model))
            {
                TempData["save result"] = "your school was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "school can not be updated");
            return View(model);

        }
        public ActionResult Delete(int  id)
        {
            var svc = CreateSchoolService();
            var model = svc.GetSchoolById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSchool(int id)
        {
            var service = CreateSchoolService();
            service.DeleteSchool(id);
            TempData["save"] = "school was removed";
            return RedirectToAction("index");
        }
        private SchoolService CreateSchoolService()
        {
            var UserID = Guid.Parse(User.Identity.GetUserId());
            var service = new SchoolService(UserID);
            return service;
        }


    }
   
}