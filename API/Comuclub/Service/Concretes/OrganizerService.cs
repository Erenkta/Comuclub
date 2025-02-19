using Comuclub.Data;
using Comuclub.Service.Abstracts;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;

namespace Comuclub.Service.Concretes
{
    public class OrganizerService : IOrganizerService
    {
        private readonly ComuClubContext _context;

        public OrganizerService(ComuClubContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<OrganizerDto>> findAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrganizerDto> saveEvent(OrganizerModel model)
        {
            throw new NotImplementedException();
        }
    }
}
