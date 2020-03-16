using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub2.Dtos;
using GigHub2.Models;
using Microsoft.AspNet.Identity;

namespace GigHub2.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            var existed = _context.Attendances
                .Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);
            if (existed)
                return BadRequest("The attendance is already existed");

            var attend = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attend);
            _context.SaveChanges();

            return Ok();

        }

    }
}
