namespace UnitTesting
{
    public class User
    {
        public User(string name, string password)
        {
            Name = name;

            Password = password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; }
    }
}
