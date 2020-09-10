using Microsoft.AspNet.Identity;
using Recruiting.Models.Coach_Models;
using Recruiting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitingApplication.Controllers
{
    public class CoachController : Controller
    {
        // GET: Coach
        public ActionResult Index()
        {
            var UserID = Guid.Parse(User.Identity.GetUserId());
            var service = new CoachService(UserID);
            var model = service.GetAllCoaches();
            
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (CoachCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateCoachService();
            if (service.CreateCoach(model))
            {
                TempData["SaveResult"] = "your coach was added to the staff";
                return RedirectToAction("Index"); 
            };
            return View(model);
        }
        [Route("id")]
        public ActionResult Details(int id)
        {
            var svc = CreateCoachService();
            var model = svc.GetCoachById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateCoachService();
            var detail = service.GetCoachById(id);
            var model =
                new CoachEdit
                {
                    CoachId=detail.CoachId,
                   FirstName=detail.FirstName,
                   LastName=detail.LastName,
                   PositionCoach=detail.PositionCoach,
                   AreRecruting=detail.AreRecruting

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CoachEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.CoachId != id)
            {
                ModelState.AddModelError("", "this id does not match a school please enter the correct one");
                return View(model);
            }
            var service = CreateCoachService();
            if (service.UpdateCoach(model))
            {
                TempData["save result"] = "your school was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "school can not be updated");
            return View(model);

        }
        public ActionResult Delete(int id)
        {
            var svc = CreateCoachService();
            var model = svc.GetCoachById(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CoachDetail model)
        {
            var service = CreateCoachService();
            service.DeleteCoach(id);
            TempData["Save Result"] = "your coach was fired";
            return RedirectToAction("Index");
               

                
        }




        private CoachService CreateCoachService()
        {
            var UserID = Guid.Parse(User.Identity.GetUserId());
            var service = new CoachService(UserID);
            return service;
        }
    }
    
}