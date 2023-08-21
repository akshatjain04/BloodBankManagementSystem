using NUnit.Framework;
using Moq;
using System.Data;
using System.Data.SqlClient;
using BloodBankManagementSystem.BLL;
using BloodBankManagementSystem.DAL;

namespace BloodBankManagementSystem.DAL.Test
{
    [TestFixture]
    public class loginDAL_loginCheck_b341659581
    {
        private Mock<IDbConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;
        private Mock<IDbDataAdapter> _mockDataAdapter;
        private Mock<DataTable> _mockDataTable;
        private LoginBLL _loginBLL;
        private LoginDAL _loginDAL;

        [SetUp]
        public void SetUp()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();
            _mockDataAdapter = new Mock<IDbDataAdapter>();
            _mockDataTable = new Mock<DataTable>();
            _loginBLL = new LoginBLL();
            _loginDAL = new LoginDAL(_mockConnection.Object, _mockCommand.Object, _mockDataAdapter.Object, _mockDataTable.Object);
        }

        [Test]
        public void loginCheck_LoginSuccessful_ReturnsTrue()
        {
            _loginBLL.Username = "testUser";
            _loginBLL.Password = "testPassword";
            _mockDataTable.Setup(dt => dt.Rows.Count).Returns(1);

            var result = _loginDAL.LoginCheck(_loginBLL);

            Assert.IsTrue(result);
        }

        [Test]
        public void loginCheck_LoginFailed_ReturnsFalse()
        {
            _loginBLL.Username = "testUser";
            _loginBLL.Password = "wrongPassword";
            _mockDataTable.Setup(dt => dt.Rows.Count).Returns(0);

            var result = _loginDAL.LoginCheck(_loginBLL);

            Assert.IsFalse(result);
        }

        [Test]
        public void loginCheck_DatabaseConnectionError_ThrowsException()
        {
            _loginBLL.Username = "testUser";
            _loginBLL.Password = "testPassword";
            _mockConnection.Setup(conn => conn.Open()).Throws<SqlException>();

            Assert.Throws<SqlException>(() => _loginDAL.LoginCheck(_loginBLL));
        }

        [TearDown]
        public void TearDown()
        {
            _mockConnection.Object.Close();
        }
    }
}
