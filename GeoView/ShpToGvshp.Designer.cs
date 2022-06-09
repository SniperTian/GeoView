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
            this.textSavePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            // textSavePath
            // 
            this.textSavePath.Location = new System.Drawing.Point(175, 167);
            this.textSavePath.Name = "textSavePath";
            this.textSavePath.Size = new System.Drawing.Size(234, 21);
            this.textSavePath.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(95, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "存储路径：";
            // 
            // ShpToGvshp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 304);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.textSavePath);
            this.Controls.Add(this.label2);
            this.Name = "ShpToGvshp";
            this.Text = "ShpToGvshp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.TextBox textSavePath;
        private System.Windows.Forms.Label label2;
    }
}