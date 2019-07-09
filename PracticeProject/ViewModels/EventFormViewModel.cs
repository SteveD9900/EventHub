using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PracticeProject.Models;

namespace PracticeProject.ViewModels
{
    public class EventFormViewModel
    {
        [Required]
        public string Venue { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public byte EventType { get; set; }
        public IEnumerable<TypeE> Types { get; set; }
    }
}