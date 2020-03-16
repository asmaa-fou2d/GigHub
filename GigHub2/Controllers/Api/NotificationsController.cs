using AutoMapper;
using GigHub2.Dtos;
using GigHub2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub2.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var notifications = _context.UserNotifications
                    .Where(n => n.UserId == userId && n.IsRead == false)
                    .Select(n => n.Notification)
                    .Include(g => g.Gig.Artist)
                    .ToList();

                return notifications.Select(Mapper.Map<Notification, NotificationDto>);
            }
            catch (Exception ex)
            {
                return null;
            }
            //return notifications.Select(n => new NotificationDto()
            //{
            //    DateTime = n.DateTime,
            //    Gig = new GigDto()
            //    {
            //        Artist = new UserDto()
            //        {
            //            Id = n.Gig.Artist.Id,
            //            Name = n.Gig.Artist.Name,
            //        },
            //        DateTime = n.Gig.DateTime,
            //        Id = n.Gig.Id,
            //        IsCanceled = n.Gig.IsCanceled,
            //        Venue = n.Gig.Venue
            //    },
            //    OriginalDateTime = n.OriginalDateTime,
            //    OriginalVenue = n.OriginalVenue,
            //    Type = n.Type
            //});
        }
    }
}
