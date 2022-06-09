namespace GeoView
{
    partial class Identify
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
            this.cboExtent = new System.Windows.Forms.ComboBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.table = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "识别范围：";
            // 
            // cboExtent
            // 
            this.cboExtent.FormattingEnabled = true;
            this.cboExtent.Location = new System.Drawing.Point(103, 25);
            this.cboExtent.Name = "cboExtent";
            this.cboExtent.Size = new System.Drawing.Size(217, 20);
            this.cboExtent.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(27, 59);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(293, 118);
            this.treeView.TabIndex = 2;
            // 
            // table
            // 
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(27, 196);
            this.table.Name = "table";
            this.table.RowTemplate.Height = 23;
            this.table.Size = new System.Drawing.Size(293, 235);
            this.table.TabIndex = 3;
            // 
            // Identify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 461);
            this.Controls.Add(this.table);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.cboExtent);
            this.Controls.Add(this.label1);
            this.Name = "Identify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "识别";
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboExtent;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.DataGridView table;
    }
}