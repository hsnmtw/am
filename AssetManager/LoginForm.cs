using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AMModel.Models;

namespace AMView
{
    public partial class LoginForm : Form
    {
        public UserModel User { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            User = new UserModel();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (User.Authenticate(txtUserName.Text, txtPassword.Text))
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(this,"Username / password combination not correct", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Abort;
        }
    }
}
