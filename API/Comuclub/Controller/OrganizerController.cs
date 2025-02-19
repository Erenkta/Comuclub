using Comuclub.Data;
using Comuclub.Service.Abstracts;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comuclub.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizerController : ControllerBase
    {
        private readonly ComuClubContext _context;
        private readonly IOrganizerService _organizerService;

        public OrganizerController(ComuClubContext context,IOrganizerService organizerService)
        {
            _context = context;
            _organizerService = organizerService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<OrganizerDto>>> FindAll()
        {
            var result = await _organizerService.findAll();
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<IEnumerable<OrganizerDto>>> Save(OrganizerModel model)
        {
            var createdEntity = await _organizerService.saveOrganizer(model);
            return Ok(createdEntity);
        }
    }
}
