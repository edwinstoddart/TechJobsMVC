﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.searchType = "all";
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;

            if (String.IsNullOrWhiteSpace(searchTerm))
            {
                ViewBag.title = "All Jobs";
                jobs = JobData.FindAll();

                ViewBag.searchType = "all";
            } else {
                ViewBag.title = $"Jobs With {searchType}: {searchTerm}";
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.searchType = searchType;
            }
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;

            return View("Index", searchType);
        }
    }
}
