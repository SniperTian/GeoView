namespace GeoView
{
    partial class CreateLayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateLayer));
            this.label1 = new System.Windows.Forms.Label();
            this.textLayerName = new System.Windows.Forms.TextBox();
            this.textSavePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLayerType = new System.Windows.Forms.ComboBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(62, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层名称：";
            // 
            // textLayerName
            // 
            this.textLayerName.Location = new System.Drawing.Point(142, 43);
            this.textLayerName.Name = "textLayerName";
            this.textLayerName.Size = new System.Drawing.Size(234, 21);
            this.textLayerName.TabIndex = 1;
            // 
            // textSavePath
            // 
            this.textSavePath.Location = new System.Drawing.Point(142, 141);
            this.textSavePath.Name = "textSavePath";
            this.textSavePath.Size = new System.Drawing.Size(234, 21);
            this.textSavePath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(62, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "存储路径：";
            // 
            // btnSavePath
            // 
            this.btnSavePath.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePath.Image")));
            this.btnSavePath.Location = new System.Drawing.Point(383, 141);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(25, 23);
            this.btnSavePath.TabIndex = 4;
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(62, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "图层类型：";
            // 
            // cboLayerType
            // 
            this.cboLayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayerType.FormattingEnabled = true;
            this.cboLayerType.Location = new System.Drawing.Point(142, 90);
            this.cboLayerType.Name = "cboLayerType";
            this.cboLayerType.Size = new System.Drawing.Size(234, 20);
            this.cboLayerType.TabIndex = 6;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(142, 226);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(291, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CreateLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 304);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cboLayerType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.textSavePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textLayerName);
            this.Controls.Add(this.label1);
            this.Name = "CreateLayer";
            this.Text = "新建图层";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textLayerName;
        private System.Windows.Forms.TextBox textSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboLayerType;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}