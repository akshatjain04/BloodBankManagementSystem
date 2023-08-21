using System;
using NUnit.Framework;
using Moq;
using System.Data;

// Ensure the correct namespace or assembly references for frmDonors and IDataAccessLayer
using YourNamespaceForFrmDonors;
using YourNamespaceForIDataAccessLayer;

namespace BloodBankManagementSystem.UI.Test
{
    [TestFixture]
    public class frmDonors_txtSearch_TextChanged_e5ba9dfd61_Test
    {
        private frmDonors _frmDonors;
        private Mock<IDataAccessLayer> _mockDal;

        [SetUp]
        public void Setup()
        {
            _mockDal = new Mock<IDataAccessLayer>();
            _frmDonors = new frmDonors(_mockDal.Object);
        }

        [Test]
        public void txtSearch_TextChanged_WhenCalledWithKeywords_ReturnsSearchedDonors()
        {
            var dt = new DataTable();
            _mockDal.Setup(d => d.Search(It.IsAny<string>())).Returns(dt);

            _frmDonors.txtSearch_TextChanged(this, EventArgs.Empty);

            Assert.AreEqual(dt, _frmDonors.dgvDonors.DataSource);
            _mockDal.Verify(d => d.Search(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void txtSearch_TextChanged_WhenCalledWithNull_ReturnsAllDonors()
        {
            var dt = new DataTable();
            _mockDal.Setup(d => d.Select()).Returns(dt);

            _frmDonors.txtSearch_TextChanged(this, EventArgs.Empty);

            Assert.AreEqual(dt, _frmDonors.dgvDonors.DataSource);
            _mockDal.Verify(d => d.Select(), Times.Once);
        }

        [TearDown]
        public void TearDown()
        {
            _frmDonors = null;
            _mockDal = null;
        }
    }
}
