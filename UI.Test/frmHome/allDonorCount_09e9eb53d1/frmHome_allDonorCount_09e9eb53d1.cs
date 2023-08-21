using NUnit.Framework;
using Moq;
using BloodBankManagementSystem;
using System;

namespace BloodBankManagementSystem.Test
{
    [TestFixture]
    public class frmHome_allDonorCount_09e9eb53d1
    {
        private frmHome _frmHome;
        private Mock<IDal> _mockDal;

        [SetUp]
        public void Setup()
        {
            _mockDal = new Mock<IDal>();
            _frmHome = new frmHome(_mockDal.Object);
        }

        [Test]
        public void allDonorCount_WhenCalled_SetsAllLabelsWithCorrectValues()
        {
            // Arrange
            _mockDal.Setup(d => d.countDonors("O+")).Returns(5);
            _mockDal.Setup(d => d.countDonors("O-")).Returns(3);
            _mockDal.Setup(d => d.countDonors("A+")).Returns(7);
            _mockDal.Setup(d => d.countDonors("A-")).Returns(2);
            _mockDal.Setup(d => d.countDonors("B+")).Returns(4);
            _mockDal.Setup(d => d.countDonors("B-")).Returns(1);
            _mockDal.Setup(d => d.countDonors("AB+")).Returns(6);
            _mockDal.Setup(d => d.countDonors("AB-")).Returns(0);

            // Act
            _frmHome.allDonorCount();

            // Assert
            Assert.AreEqual("5", _frmHome.lblOpositiveCount.Text);
            Assert.AreEqual("3", _frmHome.lblOnegativeCount.Text);
            Assert.AreEqual("7", _frmHome.lblApositiveCount.Text);
            Assert.AreEqual("2", _frmHome.lblAnegativeCount.Text);
            Assert.AreEqual("4", _frmHome.lblBpositiveCount.Text);
            Assert.AreEqual("1", _frmHome.lblBnegativeCount.Text);
            Assert.AreEqual("6", _frmHome.lblABpositiveCount.Text);
            Assert.AreEqual("0", _frmHome.lblABnegativeCount.Text);
        }

        [Test]
        public void allDonorCount_WhenCalled_CallsCountDonorsForEachBloodType()
        {
            // Act
            _frmHome.allDonorCount();

            // Assert
            _mockDal.Verify(d => d.countDonors("O+"), Times.Once);
            _mockDal.Verify(d => d.countDonors("O-"), Times.Once);
            _mockDal.Verify(d => d.countDonors("A+"), Times.Once);
            _mockDal.Verify(d => d.countDonors("A-"), Times.Once);
            _mockDal.Verify(d => d.countDonors("B+"), Times.Once);
            _mockDal.Verify(d => d.countDonors("B-"), Times.Once);
            _mockDal.Verify(d => d.countDonors("AB+"), Times.Once);
            _mockDal.Verify(d => d.countDonors("AB-"), Times.Once);
        }
    }
}
