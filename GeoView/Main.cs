using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyMapObjectsDemo
{
    public partial class Main : Form
    {
        #region 字段

        //(1)选项变量
        private Color mZoomBoxColor = Color.DeepPink;   //缩放盒颜色
        private double mZoomBoxWidth = 0.53;    //缩放盒边界宽度，单位毫米
        private Color mSelectBoxColor = Color.DarkGreen;    //选择盒颜色
        private double mSelectBoxWidth = 0.53;  //选择盒边界宽度
        private double mZoomRatioFixed = 2; //固定放大系数
        private double mZoomRatioMouseWheel = 1.2;  //滚轮放大系数
        private double mSelectingTolerance = 3; //选择容限，单位为像素
        private MyMapObjects.moSimpleFillSymbol mSelectBoxSymbol;    //选择盒符号
        private MyMapObjects.moSimpleFillSymbol mZoomBoxSymbol;    //缩放盒符号
        private MyMapObjects.moSimpleFillSymbol mMovingPolygonSymbol;   //正在移动的多边形符号
        private MyMapObjects.moSimpleFillSymbol mEditingPolygonSymbol;  //正在编辑的多边形符号
        private MyMapObjects.moSimpleMarkerSymbol mEditingVertexSymbol; //正在编辑的图形顶点的符号
        private MyMapObjects.moSimpleLineSymbol mElasticSymbol; //橡皮筋符号
        private bool mShowLngLat = false;   //是否显示经纬度

        //(2)与地图操作有关的变量
        private Int32 mMapOpStyle = 0;  //0：无，1：放大，2：缩小，3：漫游，4：选择；5：查询；6：移动；7：描绘；8：编辑
        private PointF mStartMouseLocation;
        private bool mIsInZoomIn = false;
        private bool mIsInPan = false;
        private bool mIsInSelect = false;
        private bool mIsInIdentify = false;
        private bool mIsInMovingShapes = false;
        //正在移动的图形的集合
        private List<MyMapObjects.moGeometry> mMovingGeometries = new List<MyMapObjects.moGeometry>();
        private MyMapObjects.moGeometry mEditingGeometry;   //正在编辑的图形
        private List<MyMapObjects.moPoints> mSketchingShape;    //正在描绘的图形，用一个多点集合存储；

        #endregion
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //(1)初始化符号
            InitializeSymbols();
            //(2)初始化描绘图形
            InitializeSketchingShape();
            //(3)显示比例尺
            ShowMapScale();
        }

        private void 编辑ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 停止编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 保存编辑内容ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moMap_Click(object sender, EventArgs e)
        {

        }

        private void moMap_DoubleClick(object sender, EventArgs e)
        {

        }

        private void moMap_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void moMap_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void moMap_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void 打开地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog sDialog = new OpenFileDialog();
            string sFileName = "";
            if (sDialog.ShowDialog(this) == DialogResult.OK)
            {
                sFileName = sDialog.FileName;
                sDialog.Dispose();
            }
            else
            {
                sDialog.Dispose();
                return;
            }

            try
            {
                FileStream sStream = new FileStream(sFileName, FileMode.Open);
                BinaryReader sr = new BinaryReader(sStream);
                MyMapObjects.moMapLayer sLayer = DataIOTools.LoadMapLayer(sr);
                moMap.Layers.Add(sLayer);
                if (moMap.Layers.Count == 1)
                {
                    moMap.FullExtent();
                }
                else
                {
                    moMap.RedrawMap();
                }
                sr.Dispose();
                sStream.Dispose();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                return;
            }
        }

        #region 私有函数

        // 初始化符号
        private void InitializeSymbols()
        {
            mSelectBoxSymbol = new MyMapObjects.moSimpleFillSymbol();
            mSelectBoxSymbol.Color = Color.Transparent;
            mSelectBoxSymbol.Outline.Color = mSelectBoxColor;
            mSelectBoxSymbol.Outline.Size = mSelectBoxWidth;
            mZoomBoxSymbol = new MyMapObjects.moSimpleFillSymbol();
            mZoomBoxSymbol.Color = Color.Transparent;
            mZoomBoxSymbol.Outline.Color = mZoomBoxColor;
            mZoomBoxSymbol.Outline.Size = mZoomBoxWidth;
            mMovingPolygonSymbol = new MyMapObjects.moSimpleFillSymbol();
            mMovingPolygonSymbol.Color = Color.Transparent;
            mMovingPolygonSymbol.Outline.Color = Color.Black;
            mEditingPolygonSymbol = new MyMapObjects.moSimpleFillSymbol();
            mEditingPolygonSymbol.Color = Color.Transparent;
            mEditingPolygonSymbol.Outline.Color = Color.DarkGreen;
            mEditingPolygonSymbol.Outline.Size = 0.53;
            mEditingVertexSymbol = new MyMapObjects.moSimpleMarkerSymbol();
            mEditingVertexSymbol.Color = Color.DarkGreen;
            mEditingVertexSymbol.Style = MyMapObjects.moSimpleMarkerSymbolStyleConstant.SolidSquare;
            mEditingVertexSymbol.Size = 2;
            mElasticSymbol = new MyMapObjects.moSimpleLineSymbol();
            mElasticSymbol.Color = Color.DarkGreen;
            mElasticSymbol.Size = 0.52;
            mElasticSymbol.Style = MyMapObjects.moSimpleLineSymbolStyleConstant.Dash;
        }

        // 初始化描绘图形
        private void InitializeSketchingShape()
        {
            mSketchingShape = new List<MyMapObjects.moPoints>();
            MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
            mSketchingShape.Add(sPoints);
        }

        // 根据屏幕坐标显示地图坐标
        private void ShowCoordinate(PointF point)
        {
            MyMapObjects.moPoint sPoint = moMap.ToMapPoint(point.X, point.Y);
            if (mShowLngLat == false)
            {
                double sX = Math.Round(sPoint.X);
                double sY = Math.Round(sPoint.Y);
                tssCoordinate.Text = "X:" + sX.ToString() + ",Y:" + sY.ToString();
            }
            else
            {
                MyMapObjects.moPoint sLngLat = moMap.ProjectionCS.TransferToLngLat(sPoint);
                double sX = Math.Round(sLngLat.X, 4);
                double sY = Math.Round(sLngLat.Y, 4);
                tssCoordinate.Text = "X:" + sX.ToString() + ",Y:" + sY.ToString();
            }
        }

        //显示当前比例尺
        private void ShowMapScale()
        {
            tssMapScale.Text = "1:" + moMap.MapScale.ToString("0.00");
        }

        #endregion
    }
}
