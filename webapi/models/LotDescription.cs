namespace webapi.models
{
    public class LotDescription : BaseEntity
    {

        public int LotID { get; set; }

        public Lot Lot { get; set; }

        public string DamageType { get; set; }

        public string Conditions { get; set; }

        public int Milage { get; set; }

        public string Equipnemt { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
