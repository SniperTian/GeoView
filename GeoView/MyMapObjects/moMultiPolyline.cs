using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMapObjects
{
    public class moMultiPolyline:moGeometry
    {
        #region 字段

        private moParts _Parts;
        double _MinX = double.MaxValue, _MaxX = double.MinValue;
        double _MinY = double.MaxValue, _MaxY = double.MinValue;

        #endregion

        #region 构造函数

        public moMultiPolyline()
        {
            _Parts = new moParts();
        }

        public moMultiPolyline(moPoints points)
        {
            _Parts = new moParts();
            _Parts.Add(points);
        }

        public moMultiPolyline(moParts parts)
        {
            _Parts = parts;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置部分集合
        /// </summary>
        public moParts Parts
        {
            get { return _Parts; }
            set { _Parts = value; }
        }

        /// <summary>
        /// 获取最小X坐标
        /// </summary>
        public double MinX
        {
            get { return _MinX; }
        }

        /// <summary>
        /// 获取最大X坐标
        /// </summary>
        public double MaxX
        {
            get { return _MaxX; }
        }

        /// <summary>
        /// 获取最小Y坐标
        /// </summary>
        public double MinY
        {
            get { return _MinY; }
        }

        /// <summary>
        /// 获取最大Y坐标
        /// </summary>
        public double MaxY
        {
            get { return _MaxY; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取外包矩形
        /// </summary>
        /// <returns></returns>
        public moRectangle GetEnvelope()
        {
            moRectangle sRectangle = new moRectangle(_MinX, _MaxX, _MinY, _MaxY);
            return sRectangle;
        }

        /// <summary>
        /// 重新计算坐标范围
        /// </summary>
        public void UpdateExtent()
        {
            CalExtent();
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public moMultiPolyline Clone()
        {
            moMultiPolyline sMultiPolyline = new moMultiPolyline();
            sMultiPolyline.Parts = _Parts.Clone();
            sMultiPolyline._MinX = _MinX;
            sMultiPolyline._MaxX = _MaxX;
            sMultiPolyline._MinY = _MinY;
            sMultiPolyline._MaxY = _MaxY;
            return sMultiPolyline;
        }

        #endregion

        #region 私有函数

        //计算坐标范围
        private void CalExtent()
        {
            double sMinX = double.MaxValue, sMaxX = double.MinValue;
            double sMinY = double.MaxValue, sMaxY = double.MinValue;
            Int32 sPartCount = _Parts.Count;
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                _Parts.GetItem(i).UpdateExtent();
                if (_Parts.GetItem(i).MinX < sMinX)
                    sMinX = _Parts.GetItem(i).MinX;
                if (_Parts.GetItem(i).MaxX > sMaxX)
                    sMaxX = _Parts.GetItem(i).MaxX;
                if (_Parts.GetItem(i).MinY < sMinY)
                    sMinY = _Parts.GetItem(i).MinY;
                if (_Parts.GetItem(i).MaxY > sMaxY)
                    sMaxY = _Parts.GetItem(i).MaxY;
            }
            _MinX = sMinX;
            _MaxX = sMaxX;
            _MinY = sMinY;
            _MaxY = sMaxY;
        }

        #endregion
    }
}
