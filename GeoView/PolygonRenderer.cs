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
    public partial class PolygonRenderer : Form
    {
        #region 字段

        private Int32 mRendererMode = 0; //渲染方式,0:简单渲染,1:唯一值渲染,2:分级渲染
        //简单渲染参数
        private Color mSimpleRendererColor = Color.Red; //符号颜色
        //唯一值渲染参数
        private Int32 mUniqueFieldIndex = 0; //绑定字段索引
        //分级渲染参数
        private Int32 mClassBreaksFieldIndex = 0; //绑定字段索引
        private Int32 mClassBreaksNum = 5; //分类数
        private Color mClassBreaksRendererStartColor = Color.MistyRose; //符号起始颜色,面图层采用符号颜色进行分级表示
        private Color mClassBreaksRendererEndColor = Color.Red; //符号起始颜色,面图层采用符号颜色进行分级表示

        #endregion

        #region 构造函数
        public PolygonRenderer(MyMapObjects.moMapLayer layer)
        {
            InitializeComponent();
            //填充字段下拉列表
            Int32 fieldCount = layer.AttributeFields.Count;
            for (Int32 i = 0; i < fieldCount; i++)
            {
                cboUniqueField.Items.Add(layer.AttributeFields.GetItem(i).Name);
                cboClassBreaksField.Items.Add(layer.AttributeFields.GetItem(i).Name);
            }
        }

        #endregion

        #region 窗体操作

        //选择渲染方式
        private void GetRendererMode()
        {
            if (rbtnSimple.Checked)
            {
                mRendererMode = 0;
            }
            else if (rbtnUniqueValue.Checked)
            {
                mRendererMode = 1;
            }
            else if (rbtnClassBreaks.Checked)
            {
                mRendererMode = 2;
            }
        }

        //选择简单渲染符号颜色
        private void btnSimpleColor_Click(object sender, EventArgs e)
        {
            DialogResult sColorDialogResult = cldPolygonRenderer.ShowDialog();
            if (sColorDialogResult == DialogResult.OK)
            {
                mSimpleRendererColor = cldPolygonRenderer.Color;
                btnSimpleColor.BackColor = mSimpleRendererColor;
            }
        }

        //选择唯一值渲染字段
        private void cboUniqueField_SelectedIndexChanged(object sender, EventArgs e)
        {
            mUniqueFieldIndex = cboUniqueField.SelectedIndex;
        }

        //选择分级渲染字段
        private void cboClassBreaksField_SelectedIndexChanged(object sender, EventArgs e)
        {
            mClassBreaksFieldIndex = cboClassBreaksField.SelectedIndex;
        }

        //选择分级渲染分级数
        private void nudClassBreaksNum_ValueChanged(object sender, EventArgs e)
        {
            mClassBreaksNum = (Int32)nudClassBreaksNum.Value;
        }

        //选择分级渲染符号起始颜色
        private void btnClassBreaksStartColor_Click(object sender, EventArgs e)
        {
            DialogResult sColorDialogResult = cldPolygonRenderer.ShowDialog();
            if (sColorDialogResult == DialogResult.OK)
            {
                mClassBreaksRendererStartColor = cldPolygonRenderer.Color;
                btnClassBreaksStartColor.BackColor = mClassBreaksRendererStartColor;
            }
        }

        //选择分级渲染符号终止颜色
        private void btnClassBreaksEndColor_Click(object sender, EventArgs e)
        {
            DialogResult sColorDialogResult = cldPolygonRenderer.ShowDialog();
            if (sColorDialogResult == DialogResult.OK)
            {
                mClassBreaksRendererEndColor = cldPolygonRenderer.Color;
                btnClassBreaksEndColor.BackColor = mClassBreaksRendererEndColor;
            }
        }

        //确认
        private void btnPolygonRendererConfirm_Click(object sender, EventArgs e)
        {
            Main main = (Main)this.Owner;
            GetRendererMode();
            main.GetPolygonRenderer(mRendererMode, mSimpleRendererColor,
                mUniqueFieldIndex, mClassBreaksFieldIndex, mClassBreaksNum,
                mClassBreaksRendererStartColor, mClassBreaksRendererEndColor);
            this.Close();
        }

        //取消
        private void btnPolygonRendererCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
