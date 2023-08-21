using NUnit.Framework;
using System;
using System.Data;
using Moq;

namespace BloodBankManagementSystem.Test
{
    public interface IDataAccessLayer
    {
        int allDonorCount();
        DataTable Select();
    }

    public class frmHome
    {
        private IDataAccessLayer _dataAccessLayer;
        public object dgvDonors { get; set; }
        public string lblUser { get; set; }

        public frmHome(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public void frmHome_Load(object sender, EventArgs e)
        {
            _dataAccessLayer.allDonorCount();
            dgvDonors = _dataAccessLayer.Select();
            lblUser = frmLogin.loggedInUser;
        }
    }

    public static class frmLogin
    {
        public static string loggedInUser;
    }

    [TestFixture]
    public class frmHome_frmHome_Load_0a59025f4d
    {
        private Mock<IDataAccessLayer> _mockDal;
        private frmHome _frmHome;
        private EventArgs _eventArgs;

        [SetUp]
        public void Setup()
        {
            _mockDal = new Mock<IDataAccessLayer>();
            _frmHome = new frmHome(_mockDal.Object);
            _eventArgs = new EventArgs();
        }

        [Test]
        public void frmHome_Load_WhenCalled_ShouldCallAllDonorCount()
        {
            _frmHome.frmHome_Load(new object(), _eventArgs);

            _mockDal.Verify(x => x.allDonorCount(), Times.Once);
        }

        [Test]
        public void frmHome_Load_WhenCalled_ShouldSetDgvDonorsDataSource()
        {
            DataTable dt = new DataTable();

            _mockDal.Setup(x => x.Select()).Returns(dt);

            _frmHome.frmHome_Load(new object(), _eventArgs);

            Assert.AreEqual(dt, _frmHome.dgvDonors);
        }

        [Test]
        public void frmHome_Load_WhenCalled_ShouldSetLblUserText()
        {
            string loggedInUser = "TestUser";
            frmLogin.loggedInUser = loggedInUser;

            _frmHome.frmHome_Load(new object(), _eventArgs);

            Assert.AreEqual(loggedInUser, _frmHome.lblUser);
        }
    }
}
