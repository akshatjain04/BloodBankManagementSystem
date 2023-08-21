using System;
using NUnit.Framework;
using BloodBankManagementSystem.UI; // Add this line to include the namespace where frmHome is defined

namespace BloodBankManagementSystem.Test
{
    [TestFixture]
    public class frmHome_pictureBoxClose_Click_6794a42739
    {
        private frmHome _frmHome;
        private bool _isFormHidden;

        [SetUp]
        public void Setup()
        {
            _frmHome = new frmHome();
            _frmHome.FormClosing += (sender, args) => _isFormHidden = true; // Change Hide event to FormClosing
            _isFormHidden = false;
        }

        [Test]
        public void PictureBoxClose_Click_FormIsVisible_FormGetsHidden()
        {
            // Arrange
            _frmHome.Show();

            // Act
            _frmHome.pictureBoxClose_Click(new object(), new EventArgs());

            // Assert
            Assert.IsTrue(_isFormHidden);
        }

        [Test]
        public void PictureBoxClose_Click_FormIsAlreadyHidden_FormRemainsHidden()
        {
            // Arrange
            _frmHome.Hide();

            // Act
            _frmHome.pictureBoxClose_Click(new object(), new EventArgs());

            // Assert
            Assert.IsTrue(_isFormHidden);
        }

        [TearDown]
        public void TearDown()
        {
            _frmHome.Dispose();
        }
    }
}
