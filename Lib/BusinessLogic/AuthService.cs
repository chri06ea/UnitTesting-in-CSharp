namespace UnitTesting
{
    using UserToken = String;

    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public UserToken? Login(string username, string password)
        {
            var user = _userRepository.GetByName(username);

            if (user == null)
                return null;

            if (user.Password != password)
                return null;

            return $"{username}:{password}";
        }

        public bool Register(string username, string password)
        {
            if (username.Length < 3 || password.Length < 3)
                return false;

            if (_userRepository.UserByNameExists(username))
                return false;

            return _userRepository.Create(new User(username, password));
        }
    }
}
