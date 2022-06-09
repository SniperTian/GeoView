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

        public Identify(MyMapObjects.moMapLayer layer, MyMapObjects.moFeatures features)
        {

            InitializeComponent();
            cboExtent.Items.Add("<选择的图层>");
            cboExtent.SelectedIndex = 0;
            treeView.Nodes.Add(layer.Name);
            mSelectedNode = treeView.Nodes[0];
            for (Int32 i = 0; i < features.Count; i++)
            {
                MyMapObjects.moFeature sFeature = features.GetItem(i);
                MyMapObjects.moAttributes sAttributes = sFeature.Attributes;
                mSelectedNode.Nodes.Add(Convert.ToString(sAttributes.GetItem(0)));
            }
            mSelectedNode = treeView.Nodes[0].Nodes[0];
            treeView.Nodes[0].Expand();
            Int32 sFieldCount = layer.AttributeFields.Count;
            dataTable_select = new DataTable();
            table.DataSource = null;
            table.DataSource = dataTable_select;
            dataTable_select.Columns.Add("字段", typeof(string));
            dataTable_select.Columns.Add("值", typeof(string));

            for (Int32 i = 0; i < sFieldCount; i++)
            {
                dataTable_select.Rows.Add(layer.AttributeFields.GetItem(i).Name, Convert.ToString(features.GetItem(0).Attributes.GetItem(i)));
            }
        }
    }
}