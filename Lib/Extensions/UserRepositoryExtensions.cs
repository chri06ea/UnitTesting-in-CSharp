namespace UnitTesting
{
    public static class UserRepositoryExtensions
    {
        /// <summary>
        /// Get a user by ID
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static User? GetById(this IRepository<User> userRepository, int userId)
        {
            return userRepository.Find(x => x.Id == userId);
        }

        /// <summary>
        /// Get a user by name
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static User? GetByName(this IRepository<User> userRepository, string userName)
        {
            return userRepository.Find(x => x.Name == userName);
        }

        /// <summary>
        /// Check if a user with a specific username exists
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool UserByNameExists(this IRepository<User> userRepository, string userName)
        {
            return userRepository.Find(x => x.Name == userName) != null;
        }
    }
}
