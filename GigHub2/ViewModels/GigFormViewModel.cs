using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using GigHub2.Controllers;
using GigHub2.Models;
using GigHub2.ViewModels.CustomVaidators;

namespace GigHub2.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }


        [Required]
        public string Venue { get; set; }


        //for view model every thing is string for user side
        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [VaildTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        // we can use list or collection but we don't add any item for this list  OR using any of its options 
        // so  IEnumerable is a best interface that give us what we need 
        public IEnumerable<Genre> Genres { get; set; }

        //        public DateTime DateTime
        //        {
        //            get { return DateTime.Parse(string.Format("{0},{1}", Date, Time)); }
        //        }
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0},{1}", Date, Time));
        }

        public string Heading { get; set; }
        public string Action
        {
            get
            {
                //return (Id != 0) ? "Update" : "Create";
                //instead of hard coded "Update" : "Create"
                //we will Using Expression instead of the previous line. 

                Expression<Func<GigsController, ActionResult>> update =
                      (c => c.Update(this));

                Expression<Func<GigsController, ActionResult>> create =
                  (c => c.Create(this));

                var action = (Id != 0) ? update : create;

                var actionName = (action.Body as MethodCallExpression).Method.Name;

                 return actionName;
            }
        }

    }
}