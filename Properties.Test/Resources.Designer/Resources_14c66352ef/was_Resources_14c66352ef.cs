using NUnit.Framework;
using System.Resources;
using System.Globalization;
using System.Reflection;

namespace BloodBankManagementSystem.Properties.Test
{
    public class was_Resources_14c66352ef
    {
        [Test]
        public void Test_Resources_Constructor()
        {
            // Arrange & Act
            var resources = new ResourceManager("BloodBankManagementSystem.Properties.Resources", 
                                                Assembly.GetExecutingAssembly());

            // Assert
            Assert.IsNotNull(resources);
        }
    }
}
