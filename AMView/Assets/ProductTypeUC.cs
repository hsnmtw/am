using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AMModel.Models;

namespace AMView.Assets {
    public partial class ProductTypeUC : UserControl {
        public ProductTypeUC() {
            InitializeComponent();
        }

        private void ProductTypeUC_Load(object sender, EventArgs e) {
            txtPRODUCT_TYPE_NAME.Focus();
            txtPRODUCT_TYPE_NAME.Select();
        }

        private void btnFind_Click(object sender, EventArgs e) {
            Form frm = new Form() { Text = "Search PRODUCT_TYPE", Size = new Size(500, 300), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new ProductTypeModel().All(),
                DisplayMember = "PRODUCT_TYPE_NAME",
                OnSelected = delegate (object value) {

                    frm.Close();
                    var model = (ProductTypeModel)value;
                    model.Select();
                    txtPRODUCT_TYPE_NAME.Text = model.PRODUCT_TYPE_NAME;
                    txtID.Text = model.ID.ToString();
                }
            });
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var model = new ProductTypeModel();
            model.PRODUCT_TYPE_NAME = txtPRODUCT_TYPE_NAME.Text;
            int.TryParse(txtID.Text, out int id);
            model.ID = id;

            if (model.Validate() == false) {
                MessageBox.Show(this, "All values are required", "Save Action failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Save();

            txtID.Text = model.ID.ToString();
            txtPRODUCT_TYPE_NAME.Focus();
            txtPRODUCT_TYPE_NAME.Select();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var model = new ProductTypeModel();
            model.PRODUCT_TYPE_NAME = txtPRODUCT_TYPE_NAME.Text;
            model.Delete();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            foreach (Control control in Controls.Cast<Control>().Where(x => x.GetType().ToString().Contains("TextBox"))) control.Text = "";
            ProductTypeUC_Load(sender, e);
        }
    }
}
