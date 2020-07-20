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
            this.chkIsNew = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtGroupDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chklstRoles = new System.Windows.Forms.CheckedListBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkIsNew
            // 
            this.chkIsNew.AutoSize = true;
            this.chkIsNew.Checked = true;
            this.chkIsNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsNew.Enabled = false;
            this.chkIsNew.Location = new System.Drawing.Point(105, 15);
            this.chkIsNew.Name = "chkIsNew";
            this.chkIsNew.Size = new System.Drawing.Size(59, 17);
            this.chkIsNew.TabIndex = 0;
            this.chkIsNew.Text = "Is New";
            this.chkIsNew.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(51, 466);
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
            this.btnFind.Location = new System.Drawing.Point(289, 92);
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
            this.btnDelete.Location = new System.Drawing.Point(245, 466);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(148, 466);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGroupDesc
            // 
            this.txtGroupDesc.Location = new System.Drawing.Point(104, 120);
            this.txtGroupDesc.Multiline = true;
            this.txtGroupDesc.Name = "txtGroupDesc";
            this.txtGroupDesc.Size = new System.Drawing.Size(216, 34);
            this.txtGroupDesc.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "&Description";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(104, 93);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(183, 20);
            this.txtGroupName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Group Name";
            // 
            // chklstRoles
            // 
            this.chklstRoles.FormattingEnabled = true;
            this.chklstRoles.Location = new System.Drawing.Point(17, 161);
            this.chklstRoles.Name = "chklstRoles";
            this.chklstRoles.Size = new System.Drawing.Size(303, 289);
            this.chklstRoles.TabIndex = 8;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(105, 67);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(61, 20);
            this.txtId.TabIndex = 2;
            this.txtId.TabStop = false;
            this.txtId.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Id";
            // 
            // GroupUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chklstRoles);
            this.Controls.Add(this.chkIsNew);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGroupDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.label1);
            this.Name = "GroupUC";
            this.Size = new System.Drawing.Size(332, 510);
            this.Load += new System.EventHandler(this.GroupUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIsNew;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtGroupDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chklstRoles;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
    }
}
