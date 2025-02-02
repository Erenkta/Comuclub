namespace Comuclub.Entities
{
    public class Club

    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }
        public Organizer Organizer { get; set; }
        public long OrganizerId { get; set; }
        public ICollection<Event> Events { get; set; }   
    }
}
