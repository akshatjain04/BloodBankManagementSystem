using NUnit.Framework;
using BloodBankManagementSystem.DAL;
using System.Data;
using Moq;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    public class DonorDAL_Select_865ccf40d4
    {
        private Mock<IDbConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;
        private Mock<IDbDataAdapter> _mockDataAdapter;
        private Mock<IDbDataParameter> _mockParameter;
        private Mock<IDataReader> _mockDataReader;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();
            _mockDataAdapter = new Mock<IDbDataAdapter>();
            _mockParameter = new Mock<IDbDataParameter>();
            _mockDataReader = new Mock<IDataReader>();

            _mockConnection.Setup(m => m.CreateCommand()).Returns(_mockCommand.Object);
            _mockCommand.Setup(m => m.CreateParameter()).Returns(_mockParameter.Object);
            _mockCommand.Setup(m => m.ExecuteReader()).Returns(_mockDataReader.Object);
        }

        [Test]
        public void Select_WhenCalled_ReturnsDataTable()
        {
            // Arrange
            var donorDAL = new DonorDAL(_mockConnection.Object);

            // Act
            var result = donorDAL.Select();

            // Assert
            Assert.That(result, Is.TypeOf<DataTable>());
        }

        [Test]
        public void Select_WhenExceptionThrown_ReturnsEmptyDataTable()
        {
            // Arrange
            var donorDAL = new DonorDAL(_mockConnection.Object);
            _mockCommand.Setup(m => m.ExecuteReader()).Throws(new Exception());

            // Act
            var result = donorDAL.Select();

            // Assert
            Assert.That(result.Rows, Is.Empty);
        }
    }
}
