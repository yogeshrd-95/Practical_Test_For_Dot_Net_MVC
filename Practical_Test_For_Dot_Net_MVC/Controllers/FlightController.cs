using Practical_Test_For_Dot_Net_MVC.Models;
using Practical_Test_For_Dot_Net_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_Test_For_Dot_Net_MVC.Controllers
{
    public class FlightController : Controller
    {
        
        private readonly FlightRepository flightRepository;

        public FlightController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            flightRepository = new FlightRepository(connectionString);
        }
        // GET: Flight
        public ActionResult Index()
        {
            List<Flight> flights = flightRepository.GetFlights();
            return View(flights);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Create a new flight
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                flightRepository.CreateFlight(flight);
                return RedirectToAction("Index");
            }

            return View(flight);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var flight = flightRepository.GetFlightById(id);
            return View(flight);
        }

        // Update flight
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Flight flight)
        {
            if (ModelState.IsValid)
            {
                flightRepository.UpdateFlight(flight);
                return RedirectToAction("Index");
            }

            return View(flight);
        }

        // Delete a flight
        public ActionResult Delete(int Id)
        {
            try
            {
                flightRepository.DeleteFlight(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }
}