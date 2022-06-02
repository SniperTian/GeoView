
namespace GeoView
{
    partial class EditShpWarningForm
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.NOBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox.Location = new System.Drawing.Point(90, 31);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(423, 61);
            this.textBox.TabIndex = 0;
            this.textBox.Text = "对shapefile文件进行编辑操作，会在同一目录下生成同名gvshp文件，操作会保存在该gvshp文件中！若已有同名gvshp文件，会进行覆盖，请知悉！是否继续" +
    "？";
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(90, 131);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "确认";
            this.OKBtn.UseVisualStyleBackColor = true;
            // 
            // NOBtn
            // 
            this.NOBtn.Location = new System.Drawing.Point(438, 131);
            this.NOBtn.Name = "NOBtn";
            this.NOBtn.Size = new System.Drawing.Size(75, 23);
            this.NOBtn.TabIndex = 2;
            this.NOBtn.Text = "取消";
            this.NOBtn.UseVisualStyleBackColor = true;
            // 
            // EditShpWarningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 197);
            this.Controls.Add(this.NOBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.textBox);
            this.Name = "EditShpWarningForm";
            this.Text = "EditShpWarningForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button NOBtn;
    }
}