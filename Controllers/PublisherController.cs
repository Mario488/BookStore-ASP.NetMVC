﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookeStore_application.Models;
using BookeStore_application.Models.Domain;
using BookeStore_application.Repositories.Abstract;

namespace YtBookStore.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService service;
        public PublisherController(IPublisherService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool result = service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured on server side";

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var record = service.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Update(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool result = service.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has occured on server side";

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            bool record = service.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return View(data);
        }


    }
}