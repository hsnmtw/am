using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMView.Common {
    public partial class CommonPickUpValueListUC : UserControl {

        public object[] Data { get; set; }

        public string DisplayMember { get; set; }
        //public string ValueMember { get; set; }

        public Action<object> OnSelected { get; set; }

        public CommonPickUpValueListUC() {
            InitializeComponent();
        }

        private void CommonPickUpValueListUC_Load(object sender, EventArgs e) {
            dgvData.AutoGenerateColumns = false;
            foreach(var member in DisplayMember.Split(',')) { 
                dgvData.Columns.Add(new DataGridViewTextBoxColumn() {
                    HeaderText       = member.Replace("_"," "),
                    Name             = member,
                    DataPropertyName = member,
                    ReadOnly         = true,
                    AutoSizeMode     = DataGridViewAutoSizeColumnMode.Fill,
                });
            }
            dgvData.DataSource = Data;
        }

        private void CommonPickUpValueListUC_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Back) {
                if (lblSearch.Text.Length > 0) {
                    lblSearch.Text = lblSearch.Text.Substring(0, lblSearch.Text.Length - 1);
                    e.SuppressKeyPress = true;
                }
            } else {
                if(e.KeyCode == Keys.Enter) {
                    //lstData_DoubleClick(sender, null);
                }
            }
            
        }

        private void CommonPickUpValueListUC_KeyPress(object sender, KeyPressEventArgs e) {
            if (@" abcdefghijklmnopqrstuvwxyz1234567890-=/\|.,;?!@#$%^&*()_+".Contains(e.KeyChar.ToString().ToLower())) {
                lblSearch.Text += e.KeyChar;
            } 
        }

        private void lblSearch_TextChanged(object sender, EventArgs e) {
            //List<object> result = new List<object>();
            //foreach(var val in data) {
            //    if( val.GetType().GetProperty(DisplayMember).GetValue(val).ToString().ToLower().Contains(lblSearch.Text.ToLower())) {
            //        result.Add(val);
            //    }
            //}
            //lstData.Items.Clear();
            //lstData.Items.AddRange(result.ToArray());
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            OnSelected(Data[dgvData.SelectedRows[0].Index]);
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && dgvData.SelectedRows.Count > 0) {
                e.SuppressKeyPress = true;
                e.Handled = true;

                dgvData_CellDoubleClick(null, null);
            }
        }
    }
}
