using AMModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMView {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        

        private void MainForm_Load(object sender, EventArgs e) {
            var login = new LoginForm();
            login.ShowDialog();
            if (login.DialogResult == DialogResult.Abort) Application.Exit();
            this.lstMenu.Items.Clear();
            if (login.DialogResult == DialogResult.OK) {
                Session.Instance.CurrentUser = login.User;
                var roles = new GroupRoleModel() { GroupName = Session.Instance.CurrentUser.GroupName }.SearchByGroupName();
                foreach (var role in roles) {
                    this.lstMenu.Items.Add(role.RoleName);
                }
            }

            
            
            
        }

        public void OpenForm(string uc) {
            Type formUserControl = Type.GetType(uc);
            pnlRightPane.Controls.Clear();
            pnlRightPane.Controls.Add( (Control) Activator.CreateInstance(formUserControl) );
        }

        private void lstMenu_DoubleClick(object sender, EventArgs e) {
            switch (lstMenu.SelectedItem) {
                case "SQLView": OpenForm("AMView.SQL.SQLViewUC");          break;
                case "Groups" : OpenForm("AMView.Security.Group.GroupUC"); break;
                case "Roles"  : OpenForm("AMView.Security.Role.RoleUC");   break;
                case "Users"  : OpenForm("AMView.Security.User.UserUC");   break;
            }
        }
    }
}
