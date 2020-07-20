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
    public partial class GroupUC : UserControl {
        public GroupUC() {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e) {
            Form frm = new Form() { Text = "Search Groups", Size = new Size(200, 500), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new GroupModel().All(),
                DisplayMember = "GroupName",
                ValueMember = "GroupName",
                OnSelected = delegate (object value) {
                    
                    frm.Close();
                    var model = (GroupModel)value;
                    model.Select();
                    txtGroupName.Text = model.GroupName;
                    txtGroupDesc.Text = model.GroupDesc;
                    txtId.Text = model.Id.ToString();
                    var cmodel = new GroupRoleModel();
                    cmodel.GroupName = model.GroupName;
                    var roles = cmodel.SearchByGroupName();
                    btnSelectNone_Click(null, null);
                    foreach(var role in roles) {
                        ((CheckBox)flpRoles.Controls[role.RoleName]).Checked = true;
                    }
                }
            });
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var model = new GroupModel();
            model.GroupName = txtGroupName.Text;
            model.Id = int.Parse(txtId.Text);
            model.Delete();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var model = new GroupModel();
            model.GroupName = txtGroupName.Text;
            model.GroupDesc = txtGroupDesc.Text;

            if (model.Validate() == false) {
                MessageBox.Show(this, "All values are required", "Save Action failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Save();

            var grmodel = new GroupRoleModel();
            grmodel.GroupName = model.GroupName;
            grmodel.DeleteByGroupName();
            
            

            
            txtId.Text = model.Id.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            
            txtId.Text = "0";
            txtGroupDesc.Text = "";
            txtGroupName.Text = "";
            btnSelectNone_Click(null, null);
        }

        private void GroupUC_Load(object sender, EventArgs e) {
            txtGroupName.Focus();
            txtGroupName.Select();
            var model = new RoleModel();

            flpRoles.HorizontalScroll.Visible = false;
            flpRoles.HorizontalScroll.Maximum = 0;

            foreach (var role in model.All().OrderBy(x => x.RoleName)) {
                flpRoles.Controls.Add(new CheckBox() {
                    Name = role.RoleName,
                    Text = role.RoleName,
                    Tag  = role.Id,
                    AutoSize = false
                });
            }

        }

        private void btnSelectAll_Click(object sender, EventArgs e) {
            foreach(CheckBox chk in flpRoles.Controls) {
                chk.Checked = true;
            }
        }

        private void btnSelectNone_Click(object sender, EventArgs e) {
            foreach (CheckBox chk in flpRoles.Controls) {
                chk.Checked = false;
            }
        }
    }
}
