using AutoMapper;
using GigHub2.Dtos;
using GigHub2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //source,target
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
            Mapper.CreateMap<Genre, GenreDto>();
        }

        protected override void Configure()
        {
        }
    }
}