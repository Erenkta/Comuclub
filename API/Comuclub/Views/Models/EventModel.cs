using Comuclub.Views.Dtos;
using Comuclub.Entities;
using System.Text.Json.Serialization;

namespace Comuclub.Views.Models
{
    public class EventModel : EventDto
    {
        [JsonIgnore]
        public new long Id => base.Id;

        [JsonIgnore]
        public new Club Club => base.Club; 
    }
}
