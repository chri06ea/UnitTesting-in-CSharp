#define USE_MEMORY_REPOSITORY
//#define USE_NSUBSTITUTE_REPOSITORY

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using UnitTesting.Core;
using UnitTesting.Extensions;

namespace UnitTesting.UnitTests.BusinessLogic
{
    [TestClass]
    public class AuthServiceLoginTests
    {
        private readonly IRepository<User> _userRepository;
        private readonly AuthService _myService;

        private readonly string username = "username";
        private readonly string password = "password";

        public AuthServiceLoginTests()
        {
#if USE_MEMORY_REPOSITORY
            _userRepository = new MemoryRepository<User>();

            _myService = new AuthService(_userRepository);
#elif USE_NSUBSTITUTE_REPOSITORY
            _userRepository = Substitute.For<IRepository<User>>();
            _userRepository.Find(Arg.Any<Predicate<User>>()).Returns(new User(username, password));

            _myService = new AuthService(_userRepository);
#endif
        }

        [TestInitialize]
        public void Initialize()
        {
            _userRepository.Clear();
        }

        [TestMethod]
        public void ValidLoginReturnsUsertoken()
        {
            _myService.Register(username, password);

            var result = _myService.Login(username, password);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EmptyUsernameReturnsNull()
        {
            _myService.Register(username, password);

            var result = _myService.Login("", "");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EmptyPasswordReturnsNull()
        {
            _myService.Register(username, password);

            var result = _myService.Login(username, "");

            Assert.IsNull(result);
        }
    }
}