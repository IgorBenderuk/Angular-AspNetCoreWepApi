namespace webapi.models.UserDTOS
{
    public class UserUpdateDTO
    {
        public string FirstName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public int Age { get; set; }
    }
}
