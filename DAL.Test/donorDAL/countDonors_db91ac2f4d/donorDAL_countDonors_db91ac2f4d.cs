using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;
using Moq;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    public class donorDAL_countDonors_db91ac2f4d
    {
        private Mock<IDbConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;
        private Mock<IDbDataAdapter> _mockDataAdapter;
        private Mock<DataSet> _mockDataSet; 

        private donorDAL _donorDAL;

        [SetUp]
        public void SetUp()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();
            _mockDataAdapter = new Mock<IDbDataAdapter>();
            _mockDataSet = new Mock<DataSet>();

            _mockConnection.Setup(m => m.CreateCommand()).Returns(_mockCommand.Object);
            _mockCommand.Setup(m => m.Connection).Returns(_mockConnection.Object);
            _mockDataAdapter.Setup(m => m.SelectCommand).Returns(_mockCommand.Object);

            _donorDAL = new donorDAL(_mockConnection.Object, _mockDataAdapter.Object);
        }

        [Test]
        public void countDonors_WithValidBloodGroup_ReturnsCorrectCount()
        {
            // Arrange
            string bloodGroup = "A+";
            _mockCommand.Setup(m => m.CommandText).Returns("SELECT COUNT(*) FROM tbl_donors WHERE blood_group = '"+ bloodGroup +"'");
            _mockDataAdapter.Setup(m => m.Fill(_mockDataSet.Object)).Returns(5);

            // Act
            var result = _donorDAL.countDonors(bloodGroup);

            // Assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void countDonors_WithInvalidBloodGroup_ReturnsZero()
        {
            // Arrange
            string bloodGroup = "Invalid";
            _mockCommand.Setup(m => m.CommandText).Returns("SELECT COUNT(*) FROM tbl_donors WHERE blood_group = '"+ bloodGroup +"'");
            _mockDataAdapter.Setup(m => m.Fill(_mockDataSet.Object)).Returns(0);

            // Act
            var result = _donorDAL.countDonors(bloodGroup);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
