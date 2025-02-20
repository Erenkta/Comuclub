using Comuclub.Entities;
using Comuclub.Service.Abstracts;
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
        public async Task<ActionResult<IEnumerable<Event>>> FindAll() {
            var result =await _eventService.findAll();
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<IEnumerable<Event>>> Save(EventModel model)
        {
            var createdEntity = await _eventService.saveEvent(model);
            return Ok(createdEntity);
        }

    }
}
