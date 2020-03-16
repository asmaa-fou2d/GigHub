using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GigHub2.Models
{
    public class Gig
    {
        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public int Id { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [MaxLength(255)]
        //venue i.e Location
        public string Venue { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public bool IsCanceled { get; private set; }

        //venue i.e Category
        public Genre Genre { get; set; }

        public ApplicationUser Artist { get; set; }
        public ICollection<Attendance> Attendances { get; private set; }

        internal void Cancel()
        {
            IsCanceled = true;

            //add notification when gig has been canceled 
            var notification = Notification.GigCanceled(this);

            //add userNorificaion for each attendee
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.notify(notification);
            }

        }


        internal void Modify(DateTime date, string venue, byte genre)
        {

            DateTime = date;
            Venue = venue;
            GenreId = genre;

            //add notification when gig has been updated 
            var notification = Notification.GigUpdated(this, DateTime, Venue);


            //add userNorificaion for each attendee
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.notify(notification);
            }
        }

    }
}