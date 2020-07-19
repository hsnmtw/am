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

        private object[] data;
        public object[] Data { 
            set { 
                data = value;
            } 
        }
        public string DisplayMember {
            get { return lstData.DisplayMember; }
            set { lstData.DisplayMember = value; }
        }
        public string ValueMember {
            get { return lstData.ValueMember; }
            set { lstData.ValueMember = value; }
        }

        public Action<object> OnSelected { get; set; }

        public string SelectedValue { get { return lstData.Text; } }

        public CommonPickUpValueListUC() {
            InitializeComponent();
        }

        private void CommonPickUpValueListUC_Load(object sender, EventArgs e) {
            lstData.Items.Clear();
            lstData.Items.AddRange(data);
        }

        private void CommonPickUpValueListUC_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Back) {
                if (lblSearch.Text.Length > 0) {
                    lblSearch.Text = lblSearch.Text.Substring(0, lblSearch.Text.Length - 1);
                    e.SuppressKeyPress = true;
                }
            } else {
                if(e.KeyCode == Keys.Enter) {
                    lstData_DoubleClick(sender, null);
                }
            }
            
        }

        private void CommonPickUpValueListUC_KeyPress(object sender, KeyPressEventArgs e) {
            if (@" abcdefghijklmnopqrstuvwxyz1234567890-=/\|.,;?!@#$%^&*()_+".Contains(e.KeyChar.ToString().ToLower())) {
                lblSearch.Text += e.KeyChar;
            } 
        }

        private void lblSearch_TextChanged(object sender, EventArgs e) {
            List<object> result = new List<object>();
            foreach(var val in data) {
                if( val.GetType().GetProperty(DisplayMember).GetValue(val).ToString().ToLower().Contains(lblSearch.Text.ToLower())) {
                    result.Add(val);
                }
            }
            lstData.Items.Clear();
            lstData.Items.AddRange(result.ToArray());
        }

        private void lblSearch_DoubleClick(object sender, EventArgs e) {
            if (lstData.SelectedIndex > -1) {
                this.OnSelected(lstData.SelectedItem);
            }
        }

        private void lstData_DoubleClick(object sender, EventArgs e) {
            if (lstData.SelectedIndex > -1) {
                this.OnSelected(lstData.SelectedItem);
            }
        }
    }
}
