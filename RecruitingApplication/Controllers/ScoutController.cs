using Microsoft.AspNet.Identity;
using Recruiting.Data;
using Recruiting.Models.ScoutModels;
using Recruiting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitingApplication.Controllers
{
    public class ScoutController : Controller
    {
        // GET: Scout
        public ActionResult Index()
        {
            var UserID = Guid.Parse(User.Identity.GetUserId());
            var service = new ScoutService(UserID);
            var model = service.GetAllScouts();
            return View(model);
        }
        public ActionResult Create()
        {
            ViewBag.Title = "new Scout";
            List<Recruit> Recruits = (new RecruitService()).GetRecruits().ToList();
            var query = from r in Recruits
                        select new SelectListItem()
                        {
                            Value = r.RecruitId.ToString(),
                            Text = r.LastName
                        };
           ViewBag.RecruitId= query.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScoutCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateScoutService();
            if (service.CreateScout(model))
            {
                TempData["saveresult"] = "scout was added";
                return RedirectToAction("index");
            }
            ModelState.AddModelError("", "there was an issue with the scout");
            return View(model);
        }


        [Route("id")]
        public ActionResult Details (int id)
        {
            var svc = CreateScoutService();
            var model = svc.GetScoutById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {


            var service = CreateScoutService();
            List<Recruit> Recruits = (new RecruitService()).GetRecruits().ToList();
            var query = from r in Recruits
                        select new SelectListItem()
                        {
                            Value = r.RecruitId.ToString(),
                            Text = r.LastName
                        };
            ViewBag.RecruitId = query.ToList();
            

            var detail = service.GetScoutById(id);
            var model =
                new ScoutEdit
                {
                    ScoutId = detail.ScoutId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    RegionRecruiting = detail.RegionRecruiting,
                    Recruit = detail.Recruit

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ScoutEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ScoutId != id)
            {
                ModelState.AddModelError("", "This does not match");
                return View(model);
            }
            var service = CreateScoutService();
            if (service.UpdateScouts(model))
            {
                TempData["saveresult"] = "scout was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "scout cant be changed");
            return View(model);
        }
        public ActionResult Delete (int id)
        {
            var svc = CreateScoutService();
            var model = svc.GetScoutById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteScout(int id)
        {
            var service = CreateScoutService();
            service.DeleteScouts(id);
            TempData["SaveResult"] = "scout was fired";
            return RedirectToAction("Index");

        }

        private ScoutService CreateScoutService()
        {
            var UserID = Guid.Parse(User.Identity.GetUserId());
            var service = new ScoutService(UserID);
            return service;

        }
    }
}