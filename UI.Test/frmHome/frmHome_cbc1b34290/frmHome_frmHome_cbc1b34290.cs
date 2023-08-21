// Add this at the top of your file
using System.Windows.Forms;
using BloodBankManagementSystem.UI; // Assuming frmHome is in this namespace

namespace BloodBankManagementSystem.Test
{
    [TestFixture]
    public class frmHome_frmHome_cbc1b34290
    {
        private frmHome _frmHome;

        [SetUp]
        public void Setup()
        {
            _frmHome = new frmHome();
        }

        [Test]
        public void frmHome_WhenCalled_CheckIfControlsAreInitialized()
        {
            // Arrange
            // TODO: Add the controls you want to check if they are initialized

            // Act
            _frmHome.Show();

            // Assert
            // TODO: Assert if the controls are initialized
        }

        [Test]
        public void frmHome_WhenCalled_CheckIfFormIsVisible()
        {
            // Arrange
            // No arrangement required for this test

            // Act
            _frmHome.Show();

            // Assert
            Assert.IsTrue(_frmHome.Visible);
        }

        [TearDown]
        public void TearDown()
        {
            _frmHome.Close();
        }
    }
}
