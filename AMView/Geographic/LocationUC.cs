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
    public partial class LocationUC : UserControl {
        public LocationUC() {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e) {
            Form frm = new Form() { Text = "Search Locations", Size = new Size(500, 300), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new LocationModel().All(),
                DisplayMember = "LOCATION_NAME",
                OnSelected = delegate (object value) {

                    frm.Close();
                    var model = (LocationModel)value;
                    model.Select();
                    txtLOCATION_NAME.Text = model.LOCATION_NAME;
                    txtID.Text = model.ID.ToString();
                }
            });
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var model = new LocationModel();
            model.ID = int.Parse(txtID.Text);
            model.LOCATION_NAME = txtLOCATION_NAME.Text;
            model.Delete();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var model = new LocationModel();

            model.LOCATION_NAME = txtLOCATION_NAME.Text;
            
            int.TryParse(txtID.Text, out int id);
            model.ID = id;

            if (model.Validate() == false) {
                MessageBox.Show(this, "All values are required", "Save Action failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.Save();

            txtID.Text = model.ID.ToString();
            txtLOCATION_NAME.Focus();
            txtLOCATION_NAME.Select();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            foreach (Control control in Controls.Cast<Control>().Where(x => x.GetType().ToString().Contains("TextBox"))) control.Text = "";
            LocationUC_Load(sender, e);
        }

        private void LocationUC_Load(object sender, EventArgs e) {
            txtLOCATION_NAME.Focus();
            txtLOCATION_NAME.Select();
            txtID.Text = "0";
        }
    }
}
