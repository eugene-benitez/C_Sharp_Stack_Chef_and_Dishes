using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Chef_And_Dishes.Models;

namespace Chef_And_Dishes.Controllers
{
    public class HomeController : Controller
    {

        private MyContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            List<Chef> AllChef = dbContext.Chefs
            .Include(c => c.CreatedDishes)
            .ToList();
            return View(AllChef);
        }


        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            List<Chef> AllChef = dbContext.Chefs.ToList();
            @ViewBag.AllChef = AllChef;
            return View();
        }

        [HttpPost("dishes/addDish")]
        public IActionResult AddDish(Dish nDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(nDish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }

            return View("NewChef");
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDish = dbContext.Dishs
            .Include(d => d.Creator)
            .ToList();
            ViewBag.AllDishes = AllDish;
            return View(AllDish);
        }

        [HttpPost("addChef")]
        public IActionResult addChef(Chef nChef)
        {
            if (ModelState.IsValid)
            {
                DateTime dateOfBirth;
                string date = nChef.DOB.ToString("MM/dd/yyyy");
                DateTime.TryParse(date, out dateOfBirth);
                DateTime currentDate = DateTime.Now;

                TimeSpan difference = currentDate.Subtract(dateOfBirth);

                DateTime age = DateTime.MinValue + difference;

                int ageInYears = age.Year - 1;
                int ageInMonths = age.Month - 1;
                int ageInDays = age.Day - 1;

                if (ageInYears > 18)
                {
                    nChef.Age = ageInYears;
                    dbContext.Add(nChef);
                    dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }

                else
                {

                    return View("NewChef");
                }

            }
            return View("NewChef");
        }








        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
