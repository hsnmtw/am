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
    public partial class BuildingUC : UserControl {
        public BuildingUC() {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e) {
            Form frm = new Form() { Text = "Search Buildings", Size = new Size(500, 300), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new BuildingModel().All(),
                DisplayMember = "BUILDING_NAME",
                OnSelected = delegate (object value) {

                    frm.Close();
                    var model = (BuildingModel)value;
                    model.Select();
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
            model.BUILDING_NAME = txtBUILDING_NAME.Text;
            model.Delete();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var model = new BuildingModel();

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
            txtBUILDING_NAME.Focus();
            txtBUILDING_NAME.Select();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            foreach (Control control in Controls.Cast<Control>().Where(x => x.GetType().ToString().Contains("TextBox"))) control.Text = "";
            BuildingUC_Load(sender, e);
        }

        private void BuildingUC_Load(object sender, EventArgs e) {
            txtBUILDING_NAME.Focus();
            txtBUILDING_NAME.Select();
            txtID.Text = "0";
        }

        private void btnLookUpLocation_Click(object sender, EventArgs e) {
            Form frm = new Form() { Text = "Search Locations", Size = new Size(500, 300), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new LocationModel().All(),
                DisplayMember = "LOCATION_NAME",
                OnSelected = delegate (object value) {

                    frm.Close();
                    var model = (LocationModel)value;
                    txtLOCATION_NAME.Text = model.LOCATION_NAME;
                }
            });
            frm.ShowDialog();
        }
    }
}
