using DBLayer.DbData;
using DBLayer.UnitOfWork;
using Moq;
using NLogger;
using NUnit.Framework;
using WebAPITestApp.Infrastructure;

namespace UnitTests
{
    [TestFixture]
    public class RepositoryTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private UserService _service;
        private Mock<ILoggerService> _logger;

        [Test]
        public void GetUserToken()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _logger = new Mock<ILoggerService>();
            _unitOfWorkMock.Setup(db => db.UsersRepository.Create(It.IsAny<User>())).Verifiable();
            _service = new UserService(_unitOfWorkMock.Object, _logger.Object);
            _service.GetToken("test", "test");
            _unitOfWorkMock.VerifyAll();
        }
    }
}
