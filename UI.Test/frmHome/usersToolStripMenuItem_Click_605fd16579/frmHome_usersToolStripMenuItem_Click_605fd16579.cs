using NUnit.Framework;
using System;
using BloodBankManagementSystem.UI; // Assuming the frmHome and frmUsers are in UI namespace
using NSubstitute;

namespace BloodBankManagementSystem.Test
{
    [TestFixture]
    public class frmHome_usersToolStripMenuItem_Click_605fd16579
    {
        private frmHome _frmHome;
        private frmUsers _frmUsers;

        [SetUp]
        public void Setup()
        {
            _frmUsers = Substitute.For<frmUsers>();
            _frmHome = new frmHome(_frmUsers);
        }

        [Test]
        public void usersToolStripMenuItem_Click_UserFormOpens()
        {
            // Arrange
            object sender = new object();
            EventArgs e = new EventArgs();

            // Act
            _frmHome.usersToolStripMenuItem_Click(sender, e);

            // Assert
            _frmUsers.Received().Show();
        }

        [Test]
        public void usersToolStripMenuItem_Click_UserFormOpensOnce()
        {
            // Arrange
            object sender = new object();
            EventArgs e = new EventArgs();

            // Act
            _frmHome.usersToolStripMenuItem_Click(sender, e);

            // Assert
            _frmUsers.Received(1).Show();
        }
    }
}
