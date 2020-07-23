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

namespace AMView.Geographic {
    public partial class RoomUC : UserControl {
        public RoomUC() {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e) {
            Form frm = new Form() { Text = "Search Rooms", Size = new Size(500, 300), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new RoomModel().All(),
                DisplayMember = "ROOM_NAME,BUILDING_NAME,LOCATION_NAME",
                OnSelected = delegate (object value) {

                    frm.Close();
                    var model = (RoomModel)value;
                    model.Select();
                    txtROOM_NAME.Text = model.ROOM_NAME;
                    txtBUILDING_NAME.Text = model.BUILDING_NAME;
                    txtLOCATION_NAME.Text = model.LOCATION_NAME;
                    txtID.Text = model.ID.ToString();
                }
            });
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var model = new BuildingModel();
            model.ID = int.Parse(txtID.Text);
            model.BUILDING_NAME = txtROOM_NAME.Text;
            model.Delete();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var model = new RoomModel();

            model.ROOM_NAME = txtROOM_NAME.Text;
            model.BUILDING_NAME = txtBUILDING_NAME.Text;
            model.LOCATION_NAME = txtLOCATION_NAME.Text;

            int.TryParse(txtID.Text, out int id);
            model.ID = id;

            if (model.Validate() == false) {
                MessageBox.Show(this, "All values are required", "Save Action failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Save();

            txtID.Text = model.ID.ToString();
            txtROOM_NAME.Focus();
            txtROOM_NAME.Select();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            foreach (Control control in Controls.Cast<Control>().Where(x => x.GetType().ToString().Contains("TextBox"))) control.Text = "";
            RoomUC_Load(sender, e);
        }

        private void RoomUC_Load(object sender, EventArgs e) {
            txtROOM_NAME.Focus();
            txtROOM_NAME.Select();
            txtID.Text = "0";
        }



        private void btnLookUpBuilding_Click(object sender, EventArgs e) {
            var frm = new Form() { Text = "Search Buildings", Size = new Size(500, 300), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new BuildingModel().All(),
                DisplayMember = "BUILDING_NAME,LOCATION_NAME",
                OnSelected = delegate (object value) {
                    frm.Close();
                    var model = (BuildingModel)value;
                    txtBUILDING_NAME.Text = model.BUILDING_NAME;
                    txtLOCATION_NAME.Text = model.LOCATION_NAME;
                }
            });
            frm.ShowDialog();
        }
    }
}
