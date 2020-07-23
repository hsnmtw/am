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
                    Text = group.GROUP_NAME,
                    Tag = group.ID,
                    Name = group.GROUP_NAME
                });
            }
            this.Refresh();
            this.txtUSER_NAME.Focus();
            this.txtUSER_NAME.Select();
        }

        private void btnFind_Click(object sender, EventArgs e) {
            Form frm = new Form() { Text = "Search Users", Size = new Size(500, 300), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() { 
                Dock = DockStyle.Fill,
                Data = new UserModel().All(),
                DisplayMember = "USER_NAME,GROUP_NAME",
                OnSelected = delegate (object value) {
                    
                    frm.Close();
                    var model = (UserModel)value;
                    model.Select();
                    txtUSER_NAME.Text = model.USER_NAME;
                    txtUSER_PSWD.Text = model.USER_PSWD;
                    ((RadioButton)flpGroups.Controls[model.GROUP_NAME]).Checked = true;
                    txtID.Text = model.ID.ToString();
                }
            });
            frm.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            foreach (Control control in Controls.Cast<Control>().Where(x => x.GetType().ToString().Contains("TextBox"))) control.Text = "";
            UserUC_Load(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            UserModel model = new UserModel();
            int.TryParse(txtID.Text, out int id);
            model.ID = id;
            model.USER_NAME = txtUSER_NAME.Text;
            model.USER_PSWD = txtUSER_PSWD.Text;
            

            if(model.Validate()==false) {
                MessageBox.Show(this,"All values are required","Save Action failed !",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            model.Save();
            txtID.Text = model.ID.ToString();
            txtUSER_NAME.Focus();
            txtUSER_NAME.Select();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            UserModel user = new UserModel();
            user.USER_NAME = txtUSER_NAME.Text;
            user.Delete();
        }
    }
}
