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
    public class FollowingsController : ApiController
    {

        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if(_context.Followings.Any(f=>f.FolloweeId==userId && f.FolloweeId == dto.FolloweeId))
            {
                return BadRequest("Following already exists");
            }

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();
            return Ok();
        }

    }
}
