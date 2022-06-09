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
    public partial class CreateLayer : Form
    {
        #region 字段

        private string mLayerName = String.Empty;
        private MyMapObjects.moGeometryTypeConstant mLayerType = MyMapObjects.moGeometryTypeConstant.Point;
        private string mSavePath = String.Empty;

        #endregion

        #region 构造函数
        public CreateLayer()
        {
            InitializeComponent();
            cboLayerType.Items.Add("Point");
            cboLayerType.Items.Add("MultiPoint");
            cboLayerType.Items.Add("MultiPolyline");
            cboLayerType.Items.Add("MultiPolygon");
            cboLayerType.SelectedIndex = 0;
        }
        #endregion

        #region 窗体

        //选择路径
        private void btnSavePath_Click(object sender, EventArgs e)
        {
            sfd.Filter = @"自定义图层(*gvshp)|*.gvshp";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                mSavePath = sfd.FileName;
                textSavePath.Text = mSavePath;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            mLayerName = textLayerName.Text;
            mSavePath = textSavePath.Text;
            if(cboLayerType.SelectedIndex == 0)
            {
                mLayerType = MyMapObjects.moGeometryTypeConstant.Point;
            }
            else if(cboLayerType.SelectedIndex == 1)
            {
                mLayerType = MyMapObjects.moGeometryTypeConstant.MultiPoint;
            }
            else if (cboLayerType.SelectedIndex == 2)
            {
                mLayerType = MyMapObjects.moGeometryTypeConstant.MultiPolyline;
            }
            else if (cboLayerType.SelectedIndex == 3)
            {
                mLayerType = MyMapObjects.moGeometryTypeConstant.MultiPolygon;
            }
            if (mLayerName == String.Empty)
            {
                MessageBox.Show("还没给图层取个名字呢!");
            }
            else if(mSavePath == String.Empty)
            {
                MessageBox.Show("还没给图层选个保存路径呢!");
            }
            else
            {
                Main main = (Main)this.Owner;
                main.GetCreateLayerInfo(mLayerName, mLayerType, mSavePath);
                if (cboLayerType.Enabled == false) main.PasteToNew();
                this.Close();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 私有函数

        public void FixedType(MyMapObjects.moGeometryTypeConstant shapeType)
        {
            if (shapeType == MyMapObjects.moGeometryTypeConstant.Point) cboLayerType.SelectedIndex = 0;
            if (shapeType == MyMapObjects.moGeometryTypeConstant.MultiPoint) cboLayerType.SelectedIndex = 1;
            if (shapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline) cboLayerType.SelectedIndex = 2;
            if (shapeType == MyMapObjects.moGeometryTypeConstant.MultiPolygon) cboLayerType.SelectedIndex = 3;
            cboLayerType.Enabled = false;
        }

        #endregion
    }
}
