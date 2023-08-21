using NUnit.Framework;
using BloodBankManagementSystem.UI; // Add the correct namespace where frmHome is located

namespace BloodBankManagementSystem.Test
{
    [TestFixture]
    public class frmHome_InitializeComponent_cd9b87bd2f
    {
        private frmHome form;

        [SetUp]
        public void Setup()
        {
            form = new frmHome();
            form.InitializeComponent();
        }

        [Test]
        public void MenuStripTop_ItemsCount_IsCorrect()
        {
            Assert.AreEqual(2, form.menuStripTop.Items.Count);
        }

        [Test]
        public void PanelFooter_ControlsCount_IsCorrect()
        {
            Assert.AreEqual(3, form.panelFooter.Controls.Count);
        }

        [Test]
        public void LblDeveloper_Text_IsCorrect()
        {
            Assert.AreEqual("VIJAY THAPA", form.lblDeveloper.Text);
        }

        [Test]
        public void LblAppName_Text_IsCorrect()
        {
            Assert.AreEqual("Blood Bank Management System", form.lblAppName.Text);
        }

        [Test]
        public void PanelOpositive_ControlsCount_IsCorrect()
        {
            Assert.AreEqual(3, form.panelOpositive.Controls.Count);
        }

        [Test]
        public void LblOpositiveCount_Text_IsCorrect()
        {
            Assert.AreEqual("100", form.lblOpositiveCount.Text);
        }

        [Test]
        public void LblBloodGroup_Text_IsCorrect()
        {
            Assert.AreEqual("O+", form.lblBloodGroup.Text);
        }

        [TearDown]
        public void TearDown()
        {
            form.Dispose();
        }
    }
}
