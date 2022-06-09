
namespace GeoView
{
    partial class LayerAttributes
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
            this.AttibutesText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // AttibutesText
            // 
            this.AttibutesText.Location = new System.Drawing.Point(39, 29);
            this.AttibutesText.Name = "AttibutesText";
            this.AttibutesText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.AttibutesText.Size = new System.Drawing.Size(481, 241);
            this.AttibutesText.TabIndex = 0;
            this.AttibutesText.Text = "";
            // 
            // LayerAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 314);
            this.Controls.Add(this.AttibutesText);
            this.Name = "LayerAttributes";
            this.Text = "图层属性";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox AttibutesText;
    }
}