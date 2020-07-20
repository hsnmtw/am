using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AMModel;

namespace AMView.SQL {
    public partial class SQLViewUC : UserControl {
        
        public SQLViewUC() {
            InitializeComponent();
        }

        private void btnRUN_Click(object sender, EventArgs e) {
            
            txtResult.Text = "";
            if (txtSQL.Text.ToUpper().Trim().StartsWith("SELECT")) {
                txtResult.Text = DefaultConnection.Instance.GetCSV(sql: txtSQL.Text);
            } else {
                txtResult.Text = DefaultConnection.Instance.Execute(sql: txtSQL.Text).ToString() + " Rows affected";
            }
        }

        private void SQLViewUC_Load(object sender, EventArgs e) {
            this.Refresh();
            this.txtSQL.Focus();
            this.txtSQL.Select();
        }
    }
}
