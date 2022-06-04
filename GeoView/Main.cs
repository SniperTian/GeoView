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
        private MyMapObjects.moSimpleLineSymbol mMovingPolylineSymbol;
        private MyMapObjects.moSimpleMarkerSymbol mMovingPointSymbol;
        private MyMapObjects.moSimpleFillSymbol mEditingPolygonSymbol;  //正在编辑的多边形符号
        private MyMapObjects.moSimpleLineSymbol mEditingPolylineSymbol;
        private MyMapObjects.moSimpleMarkerSymbol mEditingVertexSymbol; //正在编辑的图形顶点的符号
        private MyMapObjects.moSimpleLineSymbol mElasticSymbol; //橡皮筋符号
        private bool mShowLngLat = false;   //是否显示经纬度

        //(2)与地图操作有关的变量
        private Int32 mMapOpStyle = 0;  //0：无，1：编辑（可选择可移动）,2:描绘要素
        private Int32 mOperatingLayerIndex = -1;    //当前操作的图层索引
        private PointF mStartMouseLocation;
        private bool mIsInZoomIn = false;
        private bool mIsInPan = false;
        private bool mIsInSelect = false;
        private bool mIsInMove = false;
        private bool mIsInIdentify = false;
        private bool mReallyMove = false;   //移动状态是否真的拖动要素进行了移动
        private Int32 mLastOpLayerIndex = -1;   //最近一次操作的图层索引
        private bool mReallyModified = false;   //修改了数据且没有保存
        //正在移动的图形的集合
        private List<MyMapObjects.moGeometry> mMovingGeometries = new List<MyMapObjects.moGeometry>();
        private MyMapObjects.moGeometry mEditingGeometry;   //正在编辑的图形
        private List<MyMapObjects.moPoints> mSketchingShape;    //正在描绘的图形，用一个多点集合存储；
        private List<MyMapObjects.moPoint> mSketchingPoint; //正在描绘的点


        //(3)与文件操作相关的变量
        private List<DataIOTools.gvShpFileManager> mGvShapeFiles = new List<DataIOTools.gvShpFileManager>();    //管理要素文件
        private List<DataIOTools.dbfFileManager> mDbfFiles = new List<DataIOTools.dbfFileManager>();    //管理属性文件
        private MyMapObjects.moLayers mDataBeforeEdit;

        //(4)与图层渲染有关的变量
        private bool mIsInPointRenderer = false;//是否选中点图层渲染
        private Int32 mPointRendererMode = 0; //渲染方式,0:简单渲染,1:唯一值渲染,2:分级渲染
        private Int32 mPointSymbolStyle = 0; //样式索引
        private Color mPointSimpleRendererColor = Color.Red; //符号颜色
        private Double mPointSimpleRendererSize = 5; //符号尺寸
        private Int32 mPointUniqueFieldIndex = 0; //绑定字段索引
        private Double mPointUniqueRendererSize = 5; //符号尺寸
        private Int32 mPointClassBreaksFieldIndex = 0; //绑定字段索引
        private Int32 mPointClassBreaksNum = 5; //分类数
        private Color mPointClassBreaksRendererColor = Color.Red; //符号颜色
        private Double mPointClassBreaksRendererMinSize = 3; //符号起始尺寸,点图层采用符号尺寸进行分级表示
        private Double mPointClassBreaksRendererMaxSize = 6; //符号终止尺寸

        private bool mIsInPolylineRenderer = false;//是否选中线图层渲染
        private Int32 mPolylineRendererMode = 0; //渲染方式,0:简单渲染,1:唯一值渲染,2:分级渲染
        private Int32 mPolylineSymbolStyle = 0; //样式索引
        private Color mPolylineSimpleRendererColor = Color.Red; //符号颜色
        private Double mPolylineSimpleRendererSize = 5; //符号尺寸
        private Int32 mPolylineUniqueFieldIndex = 0; //绑定字段索引
        private Double mPolylineUniqueRendererSize = 5; //符号尺寸
        private Int32 mPolylineClassBreaksFieldIndex = 0; //绑定字段索引
        private Int32 mPolylineClassBreaksNum = 5; //分类数
        private Color mPolylineClassBreaksRendererColor = Color.Red; //符号颜色
        private Double mPolylineClassBreaksRendererMinSize = 3; //符号起始尺寸,线图层采用符号尺寸进行分级表示
        private Double mPolylineClassBreaksRendererMaxSize = 6; //符号终止尺寸

        private bool mIsInPolygonRenderer = false;//是否选中面图层渲染
        private Int32 mPolygonRendererMode = 0; //渲染方式,0:简单渲染,1:唯一值渲染,2:分级渲染
        private Color mPolygonSimpleRendererColor = Color.Red; //符号颜色
        private Int32 mPolygonUniqueFieldIndex = 0; //绑定字段索引
        private Int32 mPolygonClassBreaksFieldIndex = 0; //绑定字段索引
        private Int32 mPolygonClassBreaksNum = 5; //分类数
        private Color mPolygonClassBreaksRendererStartColor = Color.MistyRose; //符号起始颜色,面图层采用符号颜色进行分级表示
        private Color mPolygonClassBreaksRendererEndColor = Color.Red; //符号终止颜色

        #endregion
        public Main()
        {
            InitializeComponent();
            GvToolsInitial();
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

        //编辑
        private void EditSpBtn_Click(object sender, EventArgs e)
        {
            if (moMap.Layers.Count > 0)
            {
                BeginEditItem.Enabled = true;
            }
        }

        //开始编辑
        private void BeginEditItem_Click(object sender, EventArgs e)
        {
            EndEditItem.Enabled = true;
            SaveEditItem.Enabled = true;
            MoveFeatureBtn.Enabled = true;
            CreateFeatureBtn.Enabled = true;
            SelectLayer.Enabled = true;
            RefreshSelectLayer();
            MoveFeatureBtn_Click(sender, e);
            mReallyModified = false;
        }

        //结束编辑
        private void EndEditItem_Click(object sender, EventArgs e)
        {
            if (mReallyModified == true)
            {
                DialogResult dr = MessageBox.Show("是否要保存编辑内容", "Saving", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                else if(dr == DialogResult.Yes)
                {
                    SaveEditItem_Click(sender, e);
                }
                else
                {
                    CancelEdit();
                }
            }
            MoveFeatureBtn.Enabled = false;
            CreateFeatureBtn.Enabled = false;
            MoveFeatureBtn.Checked = false;
            CreateFeatureBtn.Checked = false;
            SelectLayer.SelectedIndex = -1;
            mOperatingLayerIndex = -1;
            SelectLayer.Enabled = false;
            EndEditItem.Enabled = false;
            SaveEditItem.Enabled = false;
            mMapOpStyle = 0;
            for (Int32 i = 0; i < moMap.Layers.Count; i++)
            {
                moMap.Layers.GetItem(i).SelectedFeatures.Clear();
                moMap.Layers.GetItem(i).SelectIndex.Clear();
            }
            moMap.RedrawMap();
        }

        //保存编辑
        private void SaveEditItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (Int32 i = 0; i < moMap.Layers.Count; i++)
                {
                    //图形数据
                    MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(i);
                    mGvShapeFiles[i].Geometries.Clear();
                    for (Int32 j = 0; j < sLayer.Features.Count; j++)
                    {
                        mGvShapeFiles[i].Geometries.Add(sLayer.Features.GetItem(j).Geometry);
                    }
                    mGvShapeFiles[i].UpdateGeometries(mGvShapeFiles[i].Geometries);
                    string path = mGvShapeFiles[i].DefaultFilePath;
                    mGvShapeFiles[i].SaveToFile(path);
                    //属性数据
                    mDbfFiles[i].Fields = sLayer.AttributeFields;
                    mDbfFiles[i].AttributesList.Clear();
                    for(Int32 j = 0; j < sLayer.Features.Count; j++)
                    {
                        mDbfFiles[i].AttributesList.Add(sLayer.Features.GetItem(j).Attributes);
                    }
                    mDbfFiles[i].UpdateAttributesList(mDbfFiles[i].AttributesList);
                    path = mDbfFiles[i].DefaultPath;
                    mDbfFiles[i].SaveToFile(path);
                }
                mReallyModified = false;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
                return;
            }
        }

        //选择并移动要素
        private void MoveFeatureBtn_Click(object sender, EventArgs e)
        {
            MoveFeatureBtn.Checked = true;
            if (CreateFeatureBtn.Checked)
            {
                CreateFeatureBtn.Checked = false;
            }
            mMapOpStyle = 1;    //默认为编辑操作
            RightMenuInSelect();
        }

        //新建要素
        private void CreateFeatureBtn_Click(object sender, EventArgs e)
        {
            CreateFeatureBtn.Checked = true;
            if (MoveFeatureBtn.Checked)
            {
                MoveFeatureBtn.Checked = false;
            }
            mMapOpStyle = 2;
            RightMenuInSketch();
        }

        //选择操作图层
        private void SelectLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectLayer.SelectedIndex == -1)
            {
                SelectLayer.DropDownStyle = ComboBoxStyle.DropDown;
                SelectLayer.Text = "请选择图层";
            }
            else
            {
                SelectLayer.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            mOperatingLayerIndex = SelectLayer.SelectedIndex;
            if (mOperatingLayerIndex != -1 && mGvShapeFiles[mOperatingLayerIndex].SourceFileType=="shp")
            {
                Int32 goOn = (Int32)MessageBox.Show("对shapefile文件进行编辑操作，会在同一目录下生成同名gvshp文件，操作会保存在该gvshp文件中！若已有同名gvshp文件，会进行覆盖，请知悉！是否继续？",
                    "Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);

                if (goOn == 1)
                {
                    mGvShapeFiles[mOperatingLayerIndex].SourceFileType = "gvshp";
                    string filePath = mGvShapeFiles[mOperatingLayerIndex].DefaultFilePath;
                    string sPath = filePath.Substring(0, filePath.IndexOf(".shp")) + ".gvshp";
                    mGvShapeFiles[mOperatingLayerIndex].SaveToFile(sPath);
                    mGvShapeFiles[mOperatingLayerIndex].DefaultFilePath = sPath;
                    filePath = mDbfFiles[mOperatingLayerIndex].DefaultPath;
                    sPath= filePath.Substring(0, filePath.IndexOf(".dbf")) + ".gvdbf";
                    mDbfFiles[mOperatingLayerIndex].SaveToFile(sPath);
                    mDbfFiles[mOperatingLayerIndex].DefaultPath = sPath;
                }
                else
                {
                    SelectLayer.SelectedIndex = -1;
                    mOperatingLayerIndex = -1;
                }
            }
        }

        private void moMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1)
            {
                OnEdit_MouseDown(e);
            }
            if (mMapOpStyle == 2)
            {
                ;
            }
        }

        private void OnEdit_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (mOperatingLayerIndex == -1) return;
            //判断应该是进行选择还是移动
            mIsInMove = false;
            mIsInSelect = false;
            MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
            if (moMap.Layers.GetItem(mOperatingLayerIndex).ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
            {
                for(Int32 i = 0; i < moMap.Layers.GetItem(mOperatingLayerIndex).SelectedFeatures.Count; i++)
                {
                    MyMapObjects.moFeature sFeature = moMap.Layers.GetItem(mOperatingLayerIndex).SelectedFeatures.GetItem(i);
                    MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)sFeature.Geometry;
                    if (MyMapObjects.moMapTools.IsPointWithinMultiPolygon(sPoint, sMultiPolygon))
                    {
                        mIsInMove = true;
                        break;
                    }
                }
            }
            else if(moMap.Layers.GetItem(mOperatingLayerIndex).ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                for(Int32 i = 0; i < moMap.Layers.GetItem(mOperatingLayerIndex).SelectedFeatures.Count; i++)
                {
                    MyMapObjects.moFeature sFeature = moMap.Layers.GetItem(mOperatingLayerIndex).SelectedFeatures.GetItem(i);
                    MyMapObjects.moMultiPolyline sMultiPolyline = (MyMapObjects.moMultiPolyline)sFeature.Geometry;
                    double sTolerance = moMap.ToMapDistance(mSelectingTolerance);
                    if (MyMapObjects.moMapTools.IsPointOnMultiPolyline(sPoint, sMultiPolyline, sTolerance))
                    {
                        mIsInMove = true;
                        break;
                    }
                }
            }
            else if(moMap.Layers.GetItem(mOperatingLayerIndex).ShapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                for (Int32 i = 0; i < moMap.Layers.GetItem(mOperatingLayerIndex).SelectedFeatures.Count; i++)
                {
                    MyMapObjects.moFeature sFeature = moMap.Layers.GetItem(mOperatingLayerIndex).SelectedFeatures.GetItem(i);
                    MyMapObjects.moPoint sFeaturePoint = (MyMapObjects.moPoint)sFeature.Geometry;
                    double sTolerance = moMap.ToMapDistance(mSelectingTolerance);
                    if (MyMapObjects.moMapTools.IsPointOnPoint(sPoint, sFeaturePoint, sTolerance))
                    {
                        mIsInMove = true;
                        break;
                    }
                }
            }
            else if(moMap.Layers.GetItem(mOperatingLayerIndex).ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPoint)
            {
                for (Int32 i = 0; i < moMap.Layers.GetItem(mOperatingLayerIndex).SelectedFeatures.Count; i++)
                {
                    MyMapObjects.moFeature sFeature = moMap.Layers.GetItem(mOperatingLayerIndex).SelectedFeatures.GetItem(i);
                    MyMapObjects.moPoints sPoints = (MyMapObjects.moPoints)sFeature.Geometry;
                    double sTolerance = moMap.ToMapDistance(mSelectingTolerance);
                    if (MyMapObjects.moMapTools.IsPointOnPolyline(sPoint, sPoints, sTolerance))
                    {
                        mIsInMove = true;
                        break;
                    }
                }
            }
            
            if (mIsInMove)
            {
                OnMoveSelect_MouseDown(e);
            }
            else
            {
                mIsInSelect = true;
                OnSelect_MouseDown(e);
            }
        }
        private void OnSelect_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
            }
        }
        private void OnMoveSelect_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
            Int32 sSelFeatureCount = sLayer.SelectedFeatures.Count;
            if (sSelFeatureCount == 0) return;
            //复制图层
            mMovingGeometries.Clear();
            if (sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
            {
                for (Int32 i = 0; i < sSelFeatureCount; ++i)
                {
                    MyMapObjects.moMultiPolygon sOriPolygon = (MyMapObjects.moMultiPolygon)sLayer.SelectedFeatures.GetItem(i).Geometry;
                    MyMapObjects.moMultiPolygon sDesPolygon = sOriPolygon.Clone();
                    mMovingGeometries.Add(sDesPolygon);
                }
            }
            else if (sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                for (Int32 i = 0; i < sSelFeatureCount; ++i)
                {
                    MyMapObjects.moMultiPolyline sOriPolygon = (MyMapObjects.moMultiPolyline)sLayer.SelectedFeatures.GetItem(i).Geometry;
                    MyMapObjects.moMultiPolyline sDesPolygon = sOriPolygon.Clone();
                    mMovingGeometries.Add(sDesPolygon);
                }
            }
            else if (sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                for (Int32 i = 0; i < sSelFeatureCount; ++i)
                {
                    MyMapObjects.moPoint sOriPolygon = (MyMapObjects.moPoint)sLayer.SelectedFeatures.GetItem(i).Geometry;
                    MyMapObjects.moPoint sDesPolygon = sOriPolygon.Clone();
                    mMovingGeometries.Add(sDesPolygon);
                }
            }
            else if (sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPoint)
            {
                for (Int32 i = 0; i < sSelFeatureCount; ++i)
                {
                    MyMapObjects.moPoints sOriPolygon = (MyMapObjects.moPoints)sLayer.SelectedFeatures.GetItem(i).Geometry;
                    MyMapObjects.moPoints sDesPolygon = sOriPolygon.Clone();
                    mMovingGeometries.Add(sDesPolygon);
                }
            }
            //设置变量
            mStartMouseLocation = e.Location;
            mReallyMove = false;
        }

        private void moMap_MouseMove(object sender, MouseEventArgs e)
        {
            ShowCoordinate(e.Location);
            if (mMapOpStyle == 1) 
            {
                OnEdit_MouseMove(e);
            }
            if (mMapOpStyle == 2)
            {
                OnSketch_MouseMove(e);
            }
        }

        private void OnEdit_MouseMove(MouseEventArgs e)
        {
            if (mIsInMove)
            {
                OnMoveSelect_MouseMove(e);
            }
            else if(mIsInSelect)
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
        private void OnMoveSelect_MouseMove(MouseEventArgs e)
        {
            if (mIsInMove == false) return;
            //修改移动图形的坐标
            double sDeltaX = moMap.ToMapDistance(e.Location.X - mStartMouseLocation.X);
            double sDeltaY = moMap.ToMapDistance(mStartMouseLocation.Y - e.Location.Y);
            mReallyMove = true;
            ModifyMovingGeometries(sDeltaX, sDeltaY);
            //刷新地图并绘制移动图形
            moMap.Refresh();
            DrawMovingShape();
            //重新设置鼠标位置
            mStartMouseLocation = e.Location;
        }
        private void OnSketch_MouseMove(MouseEventArgs e)
        {
            MyMapObjects.moMapLayer sMapLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
            MyMapObjects.moPoint sCurPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
            if (sMapLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
            {
                MyMapObjects.moPoints sLastPart = mSketchingShape.Last();
                Int32 sPointCount = sLastPart.Count;
                if (sPointCount == 0)
                { }
                else if (sPointCount == 1)
                {
                    moMap.Refresh();
                    //只有一个顶点，则绘制一条橡皮筋
                    MyMapObjects.moPoint sFirstPoint = sLastPart.GetItem(0);
                    MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
                    sDrawingTool.DrawLine(sFirstPoint, sCurPoint, mElasticSymbol);
                }
                else
                {
                    moMap.Refresh();
                    //两个以上顶点，则绘制两条橡皮筋
                    MyMapObjects.moPoint sFirstPoint = sLastPart.GetItem(0);
                    MyMapObjects.moPoint sLastPoint = sLastPart.GetItem(sPointCount - 1);
                    MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
                    sDrawingTool.DrawLine(sFirstPoint, sCurPoint, mElasticSymbol);
                    sDrawingTool.DrawLine(sLastPoint, sCurPoint, mElasticSymbol);
                }
            }
            else if (sMapLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                MyMapObjects.moPoints sLastPart = mSketchingShape.Last();
                Int32 sPointCount = sLastPart.Count;
                if (sPointCount == 0)
                { }
                else
                {
                    moMap.Refresh();
                    MyMapObjects.moPoint sLastPoint = sLastPart.GetItem(sPointCount - 1);
                    MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
                    sDrawingTool.DrawLine(sLastPoint, sCurPoint, mElasticSymbol);
                }
            }
            else if (sMapLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                ;
            }
            else if (sMapLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPoint)
            {
                ;
            }
        }

        private void moMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1) 
            {
                OnEdit_MouseUp(e);
            }
        }

        private void OnEdit_MouseUp(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (mIsInMove)
            {
                OnMoveSelect_MouseUp(e);
            }
            else if(mIsInSelect)
            {
                OnSelect_MouseUp(e);
            }
        }
        //只在当前编辑的图层中进行选择(与demo中有不同)
        private void OnSelect_MouseUp(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
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
        private void OnMoveSelect_MouseUp(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (mIsInMove == false) return;
            mIsInMove = false;
            if (mReallyMove)
            {
                //做相应的数据修改
                mReallyMove = false;
                mReallyModified = true;
                MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
                for (Int32 i = 0; i < sLayer.SelectedFeatures.Count; i++)
                {
                    MyMapObjects.moFeature sFeature = sLayer.SelectedFeatures.GetItem(i);
                    sFeature.Geometry = mMovingGeometries[i];
                }
                sLayer.UpdateExtent();
                //重构地图
                moMap.RedrawMap();
            }
            else
            {
                MyMapObjects.moRectangle sBox = GetMapRectByTwoPoints(e.Location, e.Location);
                double sTolerance = moMap.ToMapDistance(mSelectingTolerance);
                moMap.SelectLayerByBox(sBox, sTolerance, mOperatingLayerIndex); //该方法只在当前图层中选择，与demo中不同
                moMap.RedrawTrackingShapes();
            }
            //清除移动图形列表
            mMovingGeometries.Clear();
        }

        private void moMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1)
            {
                ;
            }
            else if (mMapOpStyle == 2)
            {
                OnSketch_MouseClick(e);
            }
        }
        private void OnSketch_MouseClick(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            MyMapObjects.moMapLayer sMapLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
            if (sMapLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                //将屏幕坐标转换为地图坐标并加入描绘图形
                MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
                mSketchingPoint.Add(sPoint);
                EndSketchGeo(sMapLayer.ShapeType);
                //地图控件重绘跟踪图层
                moMap.RedrawTrackingShapes();
            }
            else if (sMapLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPoint)
            {
                //将屏幕坐标转换为地图坐标并加入描绘图形
                MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
                mSketchingPoint.Add(sPoint);
                EndSketchPart(sMapLayer.ShapeType);
                //地图控件重绘跟踪图层
                moMap.RedrawTrackingShapes();
            }
            else
            {
                //将屏幕坐标转换为地图坐标并加入描绘图形
                MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
                mSketchingShape.Last().Add(sPoint);
                //地图控件重绘跟踪图层
                moMap.RedrawTrackingShapes();
            }
        }
        

        private void moMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (mMapOpStyle == 2)
            {
                OnSketch_MouseDoubleClick(e);
            }
        }
        private void OnSketch_MouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            MyMapObjects.moMapLayer sMapLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
            EndSketchPart(sMapLayer.ShapeType);
            EndSketchGeo(sMapLayer.ShapeType);
        }

        private void moMap_AfterTrackingLayerDraw(object sender, MyMapObjects.moUserDrawingTool drawingTool)
        {
            DrawSketchingShapes(drawingTool);   //绘制描绘图形
            DrawEditingShapes(drawingTool); //绘制正在编辑的图形
        }

        private void moMap_MapScaleChanged(object sender)
        {
            ShowMapScale();
        }

        private void moMapRightMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (mMapOpStyle == 1)
            {
                RightOperateInSelect(e);
            }
            else if (mMapOpStyle == 2)
            {
                RightOperateInSketch(e);
            }
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
                    sGvShpFileManager.DefaultFilePath = shpFilePath;
                    sGvShpFileManager.UpdateGeometries(sGeometries);
                }
                else
                {
                    //读取gvshp文件
                    string gvshpFilePath = sFileName;
                    dbfFilePath = gvshpFilePath.Substring(0, gvshpFilePath.IndexOf(".gvshp")) + ".gvdbf";
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

        private void layersTree_MouseDown(object sender, MouseEventArgs e)
        {
            Point clickPoint = new Point(e.X, e.Y);
            TreeNode currentNode = layersTree.GetNodeAt(clickPoint);
            if (currentNode != null)
            {
                layersTree.SelectedNode = currentNode;
                mLastOpLayerIndex = currentNode.Index;  //鼠标单击或右键菜单对应的图层索引
            }
            else 
            {
                if(e.Button == MouseButtons.Right)
                {
                    mLastOpLayerIndex = -1;
                }
            }
        }

        private void 移除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 打开属性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 缩放至图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 编辑要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectLayer.Enabled == true)    //编辑状态
            {
                if (SelectLayer.SelectedIndex != mLastOpLayerIndex) //更换编辑图层
                {
                    EndEditItem_Click(sender, e);
                }
            }
            BeginEditItem_Click(sender, e);
        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region 图层渲染
        public void GetPointRenderer(Int32 renderMode, Int32 symbolStyle, Color simpleRendererColor, Double simpleRendererSize,
            Int32 uniqueFieldIndex, Double uniqueRendererSize, Int32 classBreakFieldIndex, Int32 classNum,
            Color classBreakRendererColor, double classBreakRendererMinSize, double classBreakRendererMaxSize)
        {
            mPointRendererMode = renderMode;
            mPointSymbolStyle = symbolStyle;
            mPointSimpleRendererColor = simpleRendererColor;
            mPointSimpleRendererSize = simpleRendererSize;
            mPointUniqueFieldIndex = uniqueFieldIndex;
            mPointUniqueRendererSize = uniqueRendererSize;
            mPointClassBreaksFieldIndex = classBreakFieldIndex;
            mPointClassBreaksNum = classNum;
            mPointClassBreaksRendererColor = classBreakRendererColor;
            mPointClassBreaksRendererMinSize = classBreakRendererMinSize;
            mPointClassBreaksRendererMaxSize = classBreakRendererMaxSize;
            mIsInPointRenderer = true;
        }

        public void GetPolylineRenderer(Int32 renderMode, Int32 symbolStyle, Color simpleRendererColor, Double simpleRendererSize,
            Int32 uniqueFieldIndex, Double uniqueRendererSize, Int32 classBreakFieldIndex, Int32 classNum,
            Color classBreakRendererColor, double classBreakRendererMinSize, double classBreakRendererMaxSize)
        {
            mPolylineRendererMode = renderMode;
            mPolylineSymbolStyle = symbolStyle;
            mPolylineSimpleRendererColor = simpleRendererColor;
            mPolylineSimpleRendererSize = simpleRendererSize;
            mPolylineUniqueFieldIndex = uniqueFieldIndex;
            mPolylineUniqueRendererSize = uniqueRendererSize;
            mPolylineClassBreaksFieldIndex = classBreakFieldIndex;
            mPolylineClassBreaksNum = classNum;
            mPolylineClassBreaksRendererColor = classBreakRendererColor;
            mPolylineClassBreaksRendererMinSize = classBreakRendererMinSize;
            mPolylineClassBreaksRendererMaxSize = classBreakRendererMaxSize;
            mIsInPolylineRenderer = true;
        }

        public void GetPolygonRenderer(Int32 renderMode, Color simpleRendererColor,
            Int32 uniqueFieldIndex, Int32 classBreakFieldIndex, Int32 classNum,
            Color classBreakRendererStartColor, Color classBreakRendererEndColor)
        {
            mPolygonRendererMode = renderMode;
            mPolygonSimpleRendererColor = simpleRendererColor;
            mPolygonUniqueFieldIndex = uniqueFieldIndex;
            mPolygonClassBreaksFieldIndex = classBreakFieldIndex;
            mPolygonClassBreaksNum = classNum;
            mPolygonClassBreaksRendererStartColor = classBreakRendererStartColor;
            mPolygonClassBreaksRendererEndColor = classBreakRendererEndColor;
            mIsInPolygonRenderer = true;
        }

        /// <summary>
        /// 图层渲染函数,需移植到图层栏右键菜单中的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RendererClick(object sender, EventArgs e)
        {
            MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(mLastOpLayerIndex);//待渲染的图层
            if (sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                PointRenderer sPointRenderer = new PointRenderer(moMap.Layers.GetItem(mLastOpLayerIndex));
                sPointRenderer.Owner = this;
                sPointRenderer.ShowDialog();
                //简单渲染
                if (mPointRendererMode == 0)
                {
                    MyMapObjects.moSimpleRenderer sRenderer = new MyMapObjects.moSimpleRenderer();
                    MyMapObjects.moSimpleMarkerSymbol sSymbol = new MyMapObjects.moSimpleMarkerSymbol();
                    sSymbol.Style = (MyMapObjects.moSimpleMarkerSymbolStyleConstant)mPointSymbolStyle;//修改样式
                    sSymbol.Color = mPointSimpleRendererColor;//修改颜色
                    sSymbol.Size = mPointSimpleRendererSize;//修改尺寸
                    sRenderer.Symbol = sSymbol;
                    sLayer.Renderer = sRenderer;
                    moMap.RedrawMap();
                }
                //唯一值渲染
                else if (mPointRendererMode == 1)
                {
                    MyMapObjects.moUniqueValueRenderer sRenderer = new MyMapObjects.moUniqueValueRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(mPointUniqueFieldIndex).Name;
                    List<string> sValues = new List<string>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    for (Int32 i = 0; i < sFeatrueCount; i++) //加入所有要素的属性值
                    {
                        string sValue = Convert.ToString(sLayer.Features.GetItem(i).Attributes.GetItem(mPointUniqueFieldIndex));
                        sValues.Add(sValue);
                    }
                    //去除重复
                    sValues = sValues.Distinct().ToList();
                    //生成符号
                    Int32 sValueCount = sValues.Count;
                    for (Int32 i = 0; i < sValueCount; i++)
                    {
                        MyMapObjects.moSimpleMarkerSymbol sSymbol = new MyMapObjects.moSimpleMarkerSymbol();
                        sSymbol.Style = (MyMapObjects.moSimpleMarkerSymbolStyleConstant)mPointSymbolStyle;//修改样式
                        sSymbol.Size = mPointSimpleRendererSize;//修改尺寸
                        sRenderer.AddUniqueValue(sValues[i], sSymbol);
                    }
                    sRenderer.DefaultSymbol = new MyMapObjects.moSimpleMarkerSymbol();
                    sLayer.Renderer = sRenderer;
                    moMap.RedrawMap();
                }
                //分级渲染
                else if (mPointRendererMode == 2)
                {
                    MyMapObjects.moClassBreaksRenderer sRenderer = new MyMapObjects.moClassBreaksRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(mPointClassBreaksFieldIndex).Name;
                    List<double> sValues = new List<double>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    Int32 sFieldIndes = sLayer.AttributeFields.FindField(sRenderer.Field);
                    //读出所有值,判断是否为数值字段
                    try
                    {
                        for (Int32 i = 0; i < sFeatrueCount; i++)
                        {
                            double sValue = Convert.ToDouble(sLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndes));
                            sValues.Add(sValue);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("该字段不是数值字段，不支持分级渲染！");
                        return;
                    }
                    //获取最小最大值并分级
                    double sMinValue = sValues.Min();
                    double sMaxValue = sValues.Max();
                    for (Int32 i = 0; i < mPointClassBreaksNum; i++)
                    {
                        double sValue = sMinValue + (sMaxValue - sMinValue) * (i + 1) / mPointClassBreaksNum;
                        MyMapObjects.moSimpleMarkerSymbol sSymbol = new MyMapObjects.moSimpleMarkerSymbol();
                        sSymbol.Color = mPointClassBreaksRendererColor;
                        sSymbol.Style = (MyMapObjects.moSimpleMarkerSymbolStyleConstant)mPointSymbolStyle;
                        sRenderer.AddBreakValue(sValue, sSymbol);
                    }
                    double sMinSize = mPointClassBreaksRendererMinSize;
                    double sMaxSize = mPointClassBreaksRendererMaxSize;
                    sRenderer.RampSize(sMinSize, sMaxSize);
                    sRenderer.DefaultSymbol = new MyMapObjects.moSimpleMarkerSymbol();
                    sLayer.Renderer = sRenderer;
                    moMap.RedrawMap();
                }
            }
            else if (sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                PolylineRenderer sPolylineRenderer = new PolylineRenderer(moMap.Layers.GetItem(mLastOpLayerIndex));
                sPolylineRenderer.Owner = this;
                sPolylineRenderer.ShowDialog();
                //简单渲染
                if (mPolylineRendererMode == 0)
                {
                    MyMapObjects.moSimpleRenderer sRenderer = new MyMapObjects.moSimpleRenderer();
                    MyMapObjects.moSimpleLineSymbol sSymbol = new MyMapObjects.moSimpleLineSymbol();
                    sSymbol.Style = (MyMapObjects.moSimpleLineSymbolStyleConstant)mPolylineSymbolStyle;//传参修改
                    sSymbol.Color = mPolylineSimpleRendererColor;//修改颜色
                    sSymbol.Size = mPolylineSimpleRendererSize;//修改尺寸
                    sRenderer.Symbol = sSymbol;
                    sLayer.Renderer = sRenderer;
                    moMap.RedrawMap();
                }
                //唯一值渲染
                else if (mPolylineRendererMode == 1)
                {
                    MyMapObjects.moUniqueValueRenderer sRenderer = new MyMapObjects.moUniqueValueRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(mPolylineUniqueFieldIndex).Name;
                    List<string> sValues = new List<string>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    for (Int32 i = 0; i < sFeatrueCount; i++)
                    {
                        string sValue = Convert.ToString(sLayer.Features.GetItem(i).Attributes.GetItem(mPolylineUniqueFieldIndex));
                        sValues.Add(sValue);
                    }
                    //去除重复
                    sValues = sValues.Distinct().ToList();
                    //生成符号
                    Int32 sValueCount = sValues.Count;
                    for (Int32 i = 0; i < sValueCount; i++)
                    {
                        MyMapObjects.moSimpleLineSymbol sSymbol = new MyMapObjects.moSimpleLineSymbol();
                        sSymbol.Style = (MyMapObjects.moSimpleLineSymbolStyleConstant)mPolylineSymbolStyle;//修改样式
                        sSymbol.Size = mPolylineUniqueRendererSize;//修改尺寸
                        sRenderer.AddUniqueValue(sValues[i], sSymbol);
                    }
                    sRenderer.DefaultSymbol = new MyMapObjects.moSimpleLineSymbol();
                    sLayer.Renderer = sRenderer;
                    moMap.RedrawMap();
                }
                //分级渲染
                else if (mPolylineRendererMode == 2)
                {
                    MyMapObjects.moClassBreaksRenderer sRenderer = new MyMapObjects.moClassBreaksRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(mPolylineClassBreaksFieldIndex).Name;
                    List<double> sValues = new List<double>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    Int32 sFieldIndes = sLayer.AttributeFields.FindField(sRenderer.Field);
                    //读出所有值,判断是否是数值字段
                    try
                    {
                        for (Int32 i = 0; i < sFeatrueCount; i++)
                        {
                            double sValue = Convert.ToDouble(sLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndes));
                            sValues.Add(sValue);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("该字段不是数值字段，不支持分级渲染！");
                        return;
                    }

                    //获取最小最大值并分5级
                    double sMinValue = sValues.Min();
                    double sMaxValue = sValues.Max();
                    for (Int32 i = 0; i < mPolylineClassBreaksNum; i++)
                    {
                        double sValue = sMinValue + (sMaxValue - sMinValue) * (i + 1) / mPolylineClassBreaksNum;
                        MyMapObjects.moSimpleLineSymbol sSymbol = new MyMapObjects.moSimpleLineSymbol();
                        sSymbol.Color = mPolylineClassBreaksRendererColor;
                        sSymbol.Style = (MyMapObjects.moSimpleLineSymbolStyleConstant)mPolylineSymbolStyle;
                        sRenderer.AddBreakValue(sValue, sSymbol);
                    }
                    double sMinSize = mPolylineClassBreaksRendererMinSize;
                    double sMaxSize = mPolylineClassBreaksRendererMaxSize;
                    sRenderer.RampSize(sMinSize, sMaxSize);
                    sRenderer.DefaultSymbol = new MyMapObjects.moSimpleLineSymbol();
                    sLayer.Renderer = sRenderer;
                    moMap.RedrawMap();
                }
            }
            else if (sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
            {
                PolygonRenderer sPolygonRenderer = new PolygonRenderer(moMap.Layers.GetItem(mLastOpLayerIndex));
                sPolygonRenderer.Owner = this;
                sPolygonRenderer.ShowDialog();
                //简单渲染
                if (mPolygonRendererMode == 0)
                {
                    MyMapObjects.moSimpleRenderer sRenderer = new MyMapObjects.moSimpleRenderer();
                    MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol();
                    sSymbol.Color = mPolygonSimpleRendererColor;
                    sRenderer.Symbol = sSymbol;
                    sLayer.Renderer = sRenderer;
                    moMap.RedrawMap();
                }
                //唯一值渲染
                else if (mPolygonRendererMode == 1)
                {
                    MyMapObjects.moUniqueValueRenderer sRenderer = new MyMapObjects.moUniqueValueRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(mPolygonUniqueFieldIndex).Name;
                    List<string> sValues = new List<string>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    for (Int32 i = 0; i < sFeatrueCount; i++)
                    {
                        string sValue = Convert.ToString(sLayer.Features.GetItem(i).Attributes.GetItem(mPolygonUniqueFieldIndex));
                        sValues.Add(sValue);
                    }
                    //去除重复
                    sValues = sValues.Distinct().ToList();
                    //生成符号
                    Int32 sValueCount = sValues.Count;
                    for (Int32 i = 0; i <= sValueCount - 1; i++)
                    {
                        MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol();
                        sRenderer.AddUniqueValue(sValues[i], sSymbol);
                    }
                    sRenderer.DefaultSymbol = new MyMapObjects.moSimpleFillSymbol();
                    sLayer.Renderer = sRenderer;
                    moMap.RedrawMap();
                }
                //分级渲染
                else if (mPolygonRendererMode == 2)
                {
                    MyMapObjects.moClassBreaksRenderer sRenderer = new MyMapObjects.moClassBreaksRenderer();
                    sRenderer.Field = sLayer.AttributeFields.GetItem(mPolygonClassBreaksFieldIndex).Name;
                    List<double> sValues = new List<double>();
                    Int32 sFeatrueCount = sLayer.Features.Count;
                    Int32 sFieldIndes = sLayer.AttributeFields.FindField(sRenderer.Field);
                    //读出所有值
                    try
                    {
                        for (Int32 i = 0; i < sFeatrueCount; i++)
                        {
                            double sValue = Convert.ToDouble(sLayer.Features.GetItem(i).Attributes.GetItem(sFieldIndes));
                            sValues.Add(sValue);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("该字段不是数值字段，不支持分级渲染！");
                        return;
                    }

                    //获取最小最大值并分5级
                    double sMinValue = sValues.Min();
                    double sMaxValue = sValues.Max();
                    for (Int32 i = 0; i < mPolygonClassBreaksNum; i++)
                    {
                        double sValue = sMinValue + (sMaxValue - sMinValue) * (i + 1) / mPolygonClassBreaksNum;
                        MyMapObjects.moSimpleFillSymbol sSymbol = new MyMapObjects.moSimpleFillSymbol();
                        sRenderer.AddBreakValue(sValue, sSymbol);
                    }
                    Color sStartColor = mPolygonClassBreaksRendererStartColor;
                    Color sEndColor = mPolygonClassBreaksRendererEndColor;
                    sRenderer.RampColor(sStartColor, sEndColor);
                    sRenderer.DefaultSymbol = new MyMapObjects.moSimpleFillSymbol();
                    sLayer.Renderer = sRenderer;
                    moMap.RedrawMap();
                }
            }
        }
        #endregion

        #region 私有函数

        //初始化控件
        private void GvToolsInitial()
        {
            //moMapRightMenu.Items.Add("test");
        }

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
            mMovingPolylineSymbol = new MyMapObjects.moSimpleLineSymbol();
            mMovingPolylineSymbol.Color = Color.Black;
            mMovingPointSymbol = new MyMapObjects.moSimpleMarkerSymbol();
            mMovingPointSymbol.Color = Color.Black;
            mEditingPolygonSymbol = new MyMapObjects.moSimpleFillSymbol();
            mEditingPolygonSymbol.Color = Color.Transparent;
            mEditingPolygonSymbol.Outline.Color = Color.DarkGreen;
            mEditingPolygonSymbol.Outline.Size = 0.53;
            mEditingPolylineSymbol = new MyMapObjects.moSimpleLineSymbol();
            mEditingPolylineSymbol.Color = Color.DarkGreen;
            mEditingPolylineSymbol.Size = 0.53;
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
            mSketchingPoint = new List<MyMapObjects.moPoint>();
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
                layerNode.ContextMenuStrip = LayerRightMenu;
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
                if (shapeType < moMap.Layers.GetItem(index).ShapeType)
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

        //根据指定的平移量修改移动图形的坐标
        private void ModifyMovingGeometries(double deltaX, double deltaY)
        {
            Int32 sCount = mMovingGeometries.Count;
            for (Int32 i = 0; i <= sCount - 1; i++)
            {
                if (mMovingGeometries[i].GetType() == typeof(MyMapObjects.moMultiPolygon))
                {
                    MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mMovingGeometries[i];
                    Int32 sPartCount = sMultiPolygon.Parts.Count;
                    for (Int32 j = 0; j <= sPartCount - 1; j++)
                    {
                        MyMapObjects.moPoints sPoints = sMultiPolygon.Parts.GetItem(j);
                        Int32 sPointCount = sPoints.Count;
                        for (Int32 k = 0; k <= sPointCount - 1; k++)
                        {
                            MyMapObjects.moPoint sPoint = sPoints.GetItem(k);
                            sPoint.X = sPoint.X + deltaX;
                            sPoint.Y = sPoint.Y + deltaY;
                        }
                    }
                    sMultiPolygon.UpdateExtent();
                }
                else if (mMovingGeometries[i].GetType() == typeof(MyMapObjects.moMultiPolyline))
                {
                    MyMapObjects.moMultiPolyline sMultiPolyline = (MyMapObjects.moMultiPolyline)mMovingGeometries[i];
                    Int32 sPartCount = sMultiPolyline.Parts.Count;
                    for (Int32 j = 0; j <= sPartCount - 1; j++)
                    {
                        MyMapObjects.moPoints sPoints = sMultiPolyline.Parts.GetItem(j);
                        Int32 sPointCount = sPoints.Count;
                        for (Int32 k = 0; k <= sPointCount - 1; k++)
                        {
                            MyMapObjects.moPoint sPoint = sPoints.GetItem(k);
                            sPoint.X = sPoint.X + deltaX;
                            sPoint.Y = sPoint.Y + deltaY;
                        }
                    }
                    sMultiPolyline.UpdateExtent();
                }
                else if (mMovingGeometries[i].GetType() == typeof(MyMapObjects.moPoint))
                {
                    MyMapObjects.moPoint sPoint = (MyMapObjects.moPoint)mMovingGeometries[i];
                    sPoint.X = sPoint.X + deltaX;
                    sPoint.Y = sPoint.Y + deltaY;
                }
                else if (mMovingGeometries[i].GetType() == typeof(MyMapObjects.moPoints))
                {
                    MyMapObjects.moPoints sPoints = (MyMapObjects.moPoints)mMovingGeometries[i];
                    for(Int32 j = 0; j < sPoints.Count; j++)
                    {
                        MyMapObjects.moPoint sPoint = sPoints.GetItem(j);
                        sPoint.X = sPoint.X + deltaX;
                        sPoint.Y = sPoint.Y + deltaY;
                    }
                    sPoints.UpdateExtent();
                }
            }
        }

        //绘制正在移动的图形
        private void DrawMovingShape()
        {
            MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
            Int32 sCount = mMovingGeometries.Count;
            for (Int32 i = 0; i <= sCount - 1; i++)
            {
                if (mMovingGeometries[i].GetType() == typeof(MyMapObjects.moMultiPolygon))
                {
                    MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mMovingGeometries[i];
                    sDrawingTool.DrawMultiPolygon(sMultiPolygon, mMovingPolygonSymbol);
                }
                else if(mMovingGeometries[i].GetType() == typeof(MyMapObjects.moMultiPolyline))
                {
                    MyMapObjects.moMultiPolyline sMultiPolyline = (MyMapObjects.moMultiPolyline)mMovingGeometries[i];
                    sDrawingTool.DrawMultiPolyline(sMultiPolyline, mMovingPolylineSymbol);
                }
                else if (mMovingGeometries[i].GetType() == typeof(MyMapObjects.moPoint))
                {
                    MyMapObjects.moPoint sPoint = (MyMapObjects.moPoint)mMovingGeometries[i];
                    sDrawingTool.DrawPoint(sPoint, mMovingPointSymbol);
                }
                else if (mMovingGeometries[i].GetType() == typeof(MyMapObjects.moPoints))
                {
                    MyMapObjects.moPoints sPoints = (MyMapObjects.moPoints)mMovingGeometries[i];
                    sDrawingTool.DrawPoints(sPoints, mMovingPointSymbol);
                }
            }
        }

        //取消修改
        private void CancelEdit()
        {
            try
            {
                for (Int32 i = 0; i < moMap.Layers.Count; i++)
                {
                    MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(i);
                    MyMapObjects.moMapLayer sMapLayer = new MyMapObjects.moMapLayer(sLayer.Name, sLayer.ShapeType, mDbfFiles[i].Fields);
                    //加载要素
                    MyMapObjects.moFeatures sFeatures = new MyMapObjects.moFeatures();
                    for (Int32 j = 0; j < mGvShapeFiles[i].Geometries.Count; ++j)
                    {
                        MyMapObjects.moFeature sFeature = new MyMapObjects.moFeature(mGvShapeFiles[i].GeometryType, 
                            mGvShapeFiles[i].Geometries[j], mDbfFiles[i].AttributesList[j]);
                        sFeatures.Add(sFeature);
                    }
                    sMapLayer.Features = sFeatures;
                    sMapLayer.Renderer = sLayer.Renderer;
                    moMap.Layers.RemoveAt(i);
                    moMap.Layers.Insert(i, sMapLayer);
                }
                mReallyModified = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                return;
            }
        }

        //结束描绘部件
        private void EndSketchPart(MyMapObjects.moGeometryTypeConstant shapeType)
        {
            mReallyModified = true;
            if (shapeType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
            {
                //判断是否可以结束，即是否最少三个点
                if (mSketchingShape.Last().Count < 3)
                    return;
                //往描绘图形中增加一个多点对象
                MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
                mSketchingShape.Add(sPoints);
                //重绘跟踪层
                moMap.RedrawTrackingShapes();
            }
            else if (shapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                //判断是否可以结束，即是否最少两个点
                if (mSketchingShape.Last().Count < 2)
                    return;
                //往描绘图形中增加一个多点对象
                MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
                mSketchingShape.Add(sPoints);
                //重绘跟踪层
                moMap.RedrawTrackingShapes();
            }
            else if (shapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                ;
            }
            else if (shapeType == MyMapObjects.moGeometryTypeConstant.MultiPoint)
            {
                //重绘跟踪层
                moMap.RedrawTrackingShapes();
            }
        }

        //结束描绘图形
        private void EndSketchGeo(MyMapObjects.moGeometryTypeConstant shapeType)
        {
            mReallyModified = true;
            if (shapeType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
            {
                if (mSketchingShape.Last().Count >= 1 && mSketchingShape.Last().Count < 3)
                    return;
                //如果最后一个部件的点数为0，则删除最后一个部件
                if (mSketchingShape.Last().Count == 0)
                {
                    mSketchingShape.Remove(mSketchingShape.Last());
                }
                //如果用户的确输入了，则加入多边形图层
                if (mSketchingShape.Count > 0)
                {
                    //查找多边形图层，如果有则加入该图层
                    MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
                    //新建复合多边形
                    MyMapObjects.moMultiPolygon sMultiPolygon = new MyMapObjects.moMultiPolygon();
                    sMultiPolygon.Parts.AddRange(mSketchingShape.ToArray());
                    sMultiPolygon.UpdateExtent();
                    //生成要素并加入图层
                    MyMapObjects.moFeature sFeature = sLayer.GetNewFeature();
                    sFeature.Geometry = sMultiPolygon;
                    sLayer.Features.Add(sFeature);
                }
                //初始化描绘图形
                InitializeSketchingShape();
                //重绘地图
                moMap.RedrawMap();
            }
            else if (shapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                if (mSketchingShape.Last().Count == 1)
                    return;
                //如果最后一个部件的点数为0，则删除最后一个部件
                if (mSketchingShape.Last().Count == 0)
                {
                    mSketchingShape.Remove(mSketchingShape.Last());
                }
                //如果用户的确输入了，则加入多边形图层
                if (mSketchingShape.Count > 0)
                {
                    //查找多边形图层，如果有则加入该图层
                    MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
                    //新建复合多边形
                    MyMapObjects.moMultiPolyline sMultiPolyline = new MyMapObjects.moMultiPolyline();
                    sMultiPolyline.Parts.AddRange(mSketchingShape.ToArray());
                    sMultiPolyline.UpdateExtent();
                    //生成要素并加入图层
                    MyMapObjects.moFeature sFeature = sLayer.GetNewFeature();
                    sFeature.Geometry = sMultiPolyline;
                    sLayer.Features.Add(sFeature);
                }
                //初始化描绘图形
                InitializeSketchingShape();
                //重绘地图
                moMap.RedrawMap();
            }
            else if (shapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                if (mSketchingPoint.Count == 1)
                {
                    MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
                    MyMapObjects.moFeature sFeature = sLayer.GetNewFeature();
                    sFeature.Geometry = mSketchingPoint[0];
                    sLayer.Features.Add(sFeature);
                }
                InitializeSketchingShape();
                moMap.RedrawMap();
            }
            else if (shapeType == MyMapObjects.moGeometryTypeConstant.MultiPoint)
            {
                if (mSketchingPoint.Count > 0)
                {
                    MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
                    //新建复合多边形
                    MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
                    sPoints.AddRange(mSketchingPoint.ToArray());
                    sPoints.UpdateExtent();
                    //生成要素并加入图层
                    MyMapObjects.moFeature sFeature = sLayer.GetNewFeature();
                    sFeature.Geometry = sPoints;
                    sLayer.Features.Add(sFeature);
                }
                //初始化描绘图形
                InitializeSketchingShape();
                //重绘地图
                moMap.RedrawMap();
            }
        }

        //绘制正在描绘的图形
        private void DrawSketchingShapes(MyMapObjects.moUserDrawingTool drawingTool)
        {
            if (mOperatingLayerIndex == -1) return;
            MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
            if (sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
            {
                if (mSketchingShape == null)
                    return;
                Int32 sPartCount = mSketchingShape.Count;
                //绘制已经描绘完成的部分
                for (Int32 i = 0; i <= sPartCount - 2; i++)
                {
                    drawingTool.DrawPolygon(mSketchingShape[i], mEditingPolygonSymbol);
                }
                //正在描绘的部分（只有一个Part）
                MyMapObjects.moPoints sLastPart = mSketchingShape.Last();
                if (sLastPart.Count >= 2)
                    drawingTool.DrawPolyline(sLastPart, mEditingPolygonSymbol.Outline);
                //绘制所有顶点手柄
                for (Int32 i = 0; i <= sPartCount - 1; i++)
                {
                    MyMapObjects.moPoints sPoints = mSketchingShape[i];
                    drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
                }
            }
            else if (sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                if (mSketchingShape == null)
                    return;
                Int32 sPartCount = mSketchingShape.Count;
                //绘制已经描绘完成的部分
                for (Int32 i = 0; i <= sPartCount - 2; i++)
                {
                    drawingTool.DrawPolyline(mSketchingShape[i], mEditingPolylineSymbol);
                }
                //正在描绘的部分（只有一个Part）
                MyMapObjects.moPoints sLastPart = mSketchingShape.Last();
                if (sLastPart.Count >= 2)
                {
                    drawingTool.DrawPolyline(sLastPart, mEditingPolylineSymbol);
                }
                //绘制所有顶点手柄
                for (Int32 i = 0; i <= sPartCount - 1; i++)
                {
                    MyMapObjects.moPoints sPoints = mSketchingShape[i];
                    drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
                }
            }
            else if (sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                if (mSketchingPoint == null || mSketchingPoint.Count == 0)
                    return;
                drawingTool.DrawPoint(mSketchingPoint[0], mEditingVertexSymbol);
            }
            else if (sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPoint)
            {
                if (mSketchingPoint == null || mSketchingPoint.Count == 0)
                    return;
                MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
                sPoints.AddRange(mSketchingPoint.ToArray());
                drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
            }
        }

        //绘制正在编辑的图形
        private void DrawEditingShapes(MyMapObjects.moUserDrawingTool drawingTool)
        {
            if (mEditingGeometry == null)
                return;
            if (mEditingGeometry.GetType() == typeof(MyMapObjects.moMultiPolygon))
            {
                MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)mEditingGeometry;
                //绘制边界
                drawingTool.DrawMultiPolygon(sMultiPolygon, mEditingPolygonSymbol);
                //绘制顶点手柄
                Int32 sPartCount = sMultiPolygon.Parts.Count;
                for (Int32 i = 0; i <= sPartCount - 1; i++)
                {
                    MyMapObjects.moPoints sPoints = sMultiPolygon.Parts.GetItem(i);
                    drawingTool.DrawPoints(sPoints, mEditingVertexSymbol);
                }
            }
        }

        //选择状态右键菜单
        private void RightMenuInSelect()
        {
            if (mOperatingLayerIndex == -1) return;
            moMapRightMenu.Items.Clear();
            moMapRightMenu.Items.Add("复制");
            moMapRightMenu.Items.Add("粘贴");
            moMapRightMenu.Items.Add("删除");
        }

        //描绘状态右键菜单
        private void RightMenuInSketch()
        {
            if (mOperatingLayerIndex == -1) return;
            moMapRightMenu.Items.Clear();
            moMapRightMenu.Items.Add("结束部件");
            moMapRightMenu.Items.Add("完成草图");
            MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
        }

        private void RightOperateInSelect(ToolStripItemClickedEventArgs e)
        {
            if (mOperatingLayerIndex == -1) return;
            MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
            if (e.ClickedItem.Text == "删除")
            {
                sLayer.RemoveSelection();
                moMap.RedrawMap();
            }
        }

        private void RightOperateInSketch(ToolStripItemClickedEventArgs e)
        {
            if (mOperatingLayerIndex == -1) return;
            MyMapObjects.moMapLayer sLayer = moMap.Layers.GetItem(mOperatingLayerIndex);
            if (e.ClickedItem.Text == "结束部件")
            {
                EndSketchPart(sLayer.ShapeType);
            }
            else if (e.ClickedItem.Text == "完成草图")
            {
                EndSketchGeo(sLayer.ShapeType);
            }
        }

        #endregion
    }
}
