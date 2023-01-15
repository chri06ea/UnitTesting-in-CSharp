namespace UnitTesting.Extensions
{
    public static class RepositoryExtensions
    {

        /// <summary>
        /// Check if an entity exists in this repository
        /// </summary>
        /// <typeparam name="Model"></typeparam>
        /// <param name="_repository"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool Exists<Model>(this IRepository<Model> _repository, Predicate<Model> predicate) where Model : class
        {
            return _repository.FindAll(predicate).Count() > 0;
        }

        /// <summary>
        /// Clears/Deletes all the data in the repository
        /// </summary>
        /// <typeparam name="Model"></typeparam>
        /// <param name="_repository"></param>
        public static void Clear<Model>(this IRepository<Model> _repository) where Model : class
        {
            _repository.Delete(x => true);
        }

        /// <summary>
        /// Checks if the repository contains anything at all
        /// </summary>
        /// <typeparam name="Model"></typeparam>
        /// <param name="_repository"></param>
        public static bool IsEmpty<Model>(this IRepository<Model> _repository) where Model : class
        {
            return _repository.Find(x => true) == null;
        }
    }
}
