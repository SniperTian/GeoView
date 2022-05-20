using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMapObjects
{
    //为地图显示、缩放、漫游定义的类，实现地图坐标与屏幕坐标的转换
    internal class moMapDrawingReference
    {
        #region 字段
        private double _OffsetX, _OffsetY;              //绘图区域左上点（0，0）对应的投影坐标系中的点，即投影坐标系相对屏幕坐标系的平移量
        private double _MapScale = 10000;               //比例尺的倒数
        private double _dpm = 96 / 0.0254;              //屏幕上每米代表的象素数
        private double _mpu = 1.0;                      //1个地图坐标单位代表的米数，一般为1.

        private const double mcMaxMapScale = 10000000000;    //地图显示比例尺倒数的最大值,100亿
        private const double mcMinMapScale = 1000;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="offsetX">绘图区域左上点在地图坐标系中的X坐标</param>
        /// <param name="offsetY">绘图区域左上点在地图坐标系中的Y坐标</param>
        /// <param name="mapScale">地图比例尺的倒数</param>
        /// <param name="dpm">每米代表的象素数</param>
        /// <param name="mpu">1个地图坐标单位代表的米数</param>
        internal moMapDrawingReference(double offsetX, double offsetY, double mapScale, double dpm, double mpu)
        {
            _OffsetX = offsetX;
            _OffsetY = offsetY;
            _MapScale = mapScale;
            _dpm = dpm;
            _mpu = mpu;
        }

        #endregion

        #region 属性

        internal double OffsetX
        {
            get { return _OffsetX; }
            set { _OffsetX = value; }
        }

        internal double OffsetY
        {
            get { return _OffsetY; }
            set { _OffsetY = value; }
        }

        internal double MapScale
        {
            get { return _MapScale; }
            set { _MapScale = value; }
        }

        internal double dpm
        {
            get { return _dpm; }
            set { _dpm = value; }
        }

        internal double mpu
        {
            get { return _mpu; }
            set { _mpu = value; }
        }

        #endregion

        #region 方法

        //设置视图
        internal void SetView(double offsetX, double offsetY, double mapScale)
        {
            _OffsetX = offsetX;
            _OffsetY = offsetY;
            _MapScale = mapScale;
        }

        //以指定中心和指定系数进行缩放
        internal void ZoomByCenter(moPoint center, double ratio)
        {
            double sMapScale = _MapScale / ratio;      //新的比例尺

            if (sMapScale > mcMaxMapScale)
                sMapScale = mcMaxMapScale;
            else if (sMapScale < mcMinMapScale)
                sMapScale = mcMinMapScale;
            double sRatio = _MapScale / sMapScale;      //实际的缩放系数
            double sOffsetX = _OffsetX + (1 - 1 / sRatio) * (center.X - _OffsetX);
            double sOffsetY = _OffsetY + (1 - 1 / sRatio) * (center.Y - _OffsetY);
            _OffsetX = sOffsetX;
            _OffsetY = sOffsetY;
            _MapScale = sMapScale;
        }

        //将指定范围缩放至指定大小的屏幕窗口
        internal void ZoomExtentToWindow(moRectangle rect, double windowWidth, double windowHeight)
        {
            double sRectWidth = rect.Width, sRectHeight = rect.Height;
            //计算宽高比例
            double sMapRatio = sRectWidth / sRectHeight;            //地图范围的宽高比
            double sWindowRatio = windowWidth / windowHeight;       //窗口的宽高比
            //计算缩放后比例尺
            double sMapScale;
            if (sMapRatio <= sWindowRatio)
            {
                //按照垂向充满窗体
                sMapScale = sRectHeight * _mpu / windowHeight * _dpm;
            }
            else
            {
                //按照横向充满窗体
                sMapScale = sRectWidth * _mpu / windowWidth * _dpm;
            }
            if (sMapScale > mcMaxMapScale)          //100亿
                sMapScale = mcMaxMapScale;          //防止溢出
            else if (sMapScale < mcMinMapScale)
                sMapScale = mcMinMapScale;            //防止溢出
            //计算偏移量
            double sOffsetX, sOffsetY;              //定义新的偏移量
            sOffsetX = (rect.MinX + rect.MaxX) / 2 - windowWidth / 2 / _dpm * sMapScale / _mpu;
            sOffsetY = (rect.MinY + rect.MaxY) / 2 + windowHeight / 2 / _dpm * sMapScale / _mpu;
            //赋值
            _OffsetX = sOffsetX;
            _OffsetY = sOffsetY;
            _MapScale = sMapScale;
        }

        //将地图平移指定量
        internal void PanDelta(double deltaX, double deltaY)
        {
            _OffsetX = _OffsetX - deltaX;
            _OffsetY = _OffsetY - deltaY;
        }

        //将屏幕坐标转换为地图坐标
        internal moPoint ToMapPoint(double x, double y)
        {
            double sX = x / _dpm / _mpu * _MapScale + _OffsetX;
            double sY = _OffsetY - y / _dpm / _mpu * _MapScale;
            moPoint sPoint = new moPoint(sX, sY);
            return sPoint;
        }

        //将地图坐标转换为屏幕坐标
        internal moPoint FromMapPoint(double x, double y)
        {
            double sX = (x - _OffsetX) / _MapScale * _dpm * _mpu;
            double sY = (_OffsetY - y) / _MapScale * _dpm * _mpu;
            moPoint sPoint = new moPoint(sX, sY);
            return sPoint;
        }

        //将屏幕距离转换为地图距离
        internal double ToMapDistance(double dis)
        {
            double sDis = dis * _MapScale / _mpu / _dpm;
            return sDis;
        }

        //将地图距离转换为屏幕距离
        internal double FromMapDistance(double dis)
        {
            double sDis = dis / _MapScale * _dpm * _mpu;
            return sDis;
        }
        #endregion
    }
}
