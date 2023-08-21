using NUnit.Framework;
using System;
using Moq;

// Assuming frmHome and IAllDonorCount are in the namespace BloodBankManagementSystem.UI
using BloodBankManagementSystem.UI;

namespace BloodBankManagementSystem.Test
{
    [TestFixture]
    public class frmHome_frmHome_Activated_e02e9939c9
    {
        private frmHome _frmHome;
        private Mock<IAllDonorCount> _mockAllDonorCount;

        [SetUp]
        public void Setup()
        {
            _mockAllDonorCount = new Mock<IAllDonorCount>();
            _frmHome = new frmHome(_mockAllDonorCount.Object);
        }

        [Test]
        public void frmHome_Activated_CallsAllDonorCount()
        {
            // Arrange
            var args = new EventArgs();

            // Act
            _frmHome.frmHome_Activated(this, args);

            // Assert
            _mockAllDonorCount.Verify(m => m.allDonorCount(), Times.Once);
        }

        [Test]
        public void frmHome_Activated_ThrowsException_WhenAllDonorCountFails()
        {
            // Arrange
            var args = new EventArgs();
            _mockAllDonorCount.Setup(m => m.allDonorCount()).Throws<Exception>();

            // Act & Assert
            Assert.Throws<Exception>(() => _frmHome.frmHome_Activated(this, args));
        }
    }
}
