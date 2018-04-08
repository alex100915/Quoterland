using AutoMapper;
using MyApplication.Dtos;
using MyApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApplication.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<QuoteDto, Quote>();
            Mapper.CreateMap<Quote, QuoteDto>();
            Mapper.CreateMap<ApplicationUserDto, ApplicationUser>();
            Mapper.CreateMap<ApplicationUser, ApplicationUserDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}