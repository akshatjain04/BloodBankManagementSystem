using NUnit.Framework;
using System.Data;
using System.Data.Common;
using Moq;

namespace userDAL_Search_c0040eee0a
{
    [TestFixture]
    public class SearchTests
    {
        private Mock<IDbConnection> _mockConnection;
        private Mock<IDbCommand> _mockCommand;
        private Mock<DbDataAdapter> _mockAdapter;
        private DataTable _dataTable;

        [SetUp]
        public void Setup()
        {
            _mockConnection = new Mock<IDbConnection>();
            _mockCommand = new Mock<IDbCommand>();
            _mockAdapter = new Mock<DbDataAdapter>();
            _dataTable = new DataTable();

            _mockConnection.Setup(m => m.CreateCommand()).Returns(_mockCommand.Object);
            _mockCommand.Setup(m => m.ExecuteReader()).Returns(_dataTable.CreateDataReader());
        }

        [Test]
        public void Search_WhenCalledWithValidKeyword_ReturnsDataTable()
        {
            // Arrange
            var sut = new UserDAL(_mockConnection.Object, _mockAdapter.Object);

            // Act
            var result = sut.Search("test");

            // Assert
            Assert.That(result, Is.EqualTo(_dataTable));
        }

        [Test]
        public void Search_WhenCalledWithEmptyKeyword_ThrowsArgumentException()
        {
            // Arrange
            var sut = new UserDAL(_mockConnection.Object, _mockAdapter.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Search(string.Empty));
        }
    }

    public class UserDAL
    {
        private IDbConnection _connection;
        private DbDataAdapter _adapter;

        public UserDAL(IDbConnection connection, DbDataAdapter adapter)
        {
            _connection = connection;
            _adapter = adapter;
        }

        public DataTable Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                throw new ArgumentException("Keyword cannot be null or empty", nameof(keyword));
            }

            var command = _connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Users WHERE Name LIKE '%{keyword}%'";

            _adapter.SelectCommand = command;
            var dataTable = new DataTable();
            _adapter.Fill(dataTable);

            return dataTable;
        }
    }
}
