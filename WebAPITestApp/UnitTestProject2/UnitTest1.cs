using DBLayer.DbData;
using DBLayer.UnitOfWork;
using Moq;
using NUnit.Framework;
using WebAPITestApp.Infrastructure.WebServices.AuthorizationService;

namespace WebTest
{
    [TestFixture]
    public class RepositoryTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private UserService _service;

        [Test]
        public void GetUserToken()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _unitOfWorkMock.Setup(db => db.UsersRepository.Create(It.IsAny<User>())).Verifiable();
            _service = new UserService(_unitOfWorkMock.Object);
            _service.GetToken("test", "test");
            _unitOfWorkMock.VerifyAll();
        }
    }
}
