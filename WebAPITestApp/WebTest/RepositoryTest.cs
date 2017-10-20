using DBLayer.DbData;
using DBLayer.UnitOfWork;
using Moq;
using NUnit.Framework;

namespace WebTest
{
    [TestFixture]
    public class RepositoryTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;

        [Test]
        public void GetUserToken()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _unitOfWorkMock.Setup(db => db.UsersRepository.Create(It.IsAny<User>())).Verifiable();

        }
    }
}
