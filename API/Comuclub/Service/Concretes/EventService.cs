using AutoMapper;
using Comuclub.Common;
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
        private readonly ILog _logger;
        public EventService(ComuClubContext context,IMapper mapper,ILog logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<EventDto>> findAll()
        {
            List<Event> dbResult = await _context.Events.ToListAsync();

            return dbResult.Select(item => _mapper.Map<EventDto>(item));
        }

        public async  Task<EventDto> findEventByName(string name)
        {
            var result = await _context.Events.Where(item => item.Title.Equals(name)).FirstOrDefaultAsync();
            if(result == null)
            {
                _logger.LogError("Aradığınız Etkinlik Bulunamadı. Etkinlik Adı : "+name);
            }
            return _mapper.Map<EventDto>(result);
        }

        public async Task<ICollection<EventDto>> findUpcomingEvents(long clubId)
        {
            var dbResult = await _context.Events
               .Where(item => item.ClubId.Equals(clubId) && DateTimeOffset.Compare(DateTimeOffset.Now,item.EventDate) == -1).
                Select(item => _mapper.Map<EventDto>(item))
               .ToListAsync();

            return dbResult;

        }

        public async Task<EventDto> getDetails(long id)
        {
            var dbResult = await _context.Events.FindAsync(id);
            return _mapper.Map<EventDto>(dbResult);
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
