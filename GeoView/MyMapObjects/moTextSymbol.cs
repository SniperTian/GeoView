using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyMapObjects
{
    public class moTextSymbol
    {
        #region 字段
        private Font _Font = new Font("微软雅黑", 8);       //字体
        private Color _FontColor = Color.Black;
        private moTextSymbolAlignmentConstant _Alignment = moTextSymbolAlignmentConstant.CenterCenter;   //布局
        private double _OffsetX, _OffsetY;  //X,Y方向偏移量，单位毫米，向右为正，向上为正 
        private bool _UseMask = false;      //是否使用描边
        private Color _MaskColor = Color.White; //描边的颜色
        private double _MaskWidth = 0.5;    //描边宽度，单位毫米
        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置字体
        /// </summary>
        public Font Font
        {
            get { return _Font; }
            set { _Font = value; }
        }

        /// <summary>
        /// 获取或设置字体颜色
        /// </summary>
        public Color FontColor
        {
            get { return _FontColor; }
            set { _FontColor = value; }
        }

        /// <summary>
        /// 获取或设置布局
        /// </summary>
        public moTextSymbolAlignmentConstant Alignment
        {
            get { return _Alignment; }
            set { _Alignment = value; }
        }

        /// <summary>
        /// 获取或设置X方向偏移量，向右为正
        /// </summary>
        public double OffsetX
        {
            get { return _OffsetX; }
            set { _OffsetX = value; }
        }

        /// <summary>
        /// 获取或设置Y方向偏移量，向上为正
        /// </summary>
        public double OffsetY
        {
            get { return _OffsetY; }
            set { _OffsetY = value; }
        }

        /// <summary>
        /// 指示是否描边
        /// </summary>
        public bool UseMask
        {
            get { return _UseMask; }
            set { _UseMask = value; }
        }

        /// <summary>
        /// 获取或设置描边颜色
        /// </summary>
        public Color MaskColor
        {
            get { return _MaskColor; }
            set { _MaskColor = value; }
        }

        /// <summary>
        /// 获取或设置描边宽度
        /// </summary>
        public double MaskWidth
        {
            get { return _MaskWidth; }
            set { _MaskWidth = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public moTextSymbol Clone()
        {
            moTextSymbol sTextSymbol = new moTextSymbol();
            sTextSymbol._Font = (Font)_Font.Clone();
            sTextSymbol._FontColor = _FontColor;
            sTextSymbol._Alignment = _Alignment;
            sTextSymbol._OffsetX = _OffsetX;
            sTextSymbol._OffsetY = _OffsetY;
            sTextSymbol._UseMask = _UseMask;
            sTextSymbol._MaskColor = _MaskColor;
            sTextSymbol._MaskWidth = _MaskWidth;
            return sTextSymbol;
        }
        #endregion
    }
}
