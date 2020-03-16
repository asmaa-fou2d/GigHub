using GigHub2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub2.ViewModels
{
    public class GigListViewModel
    {
        public IEnumerable<Gig> UpcommingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }

    }
}