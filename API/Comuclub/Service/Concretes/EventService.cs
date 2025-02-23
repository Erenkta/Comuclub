using AutoMapper;
using Comuclub.Data;
using Comuclub.Entities;
using Comuclub.Service.Abstracts;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;
using Microsoft.EntityFrameworkCore;

namespace Comuclub.Service.Concretes
{
    public class EventService : IEventService
    {
        private readonly ComuClubContext _context;
        private readonly IMapper _mapper;
        public EventService(ComuClubContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDto>> findAll()
        {
            List<Event> dbResult = await _context.Events.ToListAsync();

            return dbResult.Select(item => _mapper.Map<EventDto>(item));
        }

        public async Task<Event> saveEvent(EventModel model)
        {
            var createdEntity = _mapper.Map<Event>(model);
            await _context.Events.AddAsync(createdEntity);
            await _context.SaveChangesAsync();
            return createdEntity;
        }
    }
}
