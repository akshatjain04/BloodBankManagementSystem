using NUnit.Framework;
using Moq;
using System;
using BloodBankManagementSystem.UI; // Added missing namespace

namespace BloodBankManagementSystem.Test
{
    public class frmHome_Dispose_3e9650f977
    {
        private frmHome target;
        private Mock<IDisposable> mockComponents;
        
        [SetUp]
        public void SetUp()
        {
            // TODO: Replace null with the actual implementation of the class being tested
            target = new frmHome(); // Replace null with actual instance of frmHome
            
            // Mock the components object
            mockComponents = new Mock<IDisposable>();
            target.components = mockComponents.Object;
        }

        [Test]
        public void Dispose_DisposingTrueAndComponentsNotNull_ComponentsDisposed()
        {
            // Act
            target.Dispose(true);
            
            // Assert
            mockComponents.Verify(x => x.Dispose(), Times.Once);
        }

        [Test]
        public void Dispose_DisposingFalseAndComponentsNotNull_ComponentsNotDisposed()
        {
            // Act
            target.Dispose(false);
            
            // Assert
            mockComponents.Verify(x => x.Dispose(), Times.Never);
        }

        [Test]
        public void Dispose_DisposingTrueAndComponentsNull_ComponentsNotDisposed()
        {
            // Arrange
            target.components = null;
            
            // Act
            target.Dispose(true);
            
            // Assert
            // No exception should be thrown
        }
    }
}
