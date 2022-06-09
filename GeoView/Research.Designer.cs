namespace GeoView
{
    partial class Research
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
            this.Layer_SelectBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Fields_List = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.UniqueValues = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SQL_text = new System.Windows.Forms.TextBox();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button23 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Layer_SelectBox
            // 
            this.Layer_SelectBox.DropDownHeight = 120;
            this.Layer_SelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Layer_SelectBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Layer_SelectBox.FormattingEnabled = true;
            this.Layer_SelectBox.IntegralHeight = false;
            this.Layer_SelectBox.Location = new System.Drawing.Point(90, 21);
            this.Layer_SelectBox.Name = "Layer_SelectBox";
            this.Layer_SelectBox.Size = new System.Drawing.Size(222, 22);
            this.Layer_SelectBox.TabIndex = 0;
            this.Layer_SelectBox.SelectionChangeCommitted += new System.EventHandler(this.Layer_SelectBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "图层:";
            // 
            // Fields_List
            // 
            this.Fields_List.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Fields_List.FormattingEnabled = true;
            this.Fields_List.ItemHeight = 14;
            this.Fields_List.Location = new System.Drawing.Point(43, 68);
            this.Fields_List.Name = "Fields_List";
            this.Fields_List.Size = new System.Drawing.Size(269, 144);
            this.Fields_List.TabIndex = 2;
            this.Fields_List.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Fields_List_MouseClick);
            this.Fields_List.SelectedIndexChanged += new System.EventHandler(this.Fields_List_SelectedIndexChanged);
            this.Fields_List.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Fields_List_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "=";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(43, 264);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(43, 296);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 30);
            this.button3.TabIndex = 5;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(84, 232);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 30);
            this.button4.TabIndex = 6;
            this.button4.Text = "<>";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(125, 232);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 30);
            this.button5.TabIndex = 7;
            this.button5.Text = "Like";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(84, 264);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 30);
            this.button6.TabIndex = 8;
            this.button6.Text = ">=";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(84, 296);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(40, 30);
            this.button7.TabIndex = 9;
            this.button7.Text = "<=";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(125, 264);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(40, 30);
            this.button8.TabIndex = 10;
            this.button8.Text = "And";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(125, 296);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(40, 30);
            this.button9.TabIndex = 11;
            this.button9.Text = "Or";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(125, 328);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(40, 30);
            this.button10.TabIndex = 13;
            this.button10.Text = "Not";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(84, 328);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(19, 30);
            this.button11.TabIndex = 12;
            this.button11.Text = "(";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(43, 328);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(18, 30);
            this.button12.TabIndex = 14;
            this.button12.Text = "_";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(65, 328);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(18, 30);
            this.button13.TabIndex = 15;
            this.button13.Text = "%";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(125, 360);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(40, 30);
            this.button14.TabIndex = 18;
            this.button14.Text = "Null";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(84, 360);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(40, 30);
            this.button15.TabIndex = 17;
            this.button15.Text = "In";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(43, 360);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(40, 30);
            this.button16.TabIndex = 16;
            this.button16.Text = "Is";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(181, 360);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(131, 30);
            this.button17.TabIndex = 19;
            this.button17.Text = "获取唯一值";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // UniqueValues
            // 
            this.UniqueValues.FormattingEnabled = true;
            this.UniqueValues.ItemHeight = 12;
            this.UniqueValues.Location = new System.Drawing.Point(181, 232);
            this.UniqueValues.Name = "UniqueValues";
            this.UniqueValues.Size = new System.Drawing.Size(131, 124);
            this.UniqueValues.TabIndex = 20;
            this.UniqueValues.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UniqueValues_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "Select * From Where";
            // 
            // SQL_text
            // 
            this.SQL_text.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SQL_text.Location = new System.Drawing.Point(43, 428);
            this.SQL_text.Multiline = true;
            this.SQL_text.Name = "SQL_text";
            this.SQL_text.Size = new System.Drawing.Size(269, 77);
            this.SQL_text.TabIndex = 22;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(256, 511);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(60, 30);
            this.button18.TabIndex = 24;
            this.button18.Text = "关闭";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(184, 511);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(60, 30);
            this.button19.TabIndex = 23;
            this.button19.Text = "应用";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(112, 511);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(60, 30);
            this.button20.TabIndex = 26;
            this.button20.Text = "确定";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(38, 511);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(60, 30);
            this.button21.TabIndex = 25;
            this.button21.Text = "验证";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(104, 328);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(20, 30);
            this.button22.TabIndex = 27;
            this.button22.Text = ")";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(147, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "字段列表";
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(256, 409);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(56, 19);
            this.button23.TabIndex = 29;
            this.button23.Text = "Clear";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // Research
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 561);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.SQL_text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UniqueValues);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Fields_List);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Layer_SelectBox);
            this.Name = "Research";
            this.Text = "按属性查询";
            this.Load += new System.EventHandler(this.Research_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Layer_SelectBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.ListBox UniqueValues;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SQL_text;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.ListBox Fields_List;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button23;
    }
}