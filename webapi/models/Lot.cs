namespace webapi.models
{
    public class Lot :BaseEntity
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string VIN { get; set; }

        public int OwnerId { get; set; }

        public LotDescription  Description { get; set; }

        public User Owner { get; set; }
    }
}
