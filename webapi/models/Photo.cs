namespace webapi.models
{
    public class Photo  :BaseEntity
    {
        public int Lotid;

        public LotDescription LotDescription;
        public string picture;
    }
}
