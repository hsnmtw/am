﻿namespace AMView.Geographic {
    partial class RoomUC {
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
            this.txtROOM_NAME = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtLOCATION_NAME = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLookUpBuilding = new System.Windows.Forms.Button();
            this.txtBUILDING_NAME = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(50, 124);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(288, 29);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(31, 22);
            this.btnFind.TabIndex = 4;
            this.btnFind.TabStop = false;
            this.btnFind.Text = "···";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(244, 124);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(147, 124);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtROOM_NAME
            // 
            this.txtROOM_NAME.Location = new System.Drawing.Point(103, 30);
            this.txtROOM_NAME.MaxLength = 20;
            this.txtROOM_NAME.Name = "txtROOM_NAME";
            this.txtROOM_NAME.Size = new System.Drawing.Size(183, 20);
            this.txtROOM_NAME.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Room Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Id";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(103, 4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(61, 20);
            this.txtID.TabIndex = 1;
            this.txtID.TabStop = false;
            this.txtID.Text = "0";
            // 
            // txtLOCATION_NAME
            // 
            this.txtLOCATION_NAME.Location = new System.Drawing.Point(103, 81);
            this.txtLOCATION_NAME.MaxLength = 20;
            this.txtLOCATION_NAME.Name = "txtLOCATION_NAME";
            this.txtLOCATION_NAME.ReadOnly = true;
            this.txtLOCATION_NAME.Size = new System.Drawing.Size(183, 20);
            this.txtLOCATION_NAME.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "&Location Name";
            // 
            // btnLookUpBuilding
            // 
            this.btnLookUpBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLookUpBuilding.Location = new System.Drawing.Point(288, 54);
            this.btnLookUpBuilding.Name = "btnLookUpBuilding";
            this.btnLookUpBuilding.Size = new System.Drawing.Size(31, 22);
            this.btnLookUpBuilding.TabIndex = 7;
            this.btnLookUpBuilding.TabStop = false;
            this.btnLookUpBuilding.Text = "▽";
            this.btnLookUpBuilding.UseVisualStyleBackColor = true;
            this.btnLookUpBuilding.Click += new System.EventHandler(this.btnLookUpBuilding_Click);
            // 
            // txtBUILDING_NAME
            // 
            this.txtBUILDING_NAME.Location = new System.Drawing.Point(103, 55);
            this.txtBUILDING_NAME.MaxLength = 20;
            this.txtBUILDING_NAME.Name = "txtBUILDING_NAME";
            this.txtBUILDING_NAME.ReadOnly = true;
            this.txtBUILDING_NAME.Size = new System.Drawing.Size(183, 20);
            this.txtBUILDING_NAME.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "&Building Name";
            // 
            // RoomUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLookUpBuilding);
            this.Controls.Add(this.txtBUILDING_NAME);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLOCATION_NAME);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtROOM_NAME);
            this.Controls.Add(this.label1);
            this.Name = "RoomUC";
            this.Size = new System.Drawing.Size(332, 168);
            this.Load += new System.EventHandler(this.RoomUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtROOM_NAME;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtLOCATION_NAME;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLookUpBuilding;
        private System.Windows.Forms.TextBox txtBUILDING_NAME;
        private System.Windows.Forms.Label label4;
    }
}
