using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticeProject.Models;

namespace PracticeProject.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<Event> UpcomingEvents { get; set; }
        public string Heading { get; set; }
    }
}