using AutoMapper;
using MyApplication.Core.Dtos;
using MyApplication.Core.Models;

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