using Comuclub.Data;
using Comuclub.Entities;
using Comuclub.Service.Abstracts;
using Comuclub.Views.Models;
using Microsoft.EntityFrameworkCore;

namespace Comuclub.Service.Concretes
{
    public class ClubService : IClubService
    {
        private readonly ComuClubContext _context;

        public ClubService(ComuClubContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Club>> findAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> saveClub(ClubModel model)
        {
            var clubEntity = new Club
            {
                Description = model.Description,
                Events = model.Events,
                Logo = model.Logo,
                Name = model.Name,
                OrganizerId = model.OrganizerId,
            };

            await _context.Clubs.AddAsync(clubEntity);
            await _context.SaveChangesAsync();
            return clubEntity;
        }
    }
}
