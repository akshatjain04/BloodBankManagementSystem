// Test generated by RoostGPT for test CSharp-Blood-Bank-Management-System using AI Type Open AI and AI Model gpt-4

using NUnit.Framework;
using System;
using Moq;
using BloodBankManagementSystem;

namespace BloodBankManagementSystem.Test
{
    [TestFixture]
    public class frmHome_donorsToolStripMenuItem_Click_1748d6b9c7
    {
        private frmHome _frmHome;

        [SetUp]
        public void Setup()
        {
            _frmHome = new frmHome();
        }

        [Test]
        public void donorsToolStripMenuItem_Click_WhenCalled_ShouldOpenDonorsForm()
        {
            // Arrange
            var mockEventArgs = new Mock<EventArgs>();
            var mockForm = new Mock<frmDonors>();

            // Act
            _frmHome.donorsToolStripMenuItem_Click(null, mockEventArgs.Object);

            // Assert
            mockForm.Verify(m => m.Show(), Times.Once);
        }

        [Test]
        public void donorsToolStripMenuItem_Click_WhenCalledWithNullEventArgs_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockForm = new Mock<frmDonors>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _frmHome.donorsToolStripMenuItem_Click(null, null));
        }
    }
}
