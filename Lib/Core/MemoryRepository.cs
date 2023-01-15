namespace UnitTesting.Core
{
    public class MemoryRepository<Model> : IRepository<Model> where Model : class
    {
        private List<Model> _entities;

        public MemoryRepository()
        {
            _entities = new List<Model>();
        }

        public Model? Find(Predicate<Model> predicate)
        {
            return _entities.Find(predicate);
        }

        IEnumerable<Model> IRepository<Model>.FindAll(Predicate<Model> predicate)
        {
            return _entities.FindAll(predicate);
        }

        public bool Create(Model model)
        {
            _entities.Add(model);

            return true;
        }

        public bool Delete(Predicate<Model> predicate)
        {
            return _entities.RemoveAll(predicate) > 0;
        }

        public bool Update(Predicate<Model> predicate, Func<Model, Model> setter)
        {
            var updatedEntities = _entities.Where(model => predicate(model)).Select(setter).ToList();

            _entities = updatedEntities;

            return updatedEntities.Count() > 0;
        }
    }
}
