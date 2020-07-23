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

namespace AMView.Security {
    public partial class RoleUC : UserControl {
        public RoleUC() {
            InitializeComponent();
        }

        private void RoleUC_Load(object sender, EventArgs e) {
            txtROLE_NAME.Focus();
            txtROLE_NAME.Select();
        }

        private void btnFind_Click(object sender, EventArgs e) {
            Form frm = new Form() { Text = "Search Roles", Size = new Size(500, 300), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new RoleModel().All(),
                DisplayMember = "ROLE_NAME",
                OnSelected = delegate (object value) {

                    frm.Close();
                    var model = (RoleModel)value;
                    model.Select();
                    txtROLE_NAME.Text = model.ROLE_NAME;
                    txtID.Text = model.ID.ToString();
                }
            });
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var model = new RoleModel();
            model.ROLE_NAME = txtROLE_NAME.Text;
            int.TryParse(txtID.Text, out int id);
            model.ID = id;

            if (model.Validate() == false) {
                MessageBox.Show(this, "All values are required", "Save Action failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Save();

            txtID.Text = model.ID.ToString();
            txtROLE_NAME.Focus();
            txtROLE_NAME.Select();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var model = new RoleModel();
            model.ROLE_NAME = txtROLE_NAME.Text;
            model.Delete();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            foreach (Control control in Controls.Cast<Control>().Where(x => x.GetType().ToString().Contains("TextBox"))) control.Text = "";
            RoleUC_Load(sender, e);
        }
    }
}
