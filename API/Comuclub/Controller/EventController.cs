using Comuclub.Entities;
using Comuclub.Service.Abstracts;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comuclub.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<EventDto>>> FindAll() {
            var result =await _eventService.findAll();
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<IEnumerable<Event>>> Save(EventModel model)
        {
            var createdEntity = await _eventService.saveEvent(model);
            return Ok(createdEntity);
        }
        [HttpPost("{id}/details")]
        public async Task<ActionResult<EventDto>> GetDetails(long id)
        {
            var eventDetailDto = await _eventService.getDetails(id);
            return Ok(eventDetailDto);
        }
        [HttpGet("{eventName}")]
        public async Task<ActionResult<EventDto>> FindEventByName(string eventName)
        {
            var eventDto = await _eventService.findEventByName(eventName);
            return Ok(eventDto);
        }
        [HttpGet("{clubId}/upcoming")]
        public async Task<ActionResult<ICollection<EventDto>>> FindUpcomingEvents(long clubId)
        {
            var upcomingEvents = await _eventService.findUpcomingEvents(clubId);
            return Ok(upcomingEvents);
        }

    }
}
