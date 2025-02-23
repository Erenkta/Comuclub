using Comuclub.Entities;
using Comuclub.Service.Abstracts;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comuclub.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Club>>> findAll()
        {
            var result = await _clubService.findAll();
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Club>> save(ClubModel entityModel)
        {

            Club createdEntity = await _clubService.saveClub(entityModel);
            return Ok(createdEntity);
        }
        [HttpGet("{clubName}")]
        public async Task<ActionResult<ClubDto>> findClubByName(string clubName)
        {
            var clubDto = await _clubService.findByClubName(clubName);
            return Ok(clubDto);
        }

    }
}
