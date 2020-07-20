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
            Form frm = new Form() { Text = "Search Locations", Size = new Size(200, 500), StartPosition = FormStartPosition.CenterParent };
            frm.Controls.Add(new Common.CommonPickUpValueListUC() {
                Dock = DockStyle.Fill,
                Data = new LocationModel().All(),
                DisplayMember = "LocationName",
                ValueMember = "LocationName",
                OnSelected = delegate (object value) {
                    this.chkIsNew.Checked = false;
                    frm.Close();
                    var model = (LocationModel)value;
                    model.Select();
                    txtLocationName.Text = model.LocationName;
                    

                    
                }
            });
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var model = new LocationModel();
            model.Id = int.Parse(txtId.Text);
            model.LocationName = txtLocationName.Text;
            model.Delete();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var model = new LocationModel();
            model.LocationName = txtLocationName.Text;
            model.Id = int.Parse(txtId.Text);

            if (model.Validate() == false) {
                MessageBox.Show(this, "All values are required", "Save Action failed !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.chkIsNew.Checked) {
                model.Insert();
            } else {
                model.Update();
            }

            chkIsNew.Checked = false;
            txtId.Text = model.Id.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            txtId.Text = "0";
            txtLocationName.Text = "";
            chkIsNew.Checked = true;
        }

        private void LocationUC_Load(object sender, EventArgs e) {
            txtLocationName.Focus();
            txtLocationName.Select();
            txtId.Text = "0";
        }
    }
}
