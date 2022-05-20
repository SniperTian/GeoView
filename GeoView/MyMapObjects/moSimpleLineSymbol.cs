using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;


namespace MyMapObjects
{
    public class moSimpleLineSymbol:moSymbol
    {
        #region 字段

        private string _Label = "";     //符号标签
        private bool _Visible = true;   //是否可见
        private moSimpleLineSymbolStyleConstant _Style = moSimpleLineSymbolStyleConstant.Solid; //形状
        private Color _Color = Color.LightPink;     //颜色
        private double _Size = 0.35;    //宽度，单位毫米

        #endregion

        #region 构造函数

        public moSimpleLineSymbol()
        {
            CreateRandomColor();        //生成随机颜色
        }

        public moSimpleLineSymbol(string label)
        {
            _Label = label;
            CreateRandomColor();        //生成随机颜色
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取符号类型
        /// </summary>
        public override moSymbolTypeConstant SymbolType
        {
            get { return moSymbolTypeConstant.SimpleLineSymbol; }
        }

        /// <summary>
        /// 获取或设置标签
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
        /// 获取或设置形状
        /// </summary>
        public moSimpleLineSymbolStyleConstant Style
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
        /// 获取或设置宽度
        /// </summary>
        public double Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 复制
        /// </summary>
        public override moSymbol Clone()
        {
            moSimpleLineSymbol sSymbol = new moSimpleLineSymbol();
            sSymbol._Label = _Label;
            sSymbol._Visible = _Visible;
            sSymbol._Style = _Style;
            sSymbol._Color = _Color;
            sSymbol._Size = _Size;
            return sSymbol;
        }

        #endregion

        #region 私有函数

        //生成随机颜色
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
