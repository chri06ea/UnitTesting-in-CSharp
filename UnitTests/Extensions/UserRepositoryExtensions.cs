using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using UnitTesting.Core;
using UnitTesting.Extensions;

namespace UnitTesting.UnitTests.Extensions
{
    [TestClass]
    public class UserRepositoryExtensionsTests
    {
        private readonly IRepository<User> _userRepository;
        private readonly AuthService _myService;

        private readonly string username = "username";
        private readonly string password = "password";

        public UserRepositoryExtensionsTests()
        {
            _userRepository = new MemoryRepository<User>();

            _myService = new AuthService(_userRepository);
        }

        [TestInitialize]
        public void Initialize()
        {
            _userRepository.Clear();
        }

        [TestMethod]
        public void GetById()
        {
            var model = new User(username, password);
            _userRepository.Create(model);

            var result = _userRepository.GetById(model.Id);

            Assert.IsNotNull(result);
        }
    }
}