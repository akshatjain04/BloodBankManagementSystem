using NUnit.Framework;
using System;
using Moq;

namespace BloodBankManagementSystem.UI.Test
{
    public interface IForm : IDisposable
    {
        void Dispose(bool disposing);
    }

    [TestFixture]
    public class frmLogin_Dispose_3e9650f977
    {
        private Mock<IForm> _frmLoginMock;
        private IDisposable _components;
        private Mock<IDisposable> _componentsMock;

        [SetUp]
        public void Setup()
        {
            _componentsMock = new Mock<IDisposable>();
            _components = _componentsMock.Object;
            _frmLoginMock = new Mock<IForm>();
        }

        [Test]
        public void Dispose_DisposingTrueAndComponentsNotNull_ComponentsDisposed()
        {
            // Arrange
            bool disposing = true;
            _frmLoginMock.Setup(x => x.Dispose(disposing)).Callback(() => _components.Dispose());

            // Act
            _frmLoginMock.Object.Dispose(disposing);

            // Assert
            _componentsMock.Verify(x => x.Dispose(), Times.Once);
        }

        [Test]
        public void Dispose_DisposingTrueAndComponentsNull_ComponentsNotDisposed()
        {
            // Arrange
            bool disposing = true;
            _components = null;
            _frmLoginMock.Setup(x => x.Dispose(disposing)).Callback(() => _components?.Dispose());

            // Act
            _frmLoginMock.Object.Dispose(disposing);

            // Assert
            _componentsMock.Verify(x => x.Dispose(), Times.Never);
        }

        [Test]
        public void Dispose_DisposingFalseAndComponentsNotNull_ComponentsNotDisposed()
        {
            // Arrange
            bool disposing = false;
            _frmLoginMock.Setup(x => x.Dispose(disposing)).Callback(() => { if (disposing) _components?.Dispose(); });

            // Act
            _frmLoginMock.Object.Dispose(disposing);

            // Assert
            _componentsMock.Verify(x => x.Dispose(), Times.Never);
        }

        [TearDown]
        public void TearDown()
        {
            _frmLoginMock = null;
            _componentsMock = null;
        }
    }
}
