using NUnit.Framework;
using System;
using System.Windows.Forms;
using BloodBankManagementSystem.UI;

namespace BloodBankManagementSystem.UI.Test
{
    [TestFixture]
    public class frmDonors_btnClear_Click_7117c2d6bc
    {
        private frmDonors _frmDonors;
        private Button _btnClear;

        [SetUp]
        public void SetUp()
        {
            _frmDonors = new frmDonors();
            _btnClear = new Button();
        }

        [Test]
        public void btnClear_Click_AllTextBoxesCleared()
        {
            // Arrange
            _frmDonors.txtName.Text = "John Doe";
            _frmDonors.txtEmail.Text = "johndoe@example.com";
            _frmDonors.txtContact.Text = "1234567890";

            // Act
            _frmDonors.btnClear_Click(_btnClear, EventArgs.Empty);

            // Assert
            Assert.That(_frmDonors.txtName.Text, Is.Empty);
            Assert.That(_frmDonors.txtEmail.Text, Is.Empty);
            Assert.That(_frmDonors.txtContact.Text, Is.Empty);
        }

        [Test]
        public void btnClear_Click_TextBoxesAlreadyCleared_NoChange()
        {
            // Arrange
            _frmDonors.txtName.Text = "";
            _frmDonors.txtEmail.Text = "";
            _frmDonors.txtContact.Text = "";

            // Act
            _frmDonors.btnClear_Click(_btnClear, EventArgs.Empty);

            // Assert
            Assert.That(_frmDonors.txtName.Text, Is.Empty);
            Assert.That(_frmDonors.txtEmail.Text, Is.Empty);
            Assert.That(_frmDonors.txtContact.Text, Is.Empty);
        }

        [TearDown]
        public void TearDown()
        {
            _frmDonors = null;
            _btnClear = null;
        }
    }
}
