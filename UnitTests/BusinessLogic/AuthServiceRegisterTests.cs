using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting.Core;
using UnitTesting.Extensions;

namespace UnitTesting.UnitTests.BusinessLogic
{

    [TestClass]
    public class AuthServiceRegisterTests
    {
        private readonly IRepository<User> _userRepository;
        private readonly AuthService _myService;

        private readonly string username = "username";
        private readonly string password = "password";

        public AuthServiceRegisterTests()
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
        public void ValidUsernameAndPassReturnsTrue()
        {
            var result = _myService.Register(username, password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EmptyUsernameReturnsFalse()
        {
            var result = _myService.Register("", password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CannotCreateUserWithSameName()
        {
            _myService.Register(username, password);

            var result = _myService.Register(username, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EmptyPasswordReturnsFalse()
        {
            var result = _myService.Register(username, "");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EmptyUsernameAndPasswordReturnsFalse()
        {
            var result = _myService.Register("", "");

            Assert.IsFalse(result);
        }
    }
}