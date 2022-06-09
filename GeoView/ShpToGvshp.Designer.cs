namespace GeoView
{
    partial class ShpToGvshp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShpToGvshp));
            this.btnSavePath = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnGvshpPath = new System.Windows.Forms.Button();
            this.textGvshpPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textShpPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.btnShpPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSavePath
            // 
            this.btnSavePath.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePath.Image")));
            this.btnSavePath.Location = new System.Drawing.Point(487, 201);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(25, 23);
            this.btnSavePath.TabIndex = 7;
            this.btnSavePath.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(297, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(148, 229);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 12;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnGvshpPath
            // 
            this.btnGvshpPath.Image = ((System.Drawing.Image)(resources.GetObject("btnGvshpPath.Image")));
            this.btnGvshpPath.Location = new System.Drawing.Point(389, 144);
            this.btnGvshpPath.Name = "btnGvshpPath";
            this.btnGvshpPath.Size = new System.Drawing.Size(25, 23);
            this.btnGvshpPath.TabIndex = 11;
            this.btnGvshpPath.UseVisualStyleBackColor = true;
            this.btnGvshpPath.Click += new System.EventHandler(this.btnGvshpPath_Click);
            // 
            // textGvshpPath
            // 
            this.textGvshpPath.Location = new System.Drawing.Point(148, 144);
            this.textGvshpPath.Name = "textGvshpPath";
            this.textGvshpPath.Size = new System.Drawing.Size(234, 21);
            this.textGvshpPath.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(28, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "gvshp存储路径：";
            // 
            // textShpPath
            // 
            this.textShpPath.Location = new System.Drawing.Point(148, 83);
            this.textShpPath.Name = "textShpPath";
            this.textShpPath.Size = new System.Drawing.Size(234, 21);
            this.textShpPath.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(44, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "shp文件路径：";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // btnShpPath
            // 
            this.btnShpPath.Image = ((System.Drawing.Image)(resources.GetObject("btnShpPath.Image")));
            this.btnShpPath.Location = new System.Drawing.Point(389, 83);
            this.btnShpPath.Name = "btnShpPath";
            this.btnShpPath.Size = new System.Drawing.Size(25, 23);
            this.btnShpPath.TabIndex = 16;
            this.btnShpPath.UseVisualStyleBackColor = true;
            this.btnShpPath.Click += new System.EventHandler(this.btnShpPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "*将输入的shp文件转换成gvshp文件输出";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ShpToGvshp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 304);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShpPath);
            this.Controls.Add(this.textShpPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnGvshpPath);
            this.Controls.Add(this.textGvshpPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSavePath);
            this.Name = "ShpToGvshp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShpToGvshp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnGvshpPath;
        private System.Windows.Forms.TextBox textGvshpPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textShpPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button btnShpPath;
        private System.Windows.Forms.Label label3;
    }
}