namespace webapi.models
{
    public class User:BaseEntity
    {


            public string FirstName { get; set; }=string.Empty;

            public string Email { get; set; }= string.Empty;

            public string Password { get; set; } = string.Empty;

            public int Age { get; set; } = 0;

            public ICollection<Lot>? Lots { get; set; }=new List<Lot>();

            public ICollection<UserBank>? Banks { get; set; } = new List<UserBank>();
    }
}
