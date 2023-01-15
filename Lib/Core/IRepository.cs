namespace UnitTesting
{
    public interface IRepository<Model> where Model : class
    {
        /// <summary>
        /// Find a single entity that satisfies the predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Model? Find(Predicate<Model> predicate);

        /// <summary>
        /// Find all entities that satisfies the predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<Model> FindAll(Predicate<Model> predicate);

        /// <summary>
        /// Create a new entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Create(Model model);

        /// <summary>
        /// Delete all entities that satisfies the predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Delete(Predicate<Model> predicate);

        /// <summary>
        /// Update all entities that satisfies the predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="setter"></param>
        /// <returns></returns>
        bool Update(Predicate<Model> predicate, Func<Model, Model> setter);
    }
}
