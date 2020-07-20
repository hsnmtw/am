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

namespace AMView.Security.Role {
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
                    this.chkIsNew.Checked = false;
                    frm.Close();
                    var role = (RoleModel)value;
                    role.Select();
                    txtRoleName.Text = role.RoleName;
                    
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

            if (this.chkIsNew.Checked) {
                model.Insert();
            } else {
                model.Update();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var model = new RoleModel();
            model.RoleName = txtRoleName.Text;
            model.Delete();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            txtRoleName.Text = "";
        }
    }
}
