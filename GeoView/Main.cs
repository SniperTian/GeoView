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

namespace GeoView
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
        private Int32 mMapOpStyle = 0;  //0：无，1：编辑（可选择可移动）,2:在当前操作图层进行选择
        private Int32 mOperatingLayerIndex = -1;    //当前操作的图层索引
        private PointF mStartMouseLocation;
        private bool mIsInZoomIn = false;
        private bool mIsInPan = false;
        private bool mIsInSelect = false;
        private bool mIsInMove = false;
        private bool mIsInIdentify = false;
        private Int32 mLastOpLayerIndex = -1;   //最近一次操作的图层索引
        //正在移动的图形的集合
        private List<MyMapObjects.moGeometry> mMovingGeometries = new List<MyMapObjects.moGeometry>();
        private MyMapObjects.moGeometry mEditingGeometry;   //正在编辑的图形
        private List<MyMapObjects.moPoints> mSketchingShape;    //正在描绘的图形，用一个多点集合存储；

        //(3)与文件操作相关的变量
        private List<DataIOTools.gvShpFileManager> mGvShapeFiles = new List<DataIOTools.gvShpFileManager>();    //管理要素文件
        private List<DataIOTools.dbfFileManager> mDbfFiles = new List<DataIOTools.dbfFileManager>();    //管理属性文件

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

        private void EditSpBtn_Click(object sender, EventArgs e)
        {
            if (moMap.Layers.Count > 0)
            {
                BeginEditItem.Enabled = true;
            }
        }

        private void BeginEditItem_Click(object sender, EventArgs e)
        {
            EndEditItem.Enabled = true;
            SaveEditItem.Enabled = true;
            MoveFeatureBtn.Enabled = true;
            CreateFeatureBtn.Enabled = true;
            SelectLayer.Enabled = true;
            RefreshSelectLayer();
            MoveFeatureBtn_Click(sender, e);
        }

        private void EndEditItem_Click(object sender, EventArgs e)
        {
            MoveFeatureBtn.Enabled = false;
            CreateFeatureBtn.Enabled = false;
            MoveFeatureBtn.Checked = false;
            CreateFeatureBtn.Checked = false;
            SelectLayer.SelectedIndex = -1;
            SelectLayer.Enabled = false;
            EndEditItem.Enabled = false;
            SaveEditItem.Enabled = false;
        }

        private void SaveEditItem_Click(object sender, EventArgs e)
        {

        }

        private void MoveFeatureBtn_Click(object sender, EventArgs e)
        {
            MoveFeatureBtn.Checked = true;
            if (CreateFeatureBtn.Checked)
            {
                CreateFeatureBtn.Checked = false;
            }
            mMapOpStyle = 1;    //默认为编辑操作
        }

        private void CreateFeatureBtn_Click(object sender, EventArgs e)
        {
            CreateFeatureBtn.Checked = true;
            if (MoveFeatureBtn.Checked)
            {
                MoveFeatureBtn.Checked = false;
            }
        }

        private void SelectLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            mOperatingLayerIndex = SelectLayer.SelectedIndex;
        }

        private void moMap_Click(object sender, EventArgs e)
        {

        }

        private void moMap_DoubleClick(object sender, EventArgs e)
        {

        }

        private void moMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1)
            {
                OnEdit_MouseDown(e);
            }
            else if (mMapOpStyle == 2)
            {

            }
        }

        private void OnEdit_MouseDown(MouseEventArgs e)
        {
            //判断应该是进行选择还是移动
            mIsInMove = false;
            if (moMap.Layers.GetItem(mOperatingLayerIndex).ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
            {
                for(Int32 i = 0; i < moMap.Layers.GetItem(mOperatingLayerIndex).SelectedFeatures.Count; i++)
                {
                    MyMapObjects.moFeature sFeature = moMap.Layers.GetItem(mOperatingLayerIndex).SelectedFeatures.GetItem(i);
                    MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
                    MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)sFeature.Geometry;
                    if (MyMapObjects.moMapTools.IsPointWithinMultiPolygon(sPoint, sMultiPolygon))
                    {
                        mIsInMove = true;
                        break;
                    }
                }
            }
            if (mIsInMove)
            {

            }
            else
            {
                OnSelect_MouseDown(e);
            }
        }
        private void OnSelect_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInSelect = true;
            }
        }

        //private void OnMoveShape_MouseDown(MouseEventArgs e)
        //{
        //    if (e.Button != MouseButtons.Left)
        //        return;
        //    //查找多边形图层
        //    MyMapObjects.moMapLayer sLayer = GetPolygonLayer();
        //    if (sLayer == null)
        //        return;
        //    //判断是否有选中的要素
        //    Int32 sSelFeatureCount = sLayer.SelectedFeatures.Count;
        //    if (sSelFeatureCount == 0)
        //        return;
        //    //复制图层
        //    mMovingGeometries.Clear();
        //    for (Int32 i = 0; i < sSelFeatureCount; ++i)
        //    {
        //        MyMapObjects.moMultiPolygon sOriPolygon = (MyMapObjects.moMultiPolygon)sLayer.SelectedFeatures.GetItem(i).Geometry;
        //        MyMapObjects.moMultiPolygon sDesPolygon = sOriPolygon.Clone();
        //        mMovingGeometries.Add(sDesPolygon);
        //    }
        //    //设置变量
        //    mStartMouseLocation = e.Location;
        //    mIsInMovingShapes = true;
        //}

        private void moMap_MouseMove(object sender, MouseEventArgs e)
        {
            ShowCoordinate(e.Location);
            if (mMapOpStyle == 1) 
            {
                OnEdit_MouseMove(e);
            }
            else if (mMapOpStyle == 2)
            {
                
            }
        }

        private void OnEdit_MouseMove(MouseEventArgs e)
        {
            if (mIsInMove)
            {

            }
            else
            {
                OnSelect_MouseMove(e);
            }
        }
        private void OnSelect_MouseMove(MouseEventArgs e)
        {
            if (mIsInSelect == false)
            {
                return;
            }
            moMap.Refresh();
            MyMapObjects.moRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mSelectBoxSymbol);
        }

        private void moMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1) 
            {
                OnEdit_MouseUp(e);
            }
            else if (mMapOpStyle == 2)
            {
                
            }
        }

        private void OnEdit_MouseUp(MouseEventArgs e)
        {
            if (mIsInMove)
            {
                mIsInMove = false;
            }
            else
            {
                OnSelect_MouseUp(e);
            }
        }
        //只在当前编辑的图层中进行选择(与demo中有不同)
        private void OnSelect_MouseUp(MouseEventArgs e)
        {
            if (mIsInSelect == false)
            {
                return;
            }
            mIsInSelect = false;
            MyMapObjects.moRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            double sTolerance = moMap.ToMapDistance(mSelectingTolerance);
            moMap.SelectLayerByBox(sBox, sTolerance, mOperatingLayerIndex); //该方法只在当前图层中选择，与demo中不同
            moMap.RedrawTrackingShapes();
        }

        private void 打开地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog sDialog = new OpenFileDialog();
            sDialog.Filter = "图层文件|*.shp;*.gvshp";
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
                //检查是否存在同名图层
                string layerName = Path.GetFileNameWithoutExtension(sFileName);
                for(Int32 i = 0; i < moMap.Layers.Count; i++)
                {
                    if (layerName == moMap.Layers.GetItem(i).Name)
                    {
                        string errorMsg = "已存在同名图层！";
                        throw new Exception(errorMsg);
                    }
                }
                string extension = Path.GetExtension(sFileName);
                string dbfFilePath = "";
                DataIOTools.gvShpFileManager sGvShpFileManager;
                List<MyMapObjects.moGeometry> sGeometries;
                MyMapObjects.moGeometryTypeConstant sGeometryType;
                if (extension == ".shp")
                {
                    //读取shp文件
                    string shpFilePath = sFileName;
                    dbfFilePath = shpFilePath.Substring(0, shpFilePath.IndexOf(".shp")) + ".dbf";
                    //(1)读取shp文件，并以gvshp文件进行管理
                    DataIOTools.shpFileReader sShpFileReader = new DataIOTools.shpFileReader(shpFilePath);
                    sGeometryType = sShpFileReader.ShapeType;
                    sGeometries = sShpFileReader.Geometries;
                    sGvShpFileManager = new DataIOTools.gvShpFileManager(sGeometryType);
                    sGvShpFileManager.SourceFileType = "shp";   //设置文件源
                    sGvShpFileManager.UpdateGeometries(sGeometries);
                }
                else
                {
                    //读取gvshp文件
                    string gvshpFilePath = sFileName;
                    dbfFilePath = gvshpFilePath.Substring(0, gvshpFilePath.IndexOf(".gvshp")) + ".dbf";
                    //(1)读取gvshp文件
                    sGvShpFileManager = new DataIOTools.gvShpFileManager(gvshpFilePath);
                    sGvShpFileManager.SourceFileType = "gvshp";
                    sGvShpFileManager.DefaultFilePath = gvshpFilePath;
                    sGeometries = sGvShpFileManager.Geometries;
                    sGeometryType = sGvShpFileManager.GeometryType;
                }

                //(2)读取dbf文件
                DataIOTools.dbfFileManager sDbfFileManager = new DataIOTools.dbfFileManager(dbfFilePath);
                MyMapObjects.moFields sFields = sDbfFileManager.Fields;
                List<MyMapObjects.moAttributes> sAttributes = sDbfFileManager.AttributesList;
                //(3)判断要素数与属性数是否一致
                if (sGeometries.Count != sAttributes.Count)
                {
                    string errorMsg = "要素数与属性数不一致!";
                    throw new Exception(errorMsg);
                }
                
                //(4)添加至图层并加载
                MyMapObjects.moMapLayer sMapLayer = new MyMapObjects.moMapLayer(layerName, sGeometryType, sFields);
                //加载要素
                MyMapObjects.moFeatures sFeatures = new MyMapObjects.moFeatures();
                for (Int32 i = 0; i < sGeometries.Count; ++i)
                {
                    MyMapObjects.moFeature sFeature = new MyMapObjects.moFeature(sGeometryType, sGeometries[i], sAttributes[i]);
                    sFeatures.Add(sFeature);
                }
                sMapLayer.Features = sFeatures;

                //相关数据更新
                Int32 index = SearchInsertIndex(sMapLayer.ShapeType);
                mLastOpLayerIndex = index;
                moMap.Layers.Insert(index, sMapLayer);
                mGvShapeFiles.Insert(index, sGvShpFileManager);   //添加至要素文件管理列表
                mDbfFiles.Insert(index, sDbfFileManager); //添加至属性文件管理列表
                RefreshLayersTree();    //刷新图层列表
                if (moMap.Layers.Count == 1)
                {
                    moMap.FullExtent();
                }
                else
                {
                    moMap.RedrawMap();
                }
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

        //图层列表刷新
        private void RefreshLayersTree()
        {
            layersTree.Nodes.Clear();
            for(Int32 i = 0; i < moMap.Layers.Count; i++)
            {
                TreeNode layerNode = new TreeNode();
                layerNode.Text = moMap.Layers.GetItem(i).Name;
                layerNode.Checked = moMap.Layers.GetItem(i).Visible;
                layersTree.Nodes.Add(layerNode);
            }
            layersTree.Refresh();
        }

        //刷新图层下拉框
        private void RefreshSelectLayer()
        {
            SelectLayer.Items.Clear();
            for (Int32 i = 0; i < moMap.Layers.Count; i++)
            {
                SelectLayer.Items.Add(moMap.Layers.GetItem(i).Name);
            }
            SelectLayer.SelectedIndex = mLastOpLayerIndex;
            mOperatingLayerIndex = SelectLayer.SelectedIndex;
        }

        //寻找新打开图层的插入位置
        private Int32 SearchInsertIndex(MyMapObjects.moGeometryTypeConstant shapeType)
        {
            Int32 index = 0;
            for(; index < moMap.Layers.Count; index++)
            {
                if (shapeType == moMap.Layers.GetItem(index).ShapeType)
                {
                    return index;
                }
            }
            return index;
        }

        //根据屏幕上两点获得一个地图坐标下的矩形
        private MyMapObjects.moRectangle GetMapRectByTwoPoints(PointF point1, PointF point2)
        {
            MyMapObjects.moPoint sPoint1 = moMap.ToMapPoint(point1.X, point1.Y);
            MyMapObjects.moPoint sPoint2 = moMap.ToMapPoint(point2.X, point2.Y);
            double sMinX = Math.Min(sPoint1.X, sPoint2.X);
            double sMaxX = Math.Max(sPoint1.X, sPoint2.X);
            double sMinY = Math.Min(sPoint1.Y, sPoint2.Y);
            double sMaxY = Math.Max(sPoint1.Y, sPoint2.Y);
            MyMapObjects.moRectangle sRect = new MyMapObjects.moRectangle(sMinX, sMaxX, sMinY, sMaxY);
            return sRect;
        }


        #endregion

        
    }
}
