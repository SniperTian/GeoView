namespace GeoView
{
    partial class Label
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFontColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chbMask = new System.Windows.Forms.CheckBox();
            this.btnFont = new System.Windows.Forms.Button();
            this.labelFontDialog = new System.Windows.Forms.FontDialog();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbVisible = new System.Windows.Forms.CheckBox();
            this.cldLabel = new System.Windows.Forms.ColorDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.labelFontSize = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(75, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "字段:";
            // 
            // cboField
            // 
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.FormattingEnabled = true;
            this.cboField.Location = new System.Drawing.Point(129, 45);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(121, 20);
            this.cboField.TabIndex = 23;
            this.cboField.SelectedIndexChanged += new System.EventHandler(this.cboField_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(75, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "颜色:";
            // 
            // btnFontColor
            // 
            this.btnFontColor.BackColor = System.Drawing.Color.Black;
            this.btnFontColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFontColor.Location = new System.Drawing.Point(129, 95);
            this.btnFontColor.Name = "btnFontColor";
            this.btnFontColor.Size = new System.Drawing.Size(121, 24);
            this.btnFontColor.TabIndex = 27;
            this.btnFontColor.UseVisualStyleBackColor = false;
            this.btnFontColor.Click += new System.EventHandler(this.btnFontColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(75, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "字体:";
            // 
            // chbMask
            // 
            this.chbMask.AutoSize = true;
            this.chbMask.Font = new System.Drawing.Font("宋体", 12F);
            this.chbMask.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chbMask.Location = new System.Drawing.Point(46, 210);
            this.chbMask.Name = "chbMask";
            this.chbMask.Size = new System.Drawing.Size(58, 20);
            this.chbMask.TabIndex = 32;
            this.chbMask.Text = "描边";
            this.chbMask.UseVisualStyleBackColor = true;
            this.chbMask.CheckedChanged += new System.EventHandler(this.chbMask_CheckedChanged);
            // 
            // btnFont
            // 
            this.btnFont.BackColor = System.Drawing.Color.Transparent;
            this.btnFont.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFont.Location = new System.Drawing.Point(129, 147);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(121, 24);
            this.btnFont.TabIndex = 33;
            this.btnFont.Text = "宋体";
            this.btnFont.UseVisualStyleBackColor = false;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(78, 292);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 34;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(175, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelFontSize);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chbVisible);
            this.groupBox1.Controls.Add(this.chbMask);
            this.groupBox1.Location = new System.Drawing.Point(32, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 249);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // chbVisible
            // 
            this.chbVisible.AutoSize = true;
            this.chbVisible.Font = new System.Drawing.Font("宋体", 12F);
            this.chbVisible.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chbVisible.Location = new System.Drawing.Point(128, 210);
            this.chbVisible.Name = "chbVisible";
            this.chbVisible.Size = new System.Drawing.Size(90, 20);
            this.chbVisible.TabIndex = 37;
            this.chbVisible.Text = "显示注记";
            this.chbVisible.UseVisualStyleBackColor = true;
            this.chbVisible.CheckedChanged += new System.EventHandler(this.chbVisible_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(43, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "字体大小:";
            // 
            // labelFontSize
            // 
            this.labelFontSize.AutoSize = true;
            this.labelFontSize.Font = new System.Drawing.Font("宋体", 12F);
            this.labelFontSize.Location = new System.Drawing.Point(125, 175);
            this.labelFontSize.Name = "labelFontSize";
            this.labelFontSize.Size = new System.Drawing.Size(23, 16);
            this.labelFontSize.TabIndex = 37;
            this.labelFontSize.Text = "12";
            // 
            // Label
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 351);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFontColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.groupBox1);
            this.Name = "Label";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "注记";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFontColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbMask;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.FontDialog labelFontDialog;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbVisible;
        private System.Windows.Forms.ColorDialog cldLabel;
        private System.Windows.Forms.Label labelFontSize;
        private System.Windows.Forms.Label label4;
    }
}