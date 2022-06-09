using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoView
{
    public partial class Identify : Form
    {
        private TreeNode mSelectedNode = new TreeNode();
        private DataTable dataTable_select;//选中数据的数据表
        private MyMapObjects.moMapLayer mLayer;
        private MyMapObjects.moFeatures mFeatures;
        
        public Identify(MyMapObjects.moMapLayer layer, MyMapObjects.moFeatures features)
        {

            InitializeComponent();
            mLayer = layer;
            mFeatures = features;
            cboExtent.Items.Add("<选择的图层>");
            cboExtent.SelectedIndex = 0;
            treeView.Nodes.Add(mLayer.Name);
            mSelectedNode = treeView.Nodes[0];
            for (Int32 i = 0; i < mFeatures.Count; i++)
            {
                MyMapObjects.moFeature sFeature = mFeatures.GetItem(i);
                MyMapObjects.moAttributes sAttributes = sFeature.Attributes;
                mSelectedNode.Nodes.Add(Convert.ToString(sAttributes.GetItem(0)));
            }
            mSelectedNode = treeView.Nodes[0].Nodes[0];
            treeView.Nodes[0].Expand();
            ShowTable(0);
        }
        private void ShowTable(Int32 nodeIndex)
        {
            Int32 sFieldCount = mLayer.AttributeFields.Count;
            dataTable_select = new DataTable();
            table.DataSource = null;
            table.DataSource = dataTable_select;
            dataTable_select.Columns.Add("字段", typeof(string));
            dataTable_select.Columns.Add("值", typeof(string));

            for (Int32 i = 0; i < sFieldCount; i++)
            {
                dataTable_select.Rows.Add(mLayer.AttributeFields.GetItem(i).Name, Convert.ToString(mFeatures.GetItem(nodeIndex).Attributes.GetItem(i)));
            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Int32 index = e.Node.Index;
            ShowTable(index);

        }
    }
}