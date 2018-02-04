using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        [HttpGet]
        [Route("/Search/Results")]
        public IActionResult SearchResults(string searchType, string searchTerm)
        {
            //should take in 2 parameters, specifying the type of search and 
            //the search term. Need to name params appropriately based on form
            //field names
            ViewBag.columns = ListController.columnChoices;

            if (searchTerm == null)
            {
                ViewBag.jobs = JobData.FindAll();
            }

            else if (searchType == "all")
            {
                ViewBag.jobs = JobData.FindByValue(searchTerm);
            }

            else
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            return View("Views/Search/Index.cshtml");
        }
    }
}
