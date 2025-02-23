using Comuclub.Entities;
using Comuclub.Views.Enums;

namespace Comuclub.Views.Dtos
{
    public class EventDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EventDate { get; set; }
        public EventTypeEnum EventType { get; set; }
        public byte[] Image { get; set; }
        public Club Club { get; set; }
        public long ClubId { get; set; }
        public long AddressId { get; set; }
        public Address Address { get; set; }
    }
}
