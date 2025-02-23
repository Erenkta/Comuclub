using Comuclub.Entities;
using Comuclub.Views.Dtos;
using System.Text.Json.Serialization;

namespace Comuclub.Views.Models
{
    public class ClubModel : ClubDto
    {

        [JsonIgnore] 
        public new long Id => base.Id;

        [JsonIgnore]
        public new ICollection<Event> Events => base.Events; 
    }
}
