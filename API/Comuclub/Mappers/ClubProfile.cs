namespace Comuclub.Mappers
{
    using AutoMapper;
    using Comuclub.Entities;
    using Comuclub.Views.Dtos;
    using Comuclub.Views.Models;

    public class ClubProfile : Profile
    {
        public ClubProfile() {
            CreateMap<ClubDto, Club>().ReverseMap();
            CreateMap<ClubModel,Club>();
        }
    }
}
