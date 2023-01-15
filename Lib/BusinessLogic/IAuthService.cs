namespace UnitTesting
{
    using UserToken = String;

    public interface IAuthService
    {
        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Register(string username, string password);

        /// <summary>
        /// Login as a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserToken? Login(string username, string password);
    }
}
