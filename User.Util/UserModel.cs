namespace User.Util
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

    }

    public static class UserList
    {
        public static User GetUser()
        {
            return new User() { Id = Guid.Parse("065c5aec-50df-11ed-bdc3-0242ac120002"), Name = "First Last" };
        }
    }
}