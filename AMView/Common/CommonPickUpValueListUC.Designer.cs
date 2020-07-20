namespace AMView.Common {
    partial class CommonPickUpValueListUC {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lstData = new System.Windows.Forms.ListBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstData
            // 
            this.lstData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstData.FormattingEnabled = true;
            this.lstData.ItemHeight = 15;
            this.lstData.Location = new System.Drawing.Point(2, 19);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(137, 158);
            this.lstData.TabIndex = 0;
            this.lstData.DoubleClick += new System.EventHandler(this.lstData_DoubleClick);
            this.lstData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommonPickUpValueListUC_KeyDown);
            this.lstData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CommonPickUpValueListUC_KeyPress);
            // 
            // lblSearch
            // 
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSearch.Location = new System.Drawing.Point(2, 2);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(137, 17);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "%";
            this.lblSearch.TextChanged += new System.EventHandler(this.lblSearch_TextChanged);
            this.lblSearch.DoubleClick += new System.EventHandler(this.lblSearch_DoubleClick);
            // 
            // CommonPickUpValueListUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.lblSearch);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CommonPickUpValueListUC";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(141, 179);
            this.Load += new System.EventHandler(this.CommonPickUpValueListUC_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommonPickUpValueListUC_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CommonPickUpValueListUC_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstData;
        private System.Windows.Forms.Label lblSearch;
    }
}
