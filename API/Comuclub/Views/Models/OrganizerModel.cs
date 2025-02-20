using Comuclub.Entities;
using Comuclub.Views.Dtos;

namespace Comuclub.Views.Models
{
    public class OrganizerModel : OrganizerDto
    {
        public new long Id => base.Id;
        public new ICollection<Club>? Clubs => base.Clubs;

    }
}
