using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMapObjects
{
    /// <summary>
    /// 值类型常数
    /// </summary>
    public enum moValueTypeConstant
    {
        dInt16 = 0,
        dInt32 = 1,
        dInt64 = 2,
        dSingle = 3,
        dDouble = 4,
        dText = 5
    }
    public enum moSymbolTypeConstant
    {
        SimpleMarkerSymbol = 0,
        SimpleLineSymbol = 1,
        SimpleFillSymbol = 2
    }
    public enum moSimpleMarkerSymbolStyleConstant
    {
        Circle = 0,
        SolidCircle = 1,
        Triangle = 2,
        SolidTriangle = 3,
        Square = 4,
        SolidSquare = 5,
        CircleDot = 6,
        CircleCircle = 7
    }
    public enum moSimpleLineSymbolStyleConstant
    {
        Solid = 0,
        Dash = 1,
        Dot = 2,
        DashDot = 3,
        DashDotDot = 4
    }

    /// <summary>
    /// 几何类型常数
    /// </summary>
    public enum moGeometryTypeConstant
    {
        Point = 0,
        MultiPoint = 1,
        MultiPolyline = 2,
        MultiPolygon = 3,
    }

    /// <summary>
    /// 图层渲染类型常数
    /// </summary>
    public enum moRendererTypeConstant
    {
        Simple = 0,
        UniqueValue = 1,
        ClassBreaks = 2
    }

    /// <summary>
    /// 文本符号布局常数
    /// </summary>
    public enum moTextSymbolAlignmentConstant
    {
        TopLeft = 0,
        TopCenter = 1,
        TopRight = 2,
        CenterLeft = 3,
        CenterCenter = 4,
        CenterRight = 5,
        BottomLeft = 6,
        BottomCenter = 7,
        BottomRight = 8
    }

    /// <summary>
    /// 投影类型常数
    /// </summary>
    public enum moProjectionTypeConstant
    {
        None = 0,
        Mercator = 1,
        UTM = 2,
        Gauss_Kruger = 3,
        Lambert_Conformal_Conic_2SP = 4,
        Albers_Equal_Area = 5
    }

    /// <summary>
    /// 线性单位常数
    /// </summary>
    public enum moLinearUnitConstant
    {
        Millimeter = 0,
        Centimeter = 1,
        Decimeter = 2,
        Meter = 3,
        Kilometers = 4
    }
}
