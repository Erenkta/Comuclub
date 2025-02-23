using AutoMapper;
using Comuclub.Entities;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;


namespace Comuclub.Mappers
{
    public class OrganizerProfile : Profile
    {
        public OrganizerProfile() {
            CreateMap<OrganizerDto,Organizer>().ReverseMap();
            CreateMap<OrganizerModel, Organizer>();
        }
    }
}
