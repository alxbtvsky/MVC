﻿using HDL.Models;
using HDL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HDL.Controllers
{
    public class ProfileController : Controller
    {
        ProfileService profileService = new ProfileService();

        // GET: Profile
        public ActionResult Index()
        {
            return View(profileService.ListAll());
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            HDL.Models.Profile profile = profileService.Get(id);
            return View(profile);
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View(profileService.Get(id));
        }

        // POST: Profile/Edit/5
        [HttpPost]
        //public ActionResult Create([Bind(Include = "StudentID,Name,Email,Age,Address,City,Zip,State")] Student student)
        public ActionResult Edit([Bind(Include = "ProfileID, Name,Bio,Picture")]Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = profile.ProfileID });
            }
            try
            {
                profileService.Update(profile);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/AddDog/5
        public ActionResult CreateHotdog(int id)
        {
            ViewBag.profileID = id;
            return View();
        }

        // POST: Profile/EditDog/5
        [HttpPost]
        //public ActionResult Create([Bind(Include = "StudentID,Name,Email,Age,Address,City,Zip,State")] Student student)
        public ActionResult AddHotdog(int profileID, [Bind(Include = "HotDogName,LastTimeAte,LastPlaceAte,Rating")]Hotdogs dog)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.error = "Please check your form and resubmit";
                return RedirectToAction("CreateDog");
            }
            try
            {
                profileService.AddDog(new Profile() { ProfileID = profileID }, dog);
                return RedirectToAction("Details", new { id = profileID });
            }
            catch
            {
                return View();
            }
        }


    }
}
