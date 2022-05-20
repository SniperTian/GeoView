using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;

namespace MyMapObjects
{
    public class moSimpleMarkerSymbol : moSymbol
    {
        #region 字段

        private string _Label = ""; //符号标签
        private bool _Visible = true; //是否可见
        private moSimpleMarkerSymbolStyleConstant _Style = moSimpleMarkerSymbolStyleConstant.SolidCircle; //形状
        private Color _Color = Color.LightPink; //颜色
        private double _Size = 3; //尺寸，默认为毫米

        #endregion

        #region 构造函数

        public moSimpleMarkerSymbol()
        {
            CreateRandomColor();
        }

        public moSimpleMarkerSymbol(string label)
        {
            _Label = label;
            CreateRandomColor();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取符号类型
        /// </summary>
        public override moSymbolTypeConstant SymbolType 
        {
            get
            {
                return moSymbolTypeConstant.SimpleMarkerSymbol;
            }
        }

        /// <summary>
        /// 获取或设置符号标签
        /// </summary>
        public string Label
        {
            get { return _Label; }
            set { _Label = value; }
        }

        /// <summary>
        /// 指示是否可见
        /// </summary>
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }

        /// <summary>
        /// 获取或设置形状类型
        /// </summary>
        public moSimpleMarkerSymbolStyleConstant Style
        {
            get { return _Style; }
            set { _Style = value; }
        }

        /// <summary>
        /// 获取或设置颜色
        /// </summary>
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        /// <summary>
        /// 获取或设置尺寸
        /// </summary>
        public double Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override moSymbol Clone()
        {
            moSimpleMarkerSymbol sSymbol = new moSimpleMarkerSymbol();
            sSymbol._Label = _Label;
            sSymbol._Visible = _Visible;
            sSymbol._Style = _Style;
            sSymbol._Color = _Color;
            sSymbol._Size = _Size;
            return sSymbol;
        }

        #endregion

        #region 私有函数

        /// <summary>
        /// 生成随机颜色
        /// </summary>
        private void CreateRandomColor()
        {
            //总体思想：每个随机颜色RGB中总有一个为252，其他两个值的取值范围为179-245，这样取值的目的在于让地图颜色偏浅，美观
            //生成4个元素的字节数组，第一个值决定哪个通道取252，另外三个中的两个值决定另外两个通道的值
            byte[] sBytes = new byte[4];
            RNGCryptoServiceProvider sChanelRng = new RNGCryptoServiceProvider();
            sChanelRng.GetBytes(sBytes);
            Int32 sChanelValue = sBytes[0];
            byte A = 255, R, G, B;
            if (sChanelValue <= 85)
            {
                R = 252;
                G = (byte)(179 + 66 * sBytes[2] / 255);
                B = (byte)(179 + 66 * sBytes[3] / 255);
            }
            else if (sChanelValue <= 170)
            {
                G = 252;
                R = (byte)(179 + 66 * sBytes[1] / 255);
                B = (byte)(179 + 66 * sBytes[3] / 255);
            }
            else
            {
                B = 252;
                R = (byte)(179 + 66 * sBytes[1] / 255);
                G = (byte)(179 + 66 * sBytes[2] / 255);
            }
            _Color = Color.FromArgb(A, R, G, B);
        }

        #endregion
    }
}
