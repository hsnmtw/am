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
            txtRoleName.Focus();
            txtRoleName.Select();
        }

        private void btnFind_Click(object sender, EventArgs e) {
            Form frm = new Form() { Text = "Search Roles", Size = new Size(200, 500), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new RoleModel().All(),
                DisplayMember = "RoleName",
                ValueMember = "RoleName",
                OnSelected = delegate (object value) {

                    frm.Close();
                    var model = (RoleModel)value;
                    model.Select();
                    txtRoleName.Text = model.RoleName;
                    txtId.Text = model.Id.ToString();
                }
            });
            frm.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var model = new RoleModel();
            model.RoleName = txtRoleName.Text;
            

            if (model.Validate() == false) {
                MessageBox.Show(this, "All values are required", "Save Action failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Save();

            txtId.Text = model.Id.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var model = new RoleModel();
            model.RoleName = txtRoleName.Text;
            model.Delete();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            txtRoleName.Text = "";
            txtId.Text = "0";
        }
    }
}
