namespace webapi.models
{
    public class UserBank 
    {
        public int UserID { get; set; }

        public User AccountUser { get; set; }

        public int BankID { get; set; }

        public Bank AccountBank { get; set; }

    }
}
