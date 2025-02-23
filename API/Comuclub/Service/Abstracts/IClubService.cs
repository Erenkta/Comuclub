using Comuclub.Entities;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;

namespace Comuclub.Service.Abstracts
{
    public interface IClubService
    {
        Task<Club> saveClub(ClubModel model);

        Task<IEnumerable<Club>> findAll();
        Task<ClubDto> findByClubName(string clubName);
    }
}
