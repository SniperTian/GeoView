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
        private Int32 mMapOpStyle = 0;  //0：无，1：放大，2：缩小，3：漫游，4：选择；5：查询；6：移动；7：描绘；8：编辑；
        private PointF mStartMouseLocation;
        private bool mIsInZoomIn = false;
        private bool mIsInPan = false;
        private bool mIsInSelect = false;
        private bool mIsInIdentify = false;
        private bool mIsInMovingShapes = false;   
        private Int32 mLastOpLayerIndex = -1;   //最近一次操作的图层索引
        //正在移动的图形的集合
        private List<MyMapObjects.moGeometry> mMovingGeometries = new List<MyMapObjects.moGeometry>();
        private MyMapObjects.moGeometry mEditingGeometry;   //正在编辑的图形
        private List<MyMapObjects.moPoints> mSketchingShape;    //正在描绘的图形，用一个多点集合存储；

        //图层渲染相关参数
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

        //(3)与文件操作相关的变量
        private List<DataIOTools.gvShpFileManager> mGvShapeFiles = new List<DataIOTools.gvShpFileManager>();    //管理要素文件
        private List<DataIOTools.dbfFileManager> mDbfFiles = new List<DataIOTools.dbfFileManager>();    //管理属性文件

        #endregion

        public Main()
        {
            InitializeComponent();
            moMap.MouseWheel += MoMap_MouseWheel;
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
        }

        private void CreateFeatureBtn_Click(object sender, EventArgs e)
        {
            CreateFeatureBtn.Checked = true;
            if (MoveFeatureBtn.Checked)
            {
                MoveFeatureBtn.Checked = false;
            }
        }

        private void tsbtnZoomIn_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 1;
        }

        private void tsbtnZoomOut_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 2;
        }

        private void tsbtnPan_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 3;
        }

        private void tsbtnSelect_Click(object sender, EventArgs e)
        {
            mMapOpStyle = 4;
        }
        #region 地图事件处理
        private void moMap_Click(object sender, EventArgs e)
        {
            
        }
        private void moMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1)//放大
            {
            }
            else if (mMapOpStyle == 2)//缩小
            {
                OnZoomOut_MouseClick(e);
            }
            else if (mMapOpStyle == 3)//漫游
            {

            }
            else if (mMapOpStyle == 4)//选择
            {

            }
            else if (mMapOpStyle == 5)//查询
            {

            }
            else if (mMapOpStyle == 6)//移动
            {

            }
            else if (mMapOpStyle == 7)//描绘
            {
            }
            else if (mMapOpStyle == 8)//编辑
            {
            }
        }
        //缩小状态下鼠标单击
        private void OnZoomOut_MouseClick(MouseEventArgs e)
        {
            //单点缩小
            MyMapObjects.moPoint sPoint = moMap.ToMapPoint(e.Location.X, e.Location.Y);
            moMap.ZoomByCenter(sPoint, 1 / mZoomRatioFixed);
        }

        private void moMap_DoubleClick(object sender, EventArgs e)
        {

        }
        
        private void moMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1)//放大
            {
                OnZoomIn_MouseDown(e);
            }
            else if (mMapOpStyle == 2)//缩小
            {
            }
            else if (mMapOpStyle == 3)//漫游
            {
                OnPan_MouseDown(e);
            }
            else if (mMapOpStyle == 4)//选择
            {
                OnSelect_MouseDown(e);
            }
            else if (mMapOpStyle == 5)//查询
            {
            }
            else if (mMapOpStyle == 6)//移动
            {
            }
            else if (mMapOpStyle == 7)//描绘
            {
            }
            else if (mMapOpStyle == 8)//编辑
            {
            }
        }
        //放大状态下鼠标按下
        private void OnZoomIn_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInZoomIn = true;
            }
        }

        //漫游状态下鼠标按下
        private void OnPan_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInPan = true;
                //this.Cursor = new Cursor("ico/PanUp.ico");
            }

        }

        //选择状态下鼠标按下
        private void OnSelect_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mStartMouseLocation = e.Location;
                mIsInSelect = true;
            }
        }
        //0：无，1：放大，2：缩小，3：漫游，4：选择；5：查询；6：移动；7：描绘；8：编辑；
        private void moMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1)//放大
            {
                OnZoomIn_MouseMove(e);
            }
            else if (mMapOpStyle == 2)//缩小
            {
            }
            else if (mMapOpStyle == 3)//漫游
            {
                OnPan_MouseMove(e);
            }
            else if (mMapOpStyle == 4)//选择
            {
                OnSelect_MouseMove(e);
            }
            else if (mMapOpStyle == 5)//查询
            {
            }
            else if (mMapOpStyle == 6)//移动
            { 
            }
            else if (mMapOpStyle == 7)//描绘
            {
            }
            else if (mMapOpStyle == 8)//编辑
            {
            }
        }

        //放大状态下鼠标移动
        private void OnZoomIn_MouseMove(MouseEventArgs e)
        {
            if (mIsInZoomIn == false)
            {
                return;
            }
            moMap.Refresh();
            MyMapObjects.moRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mZoomBoxSymbol);
        }

        //漫游状态下鼠标移动
        private void OnPan_MouseMove(MouseEventArgs e)
        {
            if (mIsInPan == false)
                return;
            moMap.PanMapImageTo(e.Location.X - mStartMouseLocation.X, e.Location.Y - mStartMouseLocation.Y);
        }

        //选择状态下鼠标移动
        private void OnSelect_MouseMove(MouseEventArgs e)
        {
            if (mIsInSelect == false)
                return;
            moMap.Refresh();
            MyMapObjects.moRectangle sRect = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            MyMapObjects.moUserDrawingTool sDrawingTool = moMap.GetDrawingTool();
            sDrawingTool.DrawRectangle(sRect, mZoomBoxSymbol);
        }

        private void moMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (mMapOpStyle == 1)//放大
            {
                OnZoomIn_MouseUp(e);
            }
            else if (mMapOpStyle == 2)//缩小
            {
            }
            else if (mMapOpStyle == 3)//漫游
            {
                OnPan_MouseUp(e);
            }
            else if (mMapOpStyle == 4)//选择
            {
                OnSelect_MouseUp(e);
            }
            else if (mMapOpStyle == 5)//查询
            {
            }
            else if (mMapOpStyle == 6)//移动
            {
            }
            else if (mMapOpStyle == 7)//描绘
            {
            }
            else if (mMapOpStyle == 8)//编辑
            {
            }
        }

        //放大状态下鼠标松开
        private void OnZoomIn_MouseUp(MouseEventArgs e)
        {
            if (mIsInZoomIn == false)
                return;
            mIsInZoomIn = false;
            if (mStartMouseLocation.X == e.Location.X && mStartMouseLocation.Y == e.Location.Y)
            {
                //单点放大
                MyMapObjects.moPoint sPoint = moMap.ToMapPoint(mStartMouseLocation.X, mStartMouseLocation.Y);
                moMap.ZoomByCenter(sPoint, mZoomRatioFixed);
            }
            else
            {
                //矩形放大
                MyMapObjects.moRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
                moMap.ZoomToExtent(sBox);
            }
        }

        //漫游状态下鼠标松开
        private void OnPan_MouseUp(MouseEventArgs e)
        {
            if (mIsInPan == false)
            {
                return;
            }
            mIsInPan = false;
            double sDeltaX = moMap.ToMapDistance(e.Location.X - mStartMouseLocation.X);
            double sDeltaY = moMap.ToMapDistance(mStartMouseLocation.Y - e.Location.Y);
            moMap.PanDelta(sDeltaX, sDeltaY);
        }

        //选择状态下鼠标松开
        private void OnSelect_MouseUp(MouseEventArgs e)
        {
            if (mIsInSelect == false)
            {
                return;
            }
            mIsInSelect = false;
            MyMapObjects.moRectangle sBox = GetMapRectByTwoPoints(mStartMouseLocation, e.Location);
            double sTolerance = moMap.ToMapDistance(mSelectingTolerance);
            moMap.SelectByBox(sBox, sTolerance, 0);
            moMap.RedrawTrackingShapes();
        }

        //鼠标滑轮事件
        private void MoMap_MouseWheel(object sender, MouseEventArgs e)
        {
            //计算地图控件中心的地图坐标
            double sX = moMap.ClientRectangle.Width / 2;
            double sY = moMap.ClientRectangle.Height / 2;
            MyMapObjects.moPoint sPoint = moMap.ToMapPoint(sX, sY);
            if (e.Delta > 0)
            {
                moMap.ZoomByCenter(sPoint, mZoomRatioMouseWheel);
            }
            else
            {
                moMap.ZoomByCenter(sPoint, 1 / mZoomRatioMouseWheel);
            }
        }

        #endregion

        //全范围显示
        private void tsbtnFullExtent_Click(object sender, EventArgs e)
        {
            moMap.FullExtent();
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
                mGvShapeFiles.Add(sGvShpFileManager);   //添加至要素文件管理列表
                mDbfFiles.Add(sDbfFileManager); //添加至属性文件管理列表
                                                //(4)添加至图层并加载
                string layerName = Path.GetFileNameWithoutExtension(sFileName);
                MyMapObjects.moMapLayer sMapLayer = new MyMapObjects.moMapLayer(layerName, sGeometryType, sFields);
                //加载要素
                MyMapObjects.moFeatures sFeatures = new MyMapObjects.moFeatures();
                for (Int32 i = 0; i < sGeometries.Count; ++i)
                {
                    MyMapObjects.moFeature sFeature = new MyMapObjects.moFeature(sGeometryType, sGeometries[i], sAttributes[i]);
                    sFeatures.Add(sFeature);
                }
                sMapLayer.Features = sFeatures;

                Int32 index = SearchInsertIndex(sMapLayer.ShapeType);
                moMap.Layers.Insert(index, sMapLayer);
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
        #region 图层渲染
        private void GetPointRenderer(Int32 renderMode, Int32 symbolStyle, Color simpleRendererColor, Double simpleRendererSize,
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

        private void GetPolylineRenderer(Int32 renderMode, Int32 symbolStyle, Color simpleRendererColor, Double simpleRendererSize,
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

        private void GetPolygonRenderer(Int32 renderMode, Color simpleRendererColor,
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
                if(mPointRendererMode == 0)
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
                else if(mPointRendererMode == 1)
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
            else if(sLayer.ShapeType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
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

        private void moMap_Load(object sender, EventArgs e)
        {

        }

        
    }
}
