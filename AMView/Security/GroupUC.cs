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
            Form frm = new Form() { Text = "Search Groups", Size = new Size(500, 300), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new GroupModel().All(),
                DisplayMember = "GROUP_NAME",
                OnSelected = delegate (object value) {
                    
                    frm.Close();
                    var model = (GroupModel)value;
                    model.Select();
                    txtGROUP_NAME.Text = model.GROUP_NAME;
                    txtGROUP_DESC.Text = model.GROUP_DESC;
                    txtID.Text = model.ID.ToString();
                    var cmodel = new GroupRoleModel();
                    cmodel.GROUP_NAME = model.GROUP_NAME;
                    var roles = cmodel.SearchByGROUP_NAME();
                    btnSelectNone_Click(null, null);
                    foreach(var role in roles) {
                        ((CheckBox)flpRoles.Controls[role.ROLE_NAME]).Checked = true;
                    }
                }
            });
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var model = new GroupModel();
            model.GROUP_NAME = txtGROUP_NAME.Text;
            model.ID = int.Parse(txtID.Text);
            model.Delete();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var model = new GroupModel();
            int.TryParse(txtID.Text, out int id);
            model.ID = id;
            model.GROUP_NAME = txtGROUP_NAME.Text;
            model.GROUP_DESC = txtGROUP_DESC.Text;

            if (model.Validate() == false) {
                MessageBox.Show(this, "All values are required", "Save Action failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Save();

            var grmodel = new GroupRoleModel();
            grmodel.GROUP_NAME = model.GROUP_NAME;
            grmodel.DeleteByGROUP_NAME();
            
            foreach(CheckBox role in flpRoles.Controls) {
                grmodel.ROLE_NAME = role.Text;
                grmodel.ID = -1;
                grmodel.Save();
            }

            txtID.Text = model.ID.ToString();
            txtGROUP_NAME.Focus();
            txtGROUP_NAME.Select();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            foreach (Control control in Controls.Cast<Control>().Where(x => x.GetType().ToString().Contains("TextBox"))) control.Text = "";
            btnSelectNone_Click(null, null);
            GroupUC_Load(sender, e);
        }

        private void GroupUC_Load(object sender, EventArgs e) {
            txtGROUP_NAME.Focus();
            txtGROUP_NAME.Select();
            var model = new RoleModel();

            flpRoles.HorizontalScroll.Visible = false;
            flpRoles.HorizontalScroll.Maximum = 0;

            foreach (var role in model.All().OrderBy(x => x.ROLE_NAME)) {
                flpRoles.Controls.Add(new CheckBox() {
                    Name = role.ROLE_NAME,
                    Text = role.ROLE_NAME,
                    Tag  = role.ID,
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
