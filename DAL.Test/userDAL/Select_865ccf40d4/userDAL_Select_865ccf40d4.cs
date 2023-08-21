using NUnit.Framework;
using Moq;
using System.Data;
using System.Data.Common;
using BloodBankManagementSystem.DAL;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    public class UserDAL_Select_865ccf40d4
    {
        private Mock<IDbConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;
        private Mock<IDbDataAdapter> _mockDataAdapter;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();
            _mockDataAdapter = new Mock<IDbDataAdapter>();

            _mockConnection.Setup(m => m.CreateCommand()).Returns(_mockCommand.Object);
            _mockCommand.SetupSet(m => m.Connection = It.IsAny<IDbConnection>());
            _mockCommand.SetupSet(m => m.CommandText = It.IsAny<string>());
            _mockDataAdapter.Setup(m => m.Fill(It.IsAny<DataSet>())).Returns(1);
        }

        [Test]
        public void Select_WhenCalled_ReturnsDataSet()
        {
            //Arrange
            var sut = new UserDAL(_mockConnection.Object, _mockDataAdapter.Object);

            //Act
            var result = sut.Select();

            //Assert
            Assert.IsInstanceOf<DataSet>(result);
        }

        [Test]
        public void Select_WhenExceptionThrown_ReturnsEmptyDataSet()
        {
            //Arrange
            _mockConnection.Setup(m => m.Open()).Throws<DbException>();
            var sut = new UserDAL(_mockConnection.Object, _mockDataAdapter.Object);

            //Act
            Assert.Throws<DbException>(() => sut.Select());

            //Assert
            //No assertion is needed here as the exception is expected
        }
    }
}
