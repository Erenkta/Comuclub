using AutoMapper;
using Comuclub.Data;
using Comuclub.Entities;
using Comuclub.Service.Abstracts;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;
using Microsoft.EntityFrameworkCore;

namespace Comuclub.Service.Concretes
{
    public class ClubService : IClubService
    {
        private readonly ComuClubContext _context;
        private readonly IMapper _mapper;

        public ClubService(ComuClubContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Club>> findAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<ClubDto> findByClubName(string clubName)
        {
            var result = await _context.Clubs.Where(item => item.Name == clubName).FirstOrDefaultAsync();
            ClubDto mappedResult = _mapper.Map<ClubDto>(result);
            return mappedResult;
        }

        public async Task<Club> saveClub(ClubModel model)
        {
            Club clubEntity = _mapper.Map<Club>(model);
            await _context.Clubs.AddAsync(clubEntity);
            await _context.SaveChangesAsync();
            return clubEntity;
        }
    }
}
