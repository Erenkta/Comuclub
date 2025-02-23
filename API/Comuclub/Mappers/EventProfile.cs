using AutoMapper;
using Comuclub.Entities;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;

namespace Comuclub.Mappers
{
    public class EventProfile : Profile
    {
        public EventProfile() {
            CreateMap<EventDto, Event>().ReverseMap();
            CreateMap<EventModel, Event>();
        }
    }
}
