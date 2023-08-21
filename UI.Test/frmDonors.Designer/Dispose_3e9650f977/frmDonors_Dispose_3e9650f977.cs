using NUnit.Framework;
using System;

namespace BloodBankManagementSystem.UI.Test
{
    [TestFixture]
    public class FrmDonorsTest
    {
        private FrmDonors _frmDonors;

        [SetUp]
        public void Setup()
        {
            _frmDonors = new FrmDonors();
        }

        [Test]
        public void Dispose_WhenCalledWithFalse_ShouldNotThrowException()
        {
            Assert.DoesNotThrow(() => _frmDonors.Dispose(false));
        }

        [Test]
        public void Dispose_WhenCalledWithTrue_ShouldNotThrowException()
        {
            Assert.DoesNotThrow(() => _frmDonors.Dispose(true));
        }

        [TearDown]
        public void TearDown()
        {
            _frmDonors = null;
        }
    }
}
