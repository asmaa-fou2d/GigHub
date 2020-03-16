using System;

namespace GigHub2.Dtos
{
    public class GigDto
    {
        public int Id { get; set; }
       
        public DateTime DateTime { get; set; }

        //venue i.e Location
        public string Venue { get; set; }
        
        public bool IsCanceled { get;  set; }

        //venue i.e Category
        public GenreDto Genre { get; set; }
       
        public UserDto Artist { get; set; }
        

    }
}