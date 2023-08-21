using System;
using NUnit.Framework;
using Moq;
using System.Windows.Forms;
using BloodBankManagementSystem.UI;

namespace BloodBankManagementSystem.UI.Test
{
    [TestFixture]
    public class frmDonors_InitializeComponent_cd9b87bd2f
    {
        private frmDonors form;

        [SetUp]
        public void Setup()
        {
            form = new frmDonors();
        }

        [Test]
        public void InitializeComponent_PanelTopProperties_CorrectlyAssigned()
        {
            form.InitializeComponent();

            Assert.AreEqual(DockStyle.Top, form.panelTop.Dock);
            Assert.AreEqual(1, form.panelTop.TabIndex);
        }

        [Test]
        public void InitializeComponent_PictureBoxCloseProperties_CorrectlyAssigned()
        {
            form.InitializeComponent();

            Assert.AreEqual(false, form.pictureBoxClose.TabStop);
        }

        [Test]
        public void InitializeComponent_LblFormTitleProperties_CorrectlyAssigned()
        {
            form.InitializeComponent();

            Assert.AreEqual("Manage Donors", form.lblFormTitle.Text);
        }

        [Test]
        public void InitializeComponent_TxtSearchProperties_CorrectlyAssigned()
        {
            form.InitializeComponent();

            Assert.AreEqual(48, form.txtSearch.TabIndex);
        }

        [Test]
        public void InitializeComponent_BtnClearProperties_CorrectlyAssigned()
        {
            form.InitializeComponent();

            Assert.AreEqual(45, form.btnClear.TabIndex);
            Assert.AreEqual("CLEAR", form.btnClear.Text);
        }

        // TODO: Add more test cases for each control and property to ensure they are correctly initialized.

        [TearDown]
        public void TearDown()
        {
            form.Dispose();
        }
    }
}
