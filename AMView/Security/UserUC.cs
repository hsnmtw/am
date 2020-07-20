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
    public partial class UserUC : UserControl {
        public UserUC() {
            InitializeComponent();
        }
        
        private void UserUC_Load(object sender, EventArgs e) {
            flpGroups.HorizontalScroll.Visible = false;
            var groups = new GroupModel().All();
            foreach (var group in groups) {
                flpGroups.Controls.Add(new RadioButton() {
                    Text = group.GroupName,
                    Tag = group.Id,
                    Name = group.GroupName
                });
            }
            this.Refresh();
            this.txtUserName.Focus();
            this.txtUserName.Select();
        }

        private void btnFind_Click(object sender, EventArgs e) {
            Form frm = new Form() { Text = "Search Users", Size = new Size(200,500), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() { 
                Dock = DockStyle.Fill,
                Data = new UserModel().All(),
                DisplayMember = "UserName",
                ValueMember = "UserName",
                OnSelected = delegate (object value) {
                    
                    frm.Close();
                    var model = (UserModel)value;
                    model.Select();
                    txtUserName.Text = model.UserName;
                    txtPassword.Text = model.UserPswd;
                    ((RadioButton)flpGroups.Controls[model.GroupName]).Checked = true;
                    txtId.Text = model.Id.ToString();
                }
            });
            frm.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            txtId.Text = "0";
            txtPassword.Text = "";
            txtUserName.Text = "";
            
        }

        private void btnSave_Click(object sender, EventArgs e) {
            UserModel model = new UserModel();
            model.UserName = txtUserName.Text;
            model.UserPswd = txtPassword.Text;
            

            if(model.Validate()==false) {
                MessageBox.Show(this,"All values are required","Save Action failed !",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            model.Save();
            txtId.Text = model.Id.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            UserModel user = new UserModel();
            user.UserName = txtUserName.Text;
            user.Delete();
        }
    }
}
