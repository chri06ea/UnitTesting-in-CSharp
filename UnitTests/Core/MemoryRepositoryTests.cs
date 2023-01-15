using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using UnitTesting.Core;

namespace UnitTesting.UnitTests.Core
{
    [TestClass]
    public class MemoryRepositoryTests
    {
        private readonly IRepository<TestModel> _repository;

        public MemoryRepositoryTests()
        {
            _repository = new MemoryRepository<TestModel>();
        }

        [TestInitialize]
        public void Initialize()
        {
            _repository.Delete(x => true);
        }

        [TestMethod]
        public void Find()
        {
            var model = new TestModel("name");
            _repository.Create(model);

            var result = _repository.Find(x => x == model);

            Assert.IsTrue(result == model);
        }

        [TestMethod]
        public void FindAll()
        {
            var model1 = new TestModel("name1");
            _repository.Create(model1);
            var model2 = new TestModel("name2");
            _repository.Create(model2);
            var model3 = new TestModel("name3");
            _repository.Create(model3);

            var result = _repository.FindAll(x => (x == model1 || x == model2));

            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public void Create()
        {
            var model = new TestModel("name");

            var result = _repository.Create(model);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete()
        {
            var model = new TestModel("name");
            _repository.Create(model);

            var result = _repository.Delete(x => x == model);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Update()
        {
            var model = new TestModel("name");
            _repository.Create(model);

            var result = _repository.Update(x => x == model, x => x);

            Assert.IsTrue(result);
        }
    }
}