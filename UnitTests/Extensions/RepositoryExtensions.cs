using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;
using UnitTesting.Core;
using UnitTesting.Extensions;

namespace UnitTesting.UnitTests.Extensions
{
    class TestModel
    {
        public string Name { get; set; }

        public TestModel(string name)
        {
            Name = name;
        }
    }

    [TestClass]
    public class RepositoryExtensionsTests
    {
        private readonly IRepository<TestModel> _repository;

        private readonly string name = "name";

        public RepositoryExtensionsTests()
        {
            _repository = new MemoryRepository<TestModel>();
        }

        [TestInitialize]
        public void Initialize()
        {
            _repository.Clear();
        }

        [TestMethod]
        public void Clear()
        {
            var model = new TestModel(name);
            _repository.Create(model);

            _repository.Clear();

            Assert.IsTrue(_repository.FindAll(x => true).ToList().Count == 0);
        }

        [TestMethod]
        public void Exists()
        {
            var model = new TestModel(name);
            _repository.Create(model);

            var result = _repository.Exists(x => x.Name == name);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Empty()
        {
            var model = new TestModel(name);
            _repository.Create(model);

            var result = _repository.IsEmpty();

            Assert.IsFalse(result);
        }
    }
}