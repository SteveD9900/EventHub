using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using PracticeProject.Dtos;
using PracticeProject.Models;

namespace PracticeProject.Controllers
{
    [Authorize]
    public class AttendanceController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendanceController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            if(_context.Attendances.Any(a=>a.AttendeeId==userId && a.EventId==dto.EventId))
            {
                return BadRequest("The attendance already exists");
            }

            var attendance = new Attendance
            {
                EventId = dto.EventId,
                AttendeeId = User.Identity.GetUserId()
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }

    }
}
