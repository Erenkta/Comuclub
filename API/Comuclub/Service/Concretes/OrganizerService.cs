using Comuclub.Data;
using Comuclub.Entities;
using Comuclub.Service.Abstracts;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;
using Microsoft.EntityFrameworkCore;

namespace Comuclub.Service.Concretes
{
    public class OrganizerService : IOrganizerService
    {
        private readonly ComuClubContext _context;

        public OrganizerService(ComuClubContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrganizerDto>> findAll()
        {
            var result= await _context.Organizers
                .Select(item => new OrganizerDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    PersonalMail = item.PersonalMail,
                    StudentMail = item.StudentMail,
                    StudentNo = item.StudentNo,
                     Clubs = item.Clubs,
                }).ToListAsync();

            return result;
        }

        public async Task<OrganizerDto> saveOrganizer(OrganizerModel model)
        {
            var createdEntity = new Organizer
            {
                Name = model.Name,
                Surname = model.Surname,
                StudentNo = model.StudentNo,
                StudentMail = model.StudentMail,
                PersonalMail = model.PersonalMail
            };
            var result =  await _context.Organizers.AddAsync(createdEntity);

            if(result.State == EntityState.Added)
            {
                createdEntity = result.Entity;
            }
            await _context.SaveChangesAsync();
            return new OrganizerDto
            {
                Id = createdEntity.Id,
                Name = createdEntity.Name,
                Surname = createdEntity.Surname,
                PersonalMail = createdEntity.PersonalMail,
                StudentMail = createdEntity.StudentMail,
                StudentNo = createdEntity.StudentNo,
                Clubs = createdEntity.Clubs,
            };
        }
    }
}
