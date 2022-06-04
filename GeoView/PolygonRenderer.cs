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
            cboUniqueField.SelectedIndex = 0;
            cboClassBreaksField.SelectedIndex = 0;

            if (layer.Renderer.RendererType == MyMapObjects.moRendererTypeConstant.Simple)
            {
                MyMapObjects.moSimpleRenderer sRenderer = (MyMapObjects.moSimpleRenderer)layer.Renderer;
                MyMapObjects.moSimpleFillSymbol sSymbol = (MyMapObjects.moSimpleFillSymbol)sRenderer.Symbol;
                btnSimpleColor.BackColor = sSymbol.Color;
                mSimpleRendererColor = sSymbol.Color;
                rbtnSimple.Checked = true;

            }
            else if (layer.Renderer.RendererType == MyMapObjects.moRendererTypeConstant.UniqueValue)
            {
                MyMapObjects.moUniqueValueRenderer sRenderer = (MyMapObjects.moUniqueValueRenderer)layer.Renderer;
                MyMapObjects.moSimpleFillSymbol sSymbol = (MyMapObjects.moSimpleFillSymbol)sRenderer.GetSymbol(0);
                cboUniqueField.SelectedIndex = layer.AttributeFields.FindField(sRenderer.Field);
                rbtnUniqueValue.Checked = true;

            }
            else if (layer.Renderer.RendererType == MyMapObjects.moRendererTypeConstant.ClassBreaks)
            {
                MyMapObjects.moClassBreaksRenderer sRenderer = (MyMapObjects.moClassBreaksRenderer)layer.Renderer;
                MyMapObjects.moSimpleFillSymbol sStartSymbol = (MyMapObjects.moSimpleFillSymbol)sRenderer.GetSymbol(0);
                MyMapObjects.moSimpleFillSymbol sEndSymbol = (MyMapObjects.moSimpleFillSymbol)sRenderer.GetSymbol(sRenderer.BreakCount - 1);
                cboClassBreaksField.SelectedIndex = layer.AttributeFields.FindField(sRenderer.Field);
                nudClassBreaksNum.Value = sRenderer.BreakCount;
                btnClassBreaksStartColor.BackColor = sStartSymbol.Color;
                mClassBreaksRendererStartColor = sStartSymbol.Color;
                btnClassBreaksEndColor.BackColor = sEndSymbol.Color;
                mClassBreaksRendererEndColor = sEndSymbol.Color;
                rbtnClassBreaks.Checked = true;
            }
            SetEnabled();
        }

        #endregion

        #region 窗体操作
        //设置选项是否可选
        private void SetEnabled()
        {
            if (rbtnSimple.Checked)
            {
                btnSimpleColor.Enabled = true;
                cboUniqueField.Enabled = false;
                cboClassBreaksField.Enabled = false;                
                nudClassBreaksNum.Enabled = false;
                btnClassBreaksStartColor.Enabled = false;
                btnClassBreaksEndColor.Enabled = false;
            }
            else if (rbtnUniqueValue.Checked)
            {
                btnSimpleColor.Enabled = false;
                cboUniqueField.Enabled = true;
                cboClassBreaksField.Enabled = false;
                nudClassBreaksNum.Enabled = false;
                btnClassBreaksStartColor.Enabled = false;
                btnClassBreaksEndColor.Enabled = false;
            }
            else if (rbtnClassBreaks.Checked)
            {
                btnSimpleColor.Enabled = false;
                cboUniqueField.Enabled = false;
                cboClassBreaksField.Enabled = true;
                nudClassBreaksNum.Enabled = true;
                btnClassBreaksStartColor.Enabled = true;
                btnClassBreaksEndColor.Enabled = true;

            }
        }

        private void rbtnSimple_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabled();
        }

        private void rbtnUniqueValue_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabled();
        }

        private void rbtnClassBreaks_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabled();
        }
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
