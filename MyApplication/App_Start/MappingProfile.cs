using AutoMapper;
using MyApplication.Core.Dtos;
using MyApplication.Core.Models;

namespace MyApplication.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<QuoteDto, Quote>();
            CreateMap<Quote, QuoteDto>();
            CreateMap<ApplicationUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();
        }
    }
}