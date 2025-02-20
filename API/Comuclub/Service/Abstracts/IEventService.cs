using Comuclub.Entities;
using Comuclub.Views.Models;

namespace Comuclub.Service.Abstracts
{
    public interface IEventService
    {
        Task<Event> saveEvent(EventModel model);
        Task<IEnumerable<Event>> findAll();
        
    }
}
