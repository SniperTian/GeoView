namespace GeoView
{
    partial class PolylineRenderer
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
            this.btnPolylineRendererCancel = new System.Windows.Forms.Button();
            this.btnPolylineRendererConfirm = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nudClassBreaksMaxSize = new System.Windows.Forms.NumericUpDown();
            this.nudClassBreaksMinSize = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClassBreaksColor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudClassBreaksNum = new System.Windows.Forms.NumericUpDown();
            this.cboClassBreaksField = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudUniqueSize = new System.Windows.Forms.NumericUpDown();
            this.cboUniqueField = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudSimpleSize = new System.Windows.Forms.NumericUpDown();
            this.btnSimpleColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStyle = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnClassBreaks = new System.Windows.Forms.RadioButton();
            this.rbtnUniqueValue = new System.Windows.Forms.RadioButton();
            this.rbtnSimple = new System.Windows.Forms.RadioButton();
            this.cldPolylineRenderer = new System.Windows.Forms.ColorDialog();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksMinSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksNum)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUniqueSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimpleSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPolylineRendererCancel
            // 
            this.btnPolylineRendererCancel.Location = new System.Drawing.Point(312, 514);
            this.btnPolylineRendererCancel.Name = "btnPolylineRendererCancel";
            this.btnPolylineRendererCancel.Size = new System.Drawing.Size(75, 23);
            this.btnPolylineRendererCancel.TabIndex = 35;
            this.btnPolylineRendererCancel.Text = "取消";
            this.btnPolylineRendererCancel.UseVisualStyleBackColor = true;
            this.btnPolylineRendererCancel.Click += new System.EventHandler(this.btnPolylineRendererCancel_Click);
            // 
            // btnPolylineRendererConfirm
            // 
            this.btnPolylineRendererConfirm.Location = new System.Drawing.Point(211, 514);
            this.btnPolylineRendererConfirm.Name = "btnPolylineRendererConfirm";
            this.btnPolylineRendererConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnPolylineRendererConfirm.TabIndex = 34;
            this.btnPolylineRendererConfirm.Text = "确定";
            this.btnPolylineRendererConfirm.UseVisualStyleBackColor = true;
            this.btnPolylineRendererConfirm.Click += new System.EventHandler(this.btnPolylineRendererConfirm_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.nudClassBreaksMaxSize);
            this.groupBox4.Controls.Add(this.nudClassBreaksMinSize);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.btnClassBreaksColor);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.nudClassBreaksNum);
            this.groupBox4.Controls.Add(this.cboClassBreaksField);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(36, 357);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(350, 119);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "分级渲染";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(278, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "-";
            // 
            // nudClassBreaksMaxSize
            // 
            this.nudClassBreaksMaxSize.DecimalPlaces = 2;
            this.nudClassBreaksMaxSize.Font = new System.Drawing.Font("宋体", 12F);
            this.nudClassBreaksMaxSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudClassBreaksMaxSize.Location = new System.Drawing.Point(290, 70);
            this.nudClassBreaksMaxSize.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudClassBreaksMaxSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudClassBreaksMaxSize.Name = "nudClassBreaksMaxSize";
            this.nudClassBreaksMaxSize.Size = new System.Drawing.Size(60, 26);
            this.nudClassBreaksMaxSize.TabIndex = 10;
            this.nudClassBreaksMaxSize.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.nudClassBreaksMaxSize.ValueChanged += new System.EventHandler(this.nudClassBreaksMaxSize_ValueChanged);
            // 
            // nudClassBreaksMinSize
            // 
            this.nudClassBreaksMinSize.DecimalPlaces = 2;
            this.nudClassBreaksMinSize.Font = new System.Drawing.Font("宋体", 12F);
            this.nudClassBreaksMinSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudClassBreaksMinSize.Location = new System.Drawing.Point(216, 70);
            this.nudClassBreaksMinSize.Maximum = new decimal(new int[] {
            29,
            0,
            0,
            65536});
            this.nudClassBreaksMinSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudClassBreaksMinSize.Name = "nudClassBreaksMinSize";
            this.nudClassBreaksMinSize.Size = new System.Drawing.Size(60, 26);
            this.nudClassBreaksMinSize.TabIndex = 8;
            this.nudClassBreaksMinSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudClassBreaksMinSize.ValueChanged += new System.EventHandler(this.nudClassBreaksMinSize_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(173, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "宽度:";
            // 
            // btnClassBreaksColor
            // 
            this.btnClassBreaksColor.BackColor = System.Drawing.Color.Red;
            this.btnClassBreaksColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClassBreaksColor.Location = new System.Drawing.Point(58, 73);
            this.btnClassBreaksColor.Name = "btnClassBreaksColor";
            this.btnClassBreaksColor.Size = new System.Drawing.Size(75, 24);
            this.btnClassBreaksColor.TabIndex = 8;
            this.btnClassBreaksColor.UseVisualStyleBackColor = false;
            this.btnClassBreaksColor.Click += new System.EventHandler(this.btnClassBreaksColor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(6, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "颜色:";
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
            this.cboClassBreaksField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.groupBox3.Controls.Add(this.nudUniqueSize);
            this.groupBox3.Controls.Add(this.cboUniqueField);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(36, 254);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 67);
            this.groupBox3.TabIndex = 32;
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
            // nudUniqueSize
            // 
            this.nudUniqueSize.DecimalPlaces = 2;
            this.nudUniqueSize.Font = new System.Drawing.Font("宋体", 12F);
            this.nudUniqueSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudUniqueSize.Location = new System.Drawing.Point(239, 27);
            this.nudUniqueSize.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudUniqueSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudUniqueSize.Name = "nudUniqueSize";
            this.nudUniqueSize.Size = new System.Drawing.Size(85, 26);
            this.nudUniqueSize.TabIndex = 6;
            this.nudUniqueSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudUniqueSize.ValueChanged += new System.EventHandler(this.nudUniqueSize_ValueChanged);
            // 
            // cboUniqueField
            // 
            this.cboUniqueField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUniqueField.FormattingEnabled = true;
            this.cboUniqueField.Location = new System.Drawing.Point(60, 30);
            this.cboUniqueField.Name = "cboUniqueField";
            this.cboUniqueField.Size = new System.Drawing.Size(73, 20);
            this.cboUniqueField.TabIndex = 8;
            this.cboUniqueField.SelectedIndexChanged += new System.EventHandler(this.cboUniqueField_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(185, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "宽度:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudSimpleSize);
            this.groupBox2.Controls.Add(this.btnSimpleColor);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(36, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 69);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "单一符号渲染";
            // 
            // nudSimpleSize
            // 
            this.nudSimpleSize.DecimalPlaces = 2;
            this.nudSimpleSize.Font = new System.Drawing.Font("宋体", 12F);
            this.nudSimpleSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSimpleSize.Location = new System.Drawing.Point(239, 27);
            this.nudSimpleSize.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudSimpleSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSimpleSize.Name = "nudSimpleSize";
            this.nudSimpleSize.Size = new System.Drawing.Size(85, 26);
            this.nudSimpleSize.TabIndex = 6;
            this.nudSimpleSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudSimpleSize.ValueChanged += new System.EventHandler(this.nudSimpleSize_ValueChanged);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(185, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "宽度:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(40, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "样式:";
            // 
            // cboStyle
            // 
            this.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStyle.FormattingEnabled = true;
            this.cboStyle.Location = new System.Drawing.Point(94, 99);
            this.cboStyle.Name = "cboStyle";
            this.cboStyle.Size = new System.Drawing.Size(121, 20);
            this.cboStyle.TabIndex = 29;
            this.cboStyle.SelectedIndexChanged += new System.EventHandler(this.cboStyle_SelectedIndexChanged);
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
            this.rbtnClassBreaks.CheckedChanged += new System.EventHandler(this.rbtnClassBreaks_CheckedChanged);
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
            this.rbtnUniqueValue.CheckedChanged += new System.EventHandler(this.rbtnUniqueValue_CheckedChanged);
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
            this.rbtnSimple.CheckedChanged += new System.EventHandler(this.rbtnSimple_CheckedChanged);
            // 
            // PolylineRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 562);
            this.Controls.Add(this.btnPolylineRendererCancel);
            this.Controls.Add(this.btnPolylineRendererConfirm);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboStyle);
            this.Controls.Add(this.groupBox1);
            this.Name = "PolylineRenderer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图层渲染";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksMinSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClassBreaksNum)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUniqueSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimpleSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPolylineRendererCancel;
        private System.Windows.Forms.Button btnPolylineRendererConfirm;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudClassBreaksMaxSize;
        private System.Windows.Forms.NumericUpDown nudClassBreaksMinSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClassBreaksColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudClassBreaksNum;
        private System.Windows.Forms.ComboBox cboClassBreaksField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudUniqueSize;
        private System.Windows.Forms.ComboBox cboUniqueField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudSimpleSize;
        private System.Windows.Forms.Button btnSimpleColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStyle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnClassBreaks;
        private System.Windows.Forms.RadioButton rbtnUniqueValue;
        private System.Windows.Forms.RadioButton rbtnSimple;
        private System.Windows.Forms.ColorDialog cldPolylineRenderer;
    }
}