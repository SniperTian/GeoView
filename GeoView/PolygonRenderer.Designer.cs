namespace GeoView
{
    partial class PolygonRenderer
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
            this.btnPolygonRendererCancel = new System.Windows.Forms.Button();
            this.btnPolygonRendererConfirm = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnClassBreaksEndColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClassBreaksStartColor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudClassBreaksNum = new System.Windows.Forms.NumericUpDown();
            this.cboClassBreaksField = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboUniqueField = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSimpleColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnClassBreaks = new System.Windows.Forms.RadioButton();
            this.rbtnUniqueValue = new System.Windows.Forms.RadioButton();
            this.rbtnSimple = new System.Windows.Forms.RadioButton();
            this.cldPolygonRenderer = new System.Windows.Forms.ColorDialog();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksNum)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPolygonRendererCancel
            // 
            this.btnPolygonRendererCancel.Location = new System.Drawing.Point(312, 514);
            this.btnPolygonRendererCancel.Name = "btnPolygonRendererCancel";
            this.btnPolygonRendererCancel.Size = new System.Drawing.Size(75, 23);
            this.btnPolygonRendererCancel.TabIndex = 33;
            this.btnPolygonRendererCancel.Text = "取消";
            this.btnPolygonRendererCancel.UseVisualStyleBackColor = true;
            this.btnPolygonRendererCancel.Click += new System.EventHandler(this.btnPolygonRendererCancel_Click);
            // 
            // btnPolygonRendererConfirm
            // 
            this.btnPolygonRendererConfirm.Location = new System.Drawing.Point(211, 514);
            this.btnPolygonRendererConfirm.Name = "btnPolygonRendererConfirm";
            this.btnPolygonRendererConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnPolygonRendererConfirm.TabIndex = 32;
            this.btnPolygonRendererConfirm.Text = "确定";
            this.btnPolygonRendererConfirm.UseVisualStyleBackColor = true;
            this.btnPolygonRendererConfirm.Click += new System.EventHandler(this.btnPolygonRendererConfirm_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnClassBreaksEndColor);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnClassBreaksStartColor);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.nudClassBreaksNum);
            this.groupBox4.Controls.Add(this.cboClassBreaksField);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(36, 357);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(350, 119);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "分级渲染";
            // 
            // btnClassBreaksEndColor
            // 
            this.btnClassBreaksEndColor.BackColor = System.Drawing.Color.Red;
            this.btnClassBreaksEndColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClassBreaksEndColor.Location = new System.Drawing.Point(257, 75);
            this.btnClassBreaksEndColor.Name = "btnClassBreaksEndColor";
            this.btnClassBreaksEndColor.Size = new System.Drawing.Size(75, 24);
            this.btnClassBreaksEndColor.TabIndex = 11;
            this.btnClassBreaksEndColor.UseVisualStyleBackColor = false;
            this.btnClassBreaksEndColor.Click += new System.EventHandler(this.btnClassBreaksEndColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(172, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "终止颜色:";
            // 
            // btnClassBreaksStartColor
            // 
            this.btnClassBreaksStartColor.BackColor = System.Drawing.Color.MistyRose;
            this.btnClassBreaksStartColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClassBreaksStartColor.Location = new System.Drawing.Point(91, 73);
            this.btnClassBreaksStartColor.Name = "btnClassBreaksStartColor";
            this.btnClassBreaksStartColor.Size = new System.Drawing.Size(75, 24);
            this.btnClassBreaksStartColor.TabIndex = 8;
            this.btnClassBreaksStartColor.UseVisualStyleBackColor = false;
            this.btnClassBreaksStartColor.Click += new System.EventHandler(this.btnClassBreaksStartColor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(6, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "起始颜色:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "字段:";
            // 
            // nudClassBreaksNum
            // 
            this.nudClassBreaksNum.Font = new System.Drawing.Font("宋体", 12F);
            this.nudClassBreaksNum.Location = new System.Drawing.Point(240, 27);
            this.nudClassBreaksNum.Name = "nudClassBreaksNum";
            this.nudClassBreaksNum.Size = new System.Drawing.Size(85, 26);
            this.nudClassBreaksNum.TabIndex = 6;
            this.nudClassBreaksNum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudClassBreaksNum.ValueChanged += new System.EventHandler(this.nudClassBreaksNum_ValueChanged);
            // 
            // cboClassBreaksField
            // 
            this.cboClassBreaksField.FormattingEnabled = true;
            this.cboClassBreaksField.Location = new System.Drawing.Point(60, 30);
            this.cboClassBreaksField.Name = "cboClassBreaksField";
            this.cboClassBreaksField.Size = new System.Drawing.Size(73, 20);
            this.cboClassBreaksField.TabIndex = 8;
            this.cboClassBreaksField.SelectedIndexChanged += new System.EventHandler(this.cboClassBreaksField_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(172, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "分级数:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cboUniqueField);
            this.groupBox3.Location = new System.Drawing.Point(36, 254);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 67);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "唯一值渲染";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(6, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "字段:";
            // 
            // cboUniqueField
            // 
            this.cboUniqueField.FormattingEnabled = true;
            this.cboUniqueField.Location = new System.Drawing.Point(60, 30);
            this.cboUniqueField.Name = "cboUniqueField";
            this.cboUniqueField.Size = new System.Drawing.Size(73, 20);
            this.cboUniqueField.TabIndex = 8;
            this.cboUniqueField.SelectedIndexChanged += new System.EventHandler(this.cboUniqueField_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSimpleColor);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(36, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 69);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "单一符号渲染";
            // 
            // btnSimpleColor
            // 
            this.btnSimpleColor.BackColor = System.Drawing.Color.Red;
            this.btnSimpleColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSimpleColor.Location = new System.Drawing.Point(58, 29);
            this.btnSimpleColor.Name = "btnSimpleColor";
            this.btnSimpleColor.Size = new System.Drawing.Size(75, 24);
            this.btnSimpleColor.TabIndex = 5;
            this.btnSimpleColor.UseVisualStyleBackColor = false;
            this.btnSimpleColor.Click += new System.EventHandler(this.btnSimpleColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "颜色:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnClassBreaks);
            this.groupBox1.Controls.Add(this.rbtnUniqueValue);
            this.groupBox1.Controls.Add(this.rbtnSimple);
            this.groupBox1.Location = new System.Drawing.Point(36, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 56);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // rbtnClassBreaks
            // 
            this.rbtnClassBreaks.AutoSize = true;
            this.rbtnClassBreaks.Location = new System.Drawing.Point(253, 21);
            this.rbtnClassBreaks.Name = "rbtnClassBreaks";
            this.rbtnClassBreaks.Size = new System.Drawing.Size(71, 16);
            this.rbtnClassBreaks.TabIndex = 2;
            this.rbtnClassBreaks.Text = "分级渲染";
            this.rbtnClassBreaks.UseVisualStyleBackColor = true;
            // 
            // rbtnUniqueValue
            // 
            this.rbtnUniqueValue.AutoSize = true;
            this.rbtnUniqueValue.Location = new System.Drawing.Point(138, 20);
            this.rbtnUniqueValue.Name = "rbtnUniqueValue";
            this.rbtnUniqueValue.Size = new System.Drawing.Size(83, 16);
            this.rbtnUniqueValue.TabIndex = 1;
            this.rbtnUniqueValue.Text = "唯一值渲染";
            this.rbtnUniqueValue.UseVisualStyleBackColor = true;
            // 
            // rbtnSimple
            // 
            this.rbtnSimple.AutoSize = true;
            this.rbtnSimple.Checked = true;
            this.rbtnSimple.Location = new System.Drawing.Point(24, 20);
            this.rbtnSimple.Name = "rbtnSimple";
            this.rbtnSimple.Size = new System.Drawing.Size(95, 16);
            this.rbtnSimple.TabIndex = 0;
            this.rbtnSimple.TabStop = true;
            this.rbtnSimple.Text = "单一符号渲染";
            this.rbtnSimple.UseVisualStyleBackColor = true;
            // 
            // PolygonRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 562);
            this.Controls.Add(this.btnPolygonRendererCancel);
            this.Controls.Add(this.btnPolygonRendererConfirm);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PolygonRenderer";
            this.Text = "图层渲染";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksNum)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPolygonRendererCancel;
        private System.Windows.Forms.Button btnPolygonRendererConfirm;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnClassBreaksEndColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClassBreaksStartColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudClassBreaksNum;
        private System.Windows.Forms.ComboBox cboClassBreaksField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboUniqueField;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSimpleColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnClassBreaks;
        private System.Windows.Forms.RadioButton rbtnUniqueValue;
        private System.Windows.Forms.RadioButton rbtnSimple;
        private System.Windows.Forms.ColorDialog cldPolygonRenderer;
    }
}