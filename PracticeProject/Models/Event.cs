using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeProject.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public ApplicationUser Artist { get; set; }
        [Required]
        public string ArtistId { get; set; }
        public DateTime Datetime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        [Required]
        public TypeE Type { get; set; }
        
    }
}