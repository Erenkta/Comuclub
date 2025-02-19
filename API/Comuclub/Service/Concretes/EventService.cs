using Comuclub.Data;
using Comuclub.Entities;
using Comuclub.Service.Abstracts;
using Comuclub.Views.Models;
using Microsoft.EntityFrameworkCore;

namespace Comuclub.Service.Concretes
{
    public class EventService : IEventService
    {
        private readonly ComuClubContext _context;
        public EventService(ComuClubContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> findAll()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> saveEvent(EventModel model)
        {
            var createdEntity = new Event
            {
                AddressId = model.AddressId,
                ClubId = model.ClubId,
                Description = model.Description,
                EventDate = model.EventDate,
                EventType = model.EventType,
                Image = model.Image,
                Title = model.Title,

            };
            await _context.Events.AddAsync(createdEntity);
            await _context.SaveChangesAsync();
            return createdEntity;
        }
    }
}
