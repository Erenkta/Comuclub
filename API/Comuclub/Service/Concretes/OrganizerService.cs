using AutoMapper;
using Comuclub.Data;
using Comuclub.Entities;
using Comuclub.Service.Abstracts;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;
using Microsoft.EntityFrameworkCore;

namespace Comuclub.Service.Concretes
{
    public class OrganizerService : IOrganizerService
    {
        private readonly ComuClubContext _context;
        private readonly IMapper _mapper;

        public OrganizerService(ComuClubContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrganizerDto>> findAll()
        {
            var result= await _context.Organizers
                .Select(item => _mapper.Map<OrganizerDto>(item)).ToListAsync();

            return result;
        }

        public async Task<OrganizerDto> saveOrganizer(OrganizerModel model)
        {
            var createdEntity = _mapper.Map<Organizer>(model);
            var result =  await _context.Organizers.AddAsync(createdEntity);

            if(result.State == EntityState.Added)
            {
                createdEntity = result.Entity;
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<OrganizerDto>(createdEntity);
        }
    }
}
