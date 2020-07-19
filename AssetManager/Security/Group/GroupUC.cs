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

namespace AMView.Security.Group {
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
                    this.chkIsNew.Checked = false;
                    frm.Close();
                    var model = (GroupModel)value;
                    model.Select();
                    txtGroupName.Text = model.GroupName;
                    txtGroupDesc.Text = model.GroupDesc;

                    var cmodel = new GroupRoleModel();
                    cmodel.GroupName = model.GroupName;
                    var roles = cmodel.SearchByGroupName().Select(x => x.RoleName).OrderBy(x => x);
                    for(int i = 0; i < chklstRoles.Items.Count; i++) {
                        chklstRoles.SetItemChecked(i, roles.Contains(chklstRoles.Items[i].ToString()));
                    }
                }
            });
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var model = new GroupModel();
            model.GroupName = txtGroupName.Text;
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

            if (this.chkIsNew.Checked) {
                model.Insert();
            } else {
                model.Update();
            }

            var grmodel = new GroupRoleModel();
            grmodel.GroupName = model.GroupName;
            grmodel.DeleteByGroupName();
            
            for(int i = 0; i < chklstRoles.Items.Count; i++) {
                if (chklstRoles.GetItemChecked(i)) {
                    grmodel.RoleName = chklstRoles.Items[i].ToString();
                    grmodel.Insert();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e) {
            txtGroupDesc.Text = "";
            txtGroupName.Text = "";
            for(int i=0;i< chklstRoles.Items.Count;i++) {
                chklstRoles.SetItemChecked(i, false);
            }
        }

        private void GroupUC_Load(object sender, EventArgs e) {
            txtGroupName.Focus();
            txtGroupName.Select();
            var model = new RoleModel();
            foreach(var role in model.All().OrderBy(x => x.RoleName)) {
                chklstRoles.Items.Add(role.RoleName);
            }
        }
    }
}
