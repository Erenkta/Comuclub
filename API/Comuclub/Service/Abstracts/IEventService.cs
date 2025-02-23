using Comuclub.Entities;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;

namespace Comuclub.Service.Abstracts
{
    public interface IEventService
    {
        Task<Event> saveEvent(EventModel model);
        Task<IEnumerable<EventDto>> findAll();
        
    }
}
