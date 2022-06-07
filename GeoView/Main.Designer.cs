namespace GeoView
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssMapScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssCoordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取矢量图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.恢复ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.滚动条ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.状态栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按属性选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放至所选要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平移至所选要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除所选要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geoView帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于GeoViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EditSpBtn = new System.Windows.Forms.ToolStripSplitButton();
            this.BeginEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EndEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveFeatureBtn = new System.Windows.Forms.ToolStripButton();
            this.EditPointBtn = new System.Windows.Forms.ToolStripButton();
            this.CreateFeatureBtn = new System.Windows.Forms.ToolStripButton();
            this.SelectLayer = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.layersTree = new System.Windows.Forms.TreeView();
            this.moMap = new MyMapObjects.moMapControl();
            this.moMapRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LayerRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.移除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.缩放至图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图层渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示注记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditPointStrip = new System.Windows.Forms.ToolStrip();
            this.EditPointStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.MovePointBtn = new System.Windows.Forms.ToolStripButton();
            this.AddPointBtn = new System.Windows.Forms.ToolStripButton();
            this.DeletePointBtn = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolsBar.SuspendLayout();
            this.LayerRightMenu.SuspendLayout();
            this.EditPointStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatus,
            this.tssMapScale,
            this.tssCoordinate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 643);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1034, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssStatus
            // 
            this.tssStatus.AutoSize = false;
            this.tssStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(180, 17);
            this.tssStatus.Text = "operating status";
            // 
            // tssMapScale
            // 
            this.tssMapScale.AutoSize = false;
            this.tssMapScale.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssMapScale.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssMapScale.Name = "tssMapScale";
            this.tssMapScale.Size = new System.Drawing.Size(180, 17);
            this.tssMapScale.Text = "map scale";
            // 
            // tssCoordinate
            // 
            this.tssCoordinate.AutoSize = false;
            this.tssCoordinate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssCoordinate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tssCoordinate.Name = "tssCoordinate";
            this.tssCoordinate.Size = new System.Drawing.Size(180, 17);
            this.tssCoordinate.Text = "coordinate";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.选择ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取矢量图层ToolStripMenuItem,
            this.打开地图ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.另存为ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 读取矢量图层ToolStripMenuItem
            // 
            this.读取矢量图层ToolStripMenuItem.Name = "读取矢量图层ToolStripMenuItem";
            this.读取矢量图层ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.读取矢量图层ToolStripMenuItem.Text = "新建";
            // 
            // 打开地图ToolStripMenuItem
            // 
            this.打开地图ToolStripMenuItem.Name = "打开地图ToolStripMenuItem";
            this.打开地图ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.打开地图ToolStripMenuItem.Text = "打开";
            this.打开地图ToolStripMenuItem.Click += new System.EventHandler(this.打开地图ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.撤销ToolStripMenuItem,
            this.恢复ToolStripMenuItem,
            this.剪切ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 撤销ToolStripMenuItem
            // 
            this.撤销ToolStripMenuItem.Name = "撤销ToolStripMenuItem";
            this.撤销ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.撤销ToolStripMenuItem.Text = "撤销";
            // 
            // 恢复ToolStripMenuItem
            // 
            this.恢复ToolStripMenuItem.Name = "恢复ToolStripMenuItem";
            this.恢复ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.恢复ToolStripMenuItem.Text = "恢复";
            // 
            // 剪切ToolStripMenuItem
            // 
            this.剪切ToolStripMenuItem.Name = "剪切ToolStripMenuItem";
            this.剪切ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.剪切ToolStripMenuItem.Text = "剪切";
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.滚动条ToolStripMenuItem,
            this.状态栏ToolStripMenuItem});
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 滚动条ToolStripMenuItem
            // 
            this.滚动条ToolStripMenuItem.Name = "滚动条ToolStripMenuItem";
            this.滚动条ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.滚动条ToolStripMenuItem.Text = "滚动条";
            // 
            // 状态栏ToolStripMenuItem
            // 
            this.状态栏ToolStripMenuItem.Name = "状态栏ToolStripMenuItem";
            this.状态栏ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.状态栏ToolStripMenuItem.Text = "状态栏";
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.按属性选择ToolStripMenuItem,
            this.缩放至所选要素ToolStripMenuItem,
            this.平移至所选要素ToolStripMenuItem,
            this.清除所选要素ToolStripMenuItem});
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.选择ToolStripMenuItem.Text = "选择";
            // 
            // 按属性选择ToolStripMenuItem
            // 
            this.按属性选择ToolStripMenuItem.Name = "按属性选择ToolStripMenuItem";
            this.按属性选择ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.按属性选择ToolStripMenuItem.Text = "按属性选择";
            // 
            // 缩放至所选要素ToolStripMenuItem
            // 
            this.缩放至所选要素ToolStripMenuItem.Name = "缩放至所选要素ToolStripMenuItem";
            this.缩放至所选要素ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.缩放至所选要素ToolStripMenuItem.Text = "缩放至所选要素";
            // 
            // 平移至所选要素ToolStripMenuItem
            // 
            this.平移至所选要素ToolStripMenuItem.Name = "平移至所选要素ToolStripMenuItem";
            this.平移至所选要素ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.平移至所选要素ToolStripMenuItem.Text = "平移至所选要素";
            // 
            // 清除所选要素ToolStripMenuItem
            // 
            this.清除所选要素ToolStripMenuItem.Name = "清除所选要素ToolStripMenuItem";
            this.清除所选要素ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.清除所选要素ToolStripMenuItem.Text = "清除所选要素";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geoView帮助ToolStripMenuItem,
            this.关于GeoViewToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // geoView帮助ToolStripMenuItem
            // 
            this.geoView帮助ToolStripMenuItem.Name = "geoView帮助ToolStripMenuItem";
            this.geoView帮助ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.geoView帮助ToolStripMenuItem.Text = "GeoView 帮助";
            // 
            // 关于GeoViewToolStripMenuItem
            // 
            this.关于GeoViewToolStripMenuItem.Name = "关于GeoViewToolStripMenuItem";
            this.关于GeoViewToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.关于GeoViewToolStripMenuItem.Text = "关于 GeoView";
            // 
            // toolsBar
            // 
            this.toolsBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.EditSpBtn,
            this.MoveFeatureBtn,
            this.EditPointBtn,
            this.CreateFeatureBtn,
            this.SelectLayer,
            this.toolStripSeparator4,
            this.toolStripButton3});
            this.toolsBar.Location = new System.Drawing.Point(0, 25);
            this.toolsBar.Name = "toolsBar";
            this.toolsBar.Size = new System.Drawing.Size(1034, 31);
            this.toolsBar.TabIndex = 3;
            this.toolsBar.Text = "工具栏";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "打开";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton2.Text = "保存";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton6.Text = "漫游";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton7.Text = "全范围显示";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton8.Text = "选择要素";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton4.Text = "放大";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton5.Text = "缩小";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // EditSpBtn
            // 
            this.EditSpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditSpBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BeginEditItem,
            this.EndEditItem,
            this.SaveEditItem});
            this.EditSpBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditSpBtn.Image")));
            this.EditSpBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditSpBtn.Name = "EditSpBtn";
            this.EditSpBtn.Size = new System.Drawing.Size(60, 28);
            this.EditSpBtn.Text = "编辑器";
            this.EditSpBtn.Click += new System.EventHandler(this.EditSpBtn_Click);
            // 
            // BeginEditItem
            // 
            this.BeginEditItem.Enabled = false;
            this.BeginEditItem.Name = "BeginEditItem";
            this.BeginEditItem.Size = new System.Drawing.Size(148, 22);
            this.BeginEditItem.Text = "开始编辑";
            this.BeginEditItem.Click += new System.EventHandler(this.BeginEditItem_Click);
            // 
            // EndEditItem
            // 
            this.EndEditItem.Enabled = false;
            this.EndEditItem.Name = "EndEditItem";
            this.EndEditItem.Size = new System.Drawing.Size(148, 22);
            this.EndEditItem.Text = "停止编辑";
            this.EndEditItem.Click += new System.EventHandler(this.EndEditItem_Click);
            // 
            // SaveEditItem
            // 
            this.SaveEditItem.Enabled = false;
            this.SaveEditItem.Name = "SaveEditItem";
            this.SaveEditItem.Size = new System.Drawing.Size(148, 22);
            this.SaveEditItem.Text = "保存编辑内容";
            this.SaveEditItem.Click += new System.EventHandler(this.SaveEditItem_Click);
            // 
            // MoveFeatureBtn
            // 
            this.MoveFeatureBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveFeatureBtn.Enabled = false;
            this.MoveFeatureBtn.Image = ((System.Drawing.Image)(resources.GetObject("MoveFeatureBtn.Image")));
            this.MoveFeatureBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveFeatureBtn.Name = "MoveFeatureBtn";
            this.MoveFeatureBtn.Size = new System.Drawing.Size(28, 28);
            this.MoveFeatureBtn.Text = "编辑工具";
            this.MoveFeatureBtn.Click += new System.EventHandler(this.MoveFeatureBtn_Click);
            // 
            // EditPointBtn
            // 
            this.EditPointBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditPointBtn.Enabled = false;
            this.EditPointBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditPointBtn.Image")));
            this.EditPointBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditPointBtn.Name = "EditPointBtn";
            this.EditPointBtn.Size = new System.Drawing.Size(28, 28);
            this.EditPointBtn.Text = "编辑折点";
            this.EditPointBtn.CheckedChanged += new System.EventHandler(this.EditPointBtn_CheckedChanged);
            this.EditPointBtn.Click += new System.EventHandler(this.EditPointBtn_Click);
            // 
            // CreateFeatureBtn
            // 
            this.CreateFeatureBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CreateFeatureBtn.Enabled = false;
            this.CreateFeatureBtn.Image = ((System.Drawing.Image)(resources.GetObject("CreateFeatureBtn.Image")));
            this.CreateFeatureBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateFeatureBtn.Name = "CreateFeatureBtn";
            this.CreateFeatureBtn.Size = new System.Drawing.Size(28, 28);
            this.CreateFeatureBtn.Text = "创建要素";
            this.CreateFeatureBtn.Click += new System.EventHandler(this.CreateFeatureBtn_Click);
            // 
            // SelectLayer
            // 
            this.SelectLayer.Enabled = false;
            this.SelectLayer.Name = "SelectLayer";
            this.SelectLayer.Size = new System.Drawing.Size(121, 31);
            this.SelectLayer.Text = "请选择图层";
            this.SelectLayer.SelectedIndexChanged += new System.EventHandler(this.SelectLayer_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // layersTree
            // 
            this.layersTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.layersTree.CheckBoxes = true;
            this.layersTree.Location = new System.Drawing.Point(0, 56);
            this.layersTree.Name = "layersTree";
            this.layersTree.Size = new System.Drawing.Size(290, 587);
            this.layersTree.TabIndex = 5;
            this.layersTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layersTree_MouseDown);
            // 
            // moMap
            // 
            this.moMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moMap.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.moMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.moMap.ContextMenuStrip = this.moMapRightMenu;
            this.moMap.FlashColor = System.Drawing.Color.Green;
            this.moMap.Location = new System.Drawing.Point(304, 56);
            this.moMap.Name = "moMap";
            this.moMap.SelectionColor = System.Drawing.Color.Cyan;
            this.moMap.Size = new System.Drawing.Size(738, 587);
            this.moMap.TabIndex = 0;
            this.moMap.MapScaleChanged += new MyMapObjects.moMapControl.MapScaleChangedHandle(this.moMap_MapScaleChanged);
            this.moMap.AfterTrackingLayerDraw += new MyMapObjects.moMapControl.AfterTrackingLayerDrawHandle(this.moMap_AfterTrackingLayerDraw);
            this.moMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseClick);
            this.moMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseDoubleClick);
            this.moMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseDown);
            this.moMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseMove);
            this.moMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moMap_MouseUp);
            // 
            // moMapRightMenu
            // 
            this.moMapRightMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.moMapRightMenu.Name = "moMapRightMenu";
            this.moMapRightMenu.Size = new System.Drawing.Size(181, 26);
            this.moMapRightMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.moMapRightMenu_ItemClicked);
            this.moMapRightMenu.VisibleChanged += new System.EventHandler(this.moMapRightMenu_VisibleChanged);
            // 
            // LayerRightMenu
            // 
            this.LayerRightMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.LayerRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.移除ToolStripMenuItem,
            this.打开属性表ToolStripMenuItem,
            this.缩放至图层ToolStripMenuItem,
            this.编辑要素ToolStripMenuItem,
            this.属性ToolStripMenuItem,
            this.图层渲染ToolStripMenuItem,
            this.显示注记ToolStripMenuItem});
            this.LayerRightMenu.Name = "LayerRightMenu";
            this.LayerRightMenu.Size = new System.Drawing.Size(137, 158);
            // 
            // 移除ToolStripMenuItem
            // 
            this.移除ToolStripMenuItem.Name = "移除ToolStripMenuItem";
            this.移除ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.移除ToolStripMenuItem.Text = "移除";
            this.移除ToolStripMenuItem.Click += new System.EventHandler(this.移除ToolStripMenuItem_Click);
            // 
            // 打开属性表ToolStripMenuItem
            // 
            this.打开属性表ToolStripMenuItem.Name = "打开属性表ToolStripMenuItem";
            this.打开属性表ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开属性表ToolStripMenuItem.Text = "打开属性表";
            this.打开属性表ToolStripMenuItem.Click += new System.EventHandler(this.打开属性表ToolStripMenuItem_Click);
            // 
            // 缩放至图层ToolStripMenuItem
            // 
            this.缩放至图层ToolStripMenuItem.Name = "缩放至图层ToolStripMenuItem";
            this.缩放至图层ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.缩放至图层ToolStripMenuItem.Text = "缩放至图层";
            this.缩放至图层ToolStripMenuItem.Click += new System.EventHandler(this.缩放至图层ToolStripMenuItem_Click);
            // 
            // 编辑要素ToolStripMenuItem
            // 
            this.编辑要素ToolStripMenuItem.Name = "编辑要素ToolStripMenuItem";
            this.编辑要素ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.编辑要素ToolStripMenuItem.Text = "编辑要素";
            this.编辑要素ToolStripMenuItem.Click += new System.EventHandler(this.编辑要素ToolStripMenuItem_Click);
            // 
            // 属性ToolStripMenuItem
            // 
            this.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem";
            this.属性ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.属性ToolStripMenuItem.Text = "属性";
            this.属性ToolStripMenuItem.Click += new System.EventHandler(this.属性ToolStripMenuItem_Click);
            // 
            // 图层渲染ToolStripMenuItem
            // 
            this.图层渲染ToolStripMenuItem.Name = "图层渲染ToolStripMenuItem";
            this.图层渲染ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.图层渲染ToolStripMenuItem.Text = "图层渲染";
            this.图层渲染ToolStripMenuItem.Click += new System.EventHandler(this.图层渲染ToolStripMenuItem_Click);
            // 
            // 显示注记ToolStripMenuItem
            // 
            this.显示注记ToolStripMenuItem.Name = "显示注记ToolStripMenuItem";
            this.显示注记ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.显示注记ToolStripMenuItem.Text = "显示注记";
            this.显示注记ToolStripMenuItem.Click += new System.EventHandler(this.显示注记ToolStripMenuItem_Click);
            // 
            // EditPointStrip
            // 
            this.EditPointStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.EditPointStrip.Enabled = false;
            this.EditPointStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.EditPointStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditPointStripLabel1,
            this.MovePointBtn,
            this.AddPointBtn,
            this.DeletePointBtn});
            this.EditPointStrip.Location = new System.Drawing.Point(533, 28);
            this.EditPointStrip.Name = "EditPointStrip";
            this.EditPointStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.EditPointStrip.Size = new System.Drawing.Size(71, 25);
            this.EditPointStrip.TabIndex = 6;
            this.EditPointStrip.Text = "toolStrip1";
            this.EditPointStrip.Visible = false;
            // 
            // EditPointStripLabel1
            // 
            this.EditPointStripLabel1.Name = "EditPointStripLabel1";
            this.EditPointStripLabel1.Size = new System.Drawing.Size(68, 22);
            this.EditPointStripLabel1.Text = "编辑折点：";
            // 
            // MovePointBtn
            // 
            this.MovePointBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MovePointBtn.Enabled = false;
            this.MovePointBtn.Image = ((System.Drawing.Image)(resources.GetObject("MovePointBtn.Image")));
            this.MovePointBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MovePointBtn.Name = "MovePointBtn";
            this.MovePointBtn.Size = new System.Drawing.Size(23, 22);
            this.MovePointBtn.Text = "修改草图折点";
            this.MovePointBtn.Visible = false;
            this.MovePointBtn.Click += new System.EventHandler(this.MovePointBtn_Click);
            // 
            // AddPointBtn
            // 
            this.AddPointBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddPointBtn.Enabled = false;
            this.AddPointBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddPointBtn.Image")));
            this.AddPointBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddPointBtn.Name = "AddPointBtn";
            this.AddPointBtn.Size = new System.Drawing.Size(23, 22);
            this.AddPointBtn.Text = "增加折点";
            this.AddPointBtn.Visible = false;
            this.AddPointBtn.Click += new System.EventHandler(this.AddPointBtn_Click);
            // 
            // DeletePointBtn
            // 
            this.DeletePointBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeletePointBtn.Enabled = false;
            this.DeletePointBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeletePointBtn.Image")));
            this.DeletePointBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeletePointBtn.Name = "DeletePointBtn";
            this.DeletePointBtn.Size = new System.Drawing.Size(23, 22);
            this.DeletePointBtn.Text = "删除折点";
            this.DeletePointBtn.Visible = false;
            this.DeletePointBtn.Click += new System.EventHandler(this.DeletePointBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 665);
            this.Controls.Add(this.EditPointStrip);
            this.Controls.Add(this.layersTree);
            this.Controls.Add(this.moMap);
            this.Controls.Add(this.toolsBar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "GeoView";
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolsBar.ResumeLayout(false);
            this.toolsBar.PerformLayout();
            this.LayerRightMenu.ResumeLayout(false);
            this.EditPointStrip.ResumeLayout(false);
            this.EditPointStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyMapObjects.moMapControl moMap;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tssMapScale;
        private System.Windows.Forms.ToolStripStatusLabel tssCoordinate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取矢量图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 恢复ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 滚动条ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 状态栏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按属性选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩放至所选要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平移至所选要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除所选要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geoView帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于GeoViewToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolsBar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TreeView layersTree;
        private System.Windows.Forms.ToolStripSplitButton EditSpBtn;
        private System.Windows.Forms.ToolStripMenuItem BeginEditItem;
        private System.Windows.Forms.ToolStripMenuItem EndEditItem;
        private System.Windows.Forms.ToolStripMenuItem SaveEditItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton MoveFeatureBtn;
        private System.Windows.Forms.ToolStripButton CreateFeatureBtn;
        private System.Windows.Forms.ToolStripComboBox SelectLayer;
        private System.Windows.Forms.ContextMenuStrip moMapRightMenu;
        private System.Windows.Forms.ContextMenuStrip LayerRightMenu;
        private System.Windows.Forms.ToolStripMenuItem 移除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开属性表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 缩放至图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图层渲染ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示注记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton EditPointBtn;
        private System.Windows.Forms.ToolStrip EditPointStrip;
        private System.Windows.Forms.ToolStripButton MovePointBtn;
        private System.Windows.Forms.ToolStripButton AddPointBtn;
        private System.Windows.Forms.ToolStripButton DeletePointBtn;
        private System.Windows.Forms.ToolStripLabel EditPointStripLabel1;
    }
}