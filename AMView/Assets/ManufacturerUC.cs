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
    public partial class ManufacturerUC : UserControl {
        public ManufacturerUC() {
            InitializeComponent();
        }

        private void ManufacturerUC_Load(object sender, EventArgs e) {
            txtMANUFACTURER_NAME.Focus();
            txtMANUFACTURER_NAME.Select();
        }

        private void btnFind_Click(object sender, EventArgs e) {
            Form frm = new Form() { Text = "Search MANUFACTURER", Size = new Size(500, 300), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new ManufacturerModel().All(),
                DisplayMember = "MANUFACTURER_NAME",
                OnSelected = delegate (object value) {

                    frm.Close();
                    var model = (ManufacturerModel)value;
                    model.Select();
                    txtMANUFACTURER_NAME.Text = model.MANUFACTURER_NAME;
                    txtID.Text = model.ID.ToString();
                }
            });
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var model = new ManufacturerModel();
            model.MANUFACTURER_NAME = txtMANUFACTURER_NAME.Text;
            int.TryParse(txtID.Text, out int id);
            model.ID = id;

            if (model.Validate() == false) {
                MessageBox.Show(this, "All values are required", "Save Action failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Save();

            txtID.Text = model.ID.ToString();
            txtMANUFACTURER_NAME.Focus();
            txtMANUFACTURER_NAME.Select();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var model = new ManufacturerModel();
            model.MANUFACTURER_NAME = txtMANUFACTURER_NAME.Text;
            model.Delete();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            foreach (Control control in Controls.Cast<Control>().Where(x => x.GetType().ToString().Contains("TextBox"))) control.Text = "";
            ManufacturerUC_Load(sender, e);
        }
    }
}
