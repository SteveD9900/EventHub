using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PracticeProject.Models;
using PracticeProject.ViewModels;

namespace PracticeProject.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var events = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Event)
                .Include(g => g.Artist)
                .Include(g => g.Type)
                .ToList();

            var viewModel = new EventsViewModel()
            {
                UpcomingEvents = events,
                Heading = "Events I'm Attending"
            };
            return View(viewModel);
        }


        // GET: Events
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                Types = _context.ETypes.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Types = _context.ETypes.ToList();
                return View("Create", viewModel);
            }

            var artistId = User.Identity.GetUserId();
            var artist = _context.Users.Single(u => u.Id == artistId);

            var type = _context.ETypes.Single(g => g.Id == viewModel.EventType);

            var aevent = new Event
            {
                Artist = artist,
                Datetime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                Type = type,
                Venue = viewModel.Venue
            };

            _context.Events.Add(aevent);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}