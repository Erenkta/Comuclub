using Comuclub.Entities;

namespace Comuclub.Views.Dtos
{
    public class OrganizerDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentMail { get; set; }
        public string PersonalMail { get; set; }
        public string StudentNo { get; set; }
        public ICollection<Club> Clubs { get; set; }

    }
}
