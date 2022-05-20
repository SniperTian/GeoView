using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;

namespace MyMapObjects
{
    public class moSimpleFillSymbol:moSymbol
    {
        #region 字段

        private string _Label = "";
        private bool _Visible = true;
        private Color _Color = Color.LightPink;
        private moSimpleLineSymbol _Outline;

        #endregion

        #region 构造函数
        public moSimpleFillSymbol()
        {
            CreateRandomColor();
            InitializeOutline();
        }

        public moSimpleFillSymbol(string label)
        {
            _Label = label;
            CreateRandomColor();
            InitializeOutline();
        }

        #endregion

        #region 属性

        public override moSymbolTypeConstant SymbolType
        {
            get
            {
                return moSymbolTypeConstant.SimpleFillSymbol;
            }
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
        /// 获取或设置填充颜色
        /// </summary>
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        /// <summary>
        /// 获取或设置边界符号
        /// </summary>
        public moSimpleLineSymbol Outline
        {
            get { return _Outline; }
            set { _Outline = value; }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public override moSymbol Clone()
        {
            moSimpleFillSymbol sSymbol = new moSimpleFillSymbol();
            sSymbol._Label = _Label;
            sSymbol._Visible = _Visible;
            sSymbol._Color = _Color;
            sSymbol.Outline = (moSimpleLineSymbol)_Outline.Clone();
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

        //初始化边界符号
        private void InitializeOutline()
        {
            _Outline = new moSimpleLineSymbol();
            _Outline.Color = Color.DarkGray;
        }

        #endregion
    }
}
