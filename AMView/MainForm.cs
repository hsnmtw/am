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
                var roles = new GroupRoleModel() { GROUP_NAME = Session.Instance.CurrentUser.GROUP_NAME }.SearchByGROUP_NAME();
                foreach (var role in roles) {
                    this.lstMenu.Items.Add(role.ROLE_NAME);
                }
            }

            
            
            
        }

        public void OpenForm(string uc) {
            Type formUserControl = Type.GetType(uc);
            pnlRightPane.Controls.Clear();
            pnlRightPane.Controls.Add( (Control) Activator.CreateInstance(formUserControl) );
        }

        private void lstMenu_DoubleClick(object sender, EventArgs e) {
            var dictionary = new Dictionary<string, string> {
                { "SQLView"      , "AMView.SQL.SQLViewUC"          },
                 
                { "Groups"       , "AMView.Security.GroupUC"       },
                { "Roles"        , "AMView.Security.RoleUC"        },
                { "Users"        , "AMView.Security.UserUC"        },

                { "Locations"    , "AMView.Geographic.LocationUC"  },
                { "Buildings"    , "AMView.Geographic.BuildingUC"  },
                { "Rooms"        , "AMView.Geographic.RoomUC"      },

                { "Staff"        , "AMView.Assets.StaffUC"         },
                { "Manufacturer" , "AMView.Assets.ManufacturerUC"  },
                { "ProductType"  , "AMView.Assets.ProductTypeUC"   },
            };
            if (dictionary.ContainsKey(lstMenu.SelectedItem+"")) {
                OpenForm(dictionary[lstMenu.SelectedItem+""]);
            }
        }
    }
}
