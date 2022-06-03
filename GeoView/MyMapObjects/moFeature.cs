using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMapObjects
{
    public class moFeature
    {
        #region 字段

        private moGeometryTypeConstant _ShapeType = moGeometryTypeConstant.MultiPolygon; //几何类型
        private moGeometry _Geometry; //几何图形
        private moAttributes _Attributes; //属性集合
        private moSymbol _Symbol; //为该要素配置的符号

        #endregion

        #region 构造函数

        public moFeature(moGeometryTypeConstant shapeType,moGeometry geometry,moAttributes attributes)
        {
            _ShapeType = shapeType;
            _Geometry = geometry;
            _Attributes = attributes;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置几何类型
        /// </summary>
        public moGeometryTypeConstant ShapeType
        {
            get { return _ShapeType; }
            set { _ShapeType = value; }
        }

        /// <summary>
        /// 获取或设置几何图形
        /// </summary>
        public moGeometry Geometry
        {
            get { return _Geometry; }
            set { _Geometry = value; }
        }

        /// <summary>
        /// 获取或设置属性集合
        /// </summary>
        public moAttributes Attributes
        {
            get { return _Attributes; }
            set { _Attributes = value; }
        }

        /// <summary>
        /// 获取或设置要素符号
        /// </summary>
        internal moSymbol Symbol
        {
            get { return _Symbol;}
            set { _Symbol = value;}
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取要素的最小外包矩形
        /// </summary>
        /// <returns></returns>
        public moRectangle GetEnvelope()
        {
            moRectangle sRect = null;
            if (_ShapeType == moGeometryTypeConstant.Point)
            {
                moPoint sPoint = (moPoint)_Geometry;
                sRect = new moRectangle(sPoint.X, sPoint.X, sPoint.Y, sPoint.Y);

            }
            else
            {
                if (_ShapeType == moGeometryTypeConstant.MultiPolyline)
                {
                    moMultiPolyline sMultiPolyline = (moMultiPolyline)_Geometry;
                    sRect = sMultiPolyline.GetEnvelope();
                }
                else if (_ShapeType == moGeometryTypeConstant.MultiPolygon)
                {
                    moMultiPolygon sMultiPolygon = (moMultiPolygon)_Geometry;
                    sRect = sMultiPolygon.GetEnvelope();
                }
                else
                {
                    moPoints sPoints = (moPoints)_Geometry;
                    sRect = sPoints.GetEnvelope();
                }
            }
            return sRect;
        }

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public moFeature Clone()
        {
            moGeometryTypeConstant sShapeType = _ShapeType;
            moGeometry sGeometry = null;
            moAttributes sAttributes = _Attributes.Clone();
            if (_ShapeType == moGeometryTypeConstant.Point)
            {
                moPoint sPoint = (moPoint)_Geometry;
                sGeometry = sPoint.Clone();
            }
            else if (_ShapeType == moGeometryTypeConstant.MultiPolyline)
            {
                moMultiPolyline sMultiPolyline = (moMultiPolyline)_Geometry;
                sGeometry = sMultiPolyline.Clone();
            }
            else if (_ShapeType == moGeometryTypeConstant.MultiPolygon)
            {
                moMultiPolygon sMultiPolygon = (moMultiPolygon)_Geometry;
                sGeometry = sMultiPolygon.Clone();
            }
            moFeature sFeature = new moFeature(sShapeType, sGeometry, sAttributes);
            return sFeature;
        }

        #endregion
    }
}
