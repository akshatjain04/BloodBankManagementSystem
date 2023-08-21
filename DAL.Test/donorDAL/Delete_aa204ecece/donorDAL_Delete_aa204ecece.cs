using NUnit.Framework;
using BloodBankManagementSystem.DAL;
using System.Data;
using System;

namespace BloodBankManagementSystem.DAL.Test
{
    public class DonorDAL_Delete_Tests
    {
        private DonorDAL _donorDAL;
        private IDbConnection _mockSqlConnection;
        private IDbCommand _mockSqlCommand;

        [SetUp]
        public void Setup()
        {
            _donorDAL = new DonorDAL();
            
            // Mocking IDbConnection and IDbCommand
            _mockSqlConnection = new System.Data.SqlClient.SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
            _mockSqlCommand = new System.Data.SqlClient.SqlCommand();
        }

        [Test]
        public void Delete_WhenCalledWithValidDonorId_ReturnsTrue()
        {
            // Arrange
            var donor = new DonorBLL { DonorId = 1 };

            // Act
            var result = _donorDAL.Delete(donor);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_WhenCalledWithInvalidDonorId_ReturnsFalse()
        {
            // Arrange
            var donor = new DonorBLL { DonorId = -1 };

            // Act
            var result = _donorDAL.Delete(donor);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_WhenCalledWithNullDonor_ThrowsArgumentNullException()
        {
            // Arrange
            DonorBLL donor = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _donorDAL.Delete(donor));
        }

        [TearDown]
        public void TearDown()
        {
            // Dispose resources
            _mockSqlConnection.Close();
        }
    }
}
