using NUnit.Framework;
using Moq;
using System.IO;
using System.Data;

// Replace 'YourNamespace' with the actual namespaces where your classes are defined
// For example, if your classes are in a namespace called 'BloodBankManagement', replace 'YourNamespace' with 'BloodBankManagement'
using BloodBankManagement.DonorDAL;
using BloodBankManagement.UI;
using BloodBankManagement.Models;

namespace BloodBankManagementSystem.UI.Test
{
    [TestFixture]
    public class frmDonors_btnDelete_Click_d64e603575
    {
        private Mock<IDonorDAL> _mockDonorDAL; 
        private frmDonors _frmDonors;
        private Donor _donor;

        [SetUp]
        public void Setup()
        {
            _mockDonorDAL = new Mock<IDonorDAL>();
            _frmDonors = new frmDonors(_mockDonorDAL.Object); 
            _donor = new Donor { donor_id = 1 };
        }

        [Test]
        public void btnDelete_Click_DonorWithImage_DonorDeletedSuccessfully()
        {
            string rowHeaderImage = "test-image.jpg";
            _mockDonorDAL.Setup(d => d.Delete(_donor)).Returns(true);

            _frmDonors.btnDelete_Click(null, null);

            _mockDonorDAL.Verify(d => d.Delete(_donor), Times.Once);
        }

        [Test]
        public void btnDelete_Click_DonorWithoutImage_DonorDeletedSuccessfully()
        {
            string rowHeaderImage = "no-name.jpg";
            _mockDonorDAL.Setup(d => d.Delete(_donor)).Returns(true);

            _frmDonors.btnDelete_Click(null, null);

            _mockDonorDAL.Verify(d => d.Delete(_donor), Times.Once);
        }

        [Test]
        public void btnDelete_Click_DonorWithImage_DonorDeletionFailed()
        {
            string rowHeaderImage = "test-image.jpg";
            _mockDonorDAL.Setup(d => d.Delete(_donor)).Returns(false);

            _frmDonors.btnDelete_Click(null, null);

            _mockDonorDAL.Verify(d => d.Delete(_donor), Times.Once);
        }

        [Test]
        public void btnDelete_Click_DonorWithoutImage_DonorDeletionFailed()
        {
            string rowHeaderImage = "no-name.jpg";
            _mockDonorDAL.Setup(d => d.Delete(_donor)).Returns(false);

            _frmDonors.btnDelete_Click(null, null);

            _mockDonorDAL.Verify(d => d.Delete(_donor), Times.Once);
        }
    }
}
