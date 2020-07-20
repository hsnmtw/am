namespace AMView {
    partial class MainForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pnlLeftPane = new System.Windows.Forms.Panel();
            this.pnlRightPane = new System.Windows.Forms.Panel();
            this.lstMenu = new System.Windows.Forms.ListBox();
            this.pnlLeftPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftPane
            // 
            this.pnlLeftPane.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlLeftPane.Controls.Add(this.lstMenu);
            this.pnlLeftPane.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftPane.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftPane.Name = "pnlLeftPane";
            this.pnlLeftPane.Padding = new System.Windows.Forms.Padding(3);
            this.pnlLeftPane.Size = new System.Drawing.Size(200, 650);
            this.pnlLeftPane.TabIndex = 0;
            // 
            // pnlRightPane
            // 
            this.pnlRightPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightPane.Location = new System.Drawing.Point(200, 0);
            this.pnlRightPane.Name = "pnlRightPane";
            this.pnlRightPane.Padding = new System.Windows.Forms.Padding(3);
            this.pnlRightPane.Size = new System.Drawing.Size(1001, 650);
            this.pnlRightPane.TabIndex = 1;
            // 
            // lstMenu
            // 
            this.lstMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMenu.FormattingEnabled = true;
            this.lstMenu.ItemHeight = 16;
            this.lstMenu.Location = new System.Drawing.Point(3, 3);
            this.lstMenu.Name = "lstMenu";
            this.lstMenu.Size = new System.Drawing.Size(194, 644);
            this.lstMenu.TabIndex = 0;
            this.lstMenu.DoubleClick += new System.EventHandler(this.lstMenu_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 650);
            this.Controls.Add(this.pnlRightPane);
            this.Controls.Add(this.pnlLeftPane);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlLeftPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftPane;
        private System.Windows.Forms.Panel pnlRightPane;
        private System.Windows.Forms.ListBox lstMenu;
    }
}