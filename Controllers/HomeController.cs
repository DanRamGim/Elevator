using Elevator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Elevator.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index(HomeModel home)
        {
            home.CurrentFloor = 1;
            return View(home);
        }

        public IActionResult BetweenFloors(HomeModel home)
        {
            return View(home);
        }
        public IActionResult InsideElevator(HomeModel home)
        {
            return View(home);
        }
        public IActionResult LastFloor(HomeModel home)
        {
            return View(home);
        }


        [HttpPost]
        public IActionResult EnterElevator(HomeModel home)
        {

            return this.RedirectToAction("InsideElevator", home);
        }

        [HttpPost]
        public IActionResult GetOut(HomeModel elevator)

        {
            if (elevator.SelectedFloor >= 1 && elevator.SelectedFloor <= 5)
            {
                elevator.CurrentFloor = elevator.SelectedFloor;
            }
            
            if (elevator.SelectedFloor == 1)
            {
                return this.RedirectToAction("Index", elevator);
            }
            else if (elevator.SelectedFloor > 1 && elevator.SelectedFloor < 5)
            { 
                return this.RedirectToAction("BetweenFloors", elevator);
            }
            else if (elevator.SelectedFloor == 5)
            {
                return this.RedirectToAction("LastFloor", elevator);
            }
            else
            {
                return this.RedirectToAction("InsideElevator", elevator);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
