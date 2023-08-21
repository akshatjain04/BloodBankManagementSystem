using NUnit.Framework;
using System;
using BloodBankManagementSystem.UI;

namespace BloodBankManagementSystem.UI.Test
{
    [TestFixture]
    public class frmDonors_pictureBoxClose_Click_6794a42739
    {
        private frmDonors _frmDonors;

        [SetUp]
        public void Setup()
        {
            _frmDonors = new frmDonors();
        }

        [Test]
        public void pictureBoxClose_Click_ShouldHideForm()
        {
            //Arrange
            var sender = new object();
            var e = new EventArgs();

            //Act
            _frmDonors.pictureBoxClose_Click(sender, e);

            //Assert
            Assert.IsFalse(_frmDonors.Visible);
        }

        [Test]
        public void pictureBoxClose_Click_ShouldNotThrowException_WhenSenderIsNull()
        {
            //Arrange
            var e = new EventArgs();

            //Act
            TestDelegate act = () => _frmDonors.pictureBoxClose_Click(null, e);

            //Assert
            Assert.DoesNotThrow(act);
        }

        [Test]
        public void pictureBoxClose_Click_ShouldNotThrowException_WhenEventArgsIsNull()
        {
            //Arrange
            var sender = new object();

            //Act
            TestDelegate act = () => _frmDonors.pictureBoxClose_Click(sender, null);

            //Assert
            Assert.DoesNotThrow(act);
        }

        [TearDown]
        public void Teardown()
        {
            _frmDonors.Dispose();
        }
    }
}
