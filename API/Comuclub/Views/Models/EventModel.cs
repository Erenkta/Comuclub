using Comuclub.Views.Dtos;
using System.Text.Json.Serialization;

namespace Comuclub.Views.Models
{
    public class EventModel : EventDto
    {
        [JsonIgnore]
        public new long Id => base.Id;
    }
}
