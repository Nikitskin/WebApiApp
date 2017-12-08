using Moq;
using NUnit.Framework;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.DBLayer.UnitOfWork;
using WebAPITestApp.NLogger;
using WebAPITestApp.Web.Infrastructure;
using WebAPITestApp.Web.Infrastructure.MappingProfilers;

namespace UnitTests
{
    [TestFixture]
    public class RepositoryTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private UserService _service;
        private Mock<ILoggerService> _logger;
        private Mock<IMap> _mapper;

        [Test]
        public void GetUserToken()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _logger = new Mock<ILoggerService>();
            _unitOfWorkMock.Setup(db => db.UsersRepository.Create(It.IsAny<User>())).Verifiable();
            _service = new UserService(_unitOfWorkMock.Object, _logger.Object, _mapper.Object);
            //todo implement tests
            //_service.GetToken(null);
            _unitOfWorkMock.VerifyAll();
        }
    }
}
