using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_19.Interfaces;
using Project_19.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project_19.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<Person> people;

        public HomeController(IPersonCollection personCollection)
        {
            people = personCollection.Persons;
        }

        public IActionResult Index()
        {
            return View(people);
        }



        public IActionResult Privacy(string id)
        {
            int intID = int.Parse(id);
            var person = people.Where(x => x.ID == intID).SingleOrDefault();
            return View(person);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
