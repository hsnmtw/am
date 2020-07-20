namespace AMView.Security {
    partial class GroupUC {
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtGroupDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.gboxRoles = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.flpRoles = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.gboxRoles.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(43, 474);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(279, 32);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(31, 22);
            this.btnFind.TabIndex = 5;
            this.btnFind.TabStop = false;
            this.btnFind.Text = "···";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(237, 474);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(140, 474);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGroupDesc
            // 
            this.txtGroupDesc.Location = new System.Drawing.Point(94, 60);
            this.txtGroupDesc.Multiline = true;
            this.txtGroupDesc.Name = "txtGroupDesc";
            this.txtGroupDesc.Size = new System.Drawing.Size(216, 34);
            this.txtGroupDesc.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "&Description";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(94, 33);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(183, 20);
            this.txtGroupName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Group Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(95, 7);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(61, 20);
            this.txtId.TabIndex = 2;
            this.txtId.TabStop = false;
            this.txtId.Text = "0";
            // 
            // gboxRoles
            // 
            this.gboxRoles.Controls.Add(this.flpRoles);
            this.gboxRoles.Location = new System.Drawing.Point(94, 100);
            this.gboxRoles.Name = "gboxRoles";
            this.gboxRoles.Padding = new System.Windows.Forms.Padding(8, 1, 8, 8);
            this.gboxRoles.Size = new System.Drawing.Size(216, 368);
            this.gboxRoles.TabIndex = 14;
            this.gboxRoles.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Roles";
            // 
            // flpRoles
            // 
            this.flpRoles.AutoScroll = true;
            this.flpRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpRoles.Location = new System.Drawing.Point(8, 14);
            this.flpRoles.Name = "flpRoles";
            this.flpRoles.Size = new System.Drawing.Size(200, 346);
            this.flpRoles.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(318, 108);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(54, 26);
            this.btnSelectAll.TabIndex = 15;
            this.btnSelectAll.Text = "&All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Location = new System.Drawing.Point(318, 140);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(54, 26);
            this.btnSelectNone.TabIndex = 15;
            this.btnSelectNone.Text = "&None";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // GroupUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.gboxRoles);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGroupDesc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.label1);
            this.Name = "GroupUC";
            this.Size = new System.Drawing.Size(391, 510);
            this.Load += new System.EventHandler(this.GroupUC_Load);
            this.gboxRoles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtGroupDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.GroupBox gboxRoles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flpRoles;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSelectNone;
    }
}
