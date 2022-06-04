using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyMapObjects
{
    public class moClassBreaksRenderer : moRenderer
    {
        #region 字段
        private string _Field = ""; //绑定字段
        private string _HeadTitle = "";     //在图层显示控件中的标题
        private bool _ShowHead = true;      //在图层显示控件是否显示标题
        private List<double> _BreakValues = new List<double>();       //分割值集合
        private List<moSymbol> _Symbols = new List<moSymbol>();//符号集合，小于第一个分割值对应第一个符号，依此类推
        private moSymbol _DefaultSymbol;    //默认符号
        private bool _ShowDefaultSymbol = true; //在图层显示控件中是否显示默认符号

        #endregion

        #region 构造函数
        public moClassBreaksRenderer()
        { }

        #endregion

        #region 属性

        /// <summary>
        /// 获取渲染类型
        /// </summary>
        public override moRendererTypeConstant RendererType
        {
            get
            {
                return moRendererTypeConstant.ClassBreaks;
            }
        }

        /// <summary>
        /// 获取或设置绑定字段名称
        /// </summary>
        public string Field
        {
            get { return _Field; }
            set
            {
                _Field = value;
                _HeadTitle = value;
            }
        }

        /// <summary>
        /// 获取分割值数目
        /// </summary>
        public Int32 BreakCount
        {
            get { return _BreakValues.Count; }
        }

        /// <summary>
        /// 获取或设置默认符号
        /// </summary>
        public moSymbol DefaultSymbol
        {
            get { return _DefaultSymbol; }
            set { _DefaultSymbol = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引号的分割值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double GetBreakValue(Int32 index)
        {
            return _BreakValues[index];
        }

        /// <summary>
        /// 设置指定索引号的分割值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetBreakValue(Int32 index, double breakValue)
        {
            _BreakValues[index] = breakValue;
        }

        /// <summary>
        /// 获取指定索引号的符号
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public moSymbol GetSymbol(Int32 index)
        {
            return _Symbols[index];
        }

        /// <summary>
        /// 设置指定索引号的符号
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetSymbol(Int32 index, moSymbol symbol)
        {
            _Symbols[index] = symbol;
        }

        /// <summary>
        /// 增加一个分割值及对应的符号
        /// </summary>
        /// <param name="value"></param>
        /// <param name="symbol"></param>
        public void AddBreakValue(double value, moSymbol symbol)
        {
            _BreakValues.Add(value);
            _Symbols.Add(symbol);
        }

        /// <summary>
        /// 增加分割值数组以及对应的符号数组
        /// </summary>
        /// <param name="values"></param>
        /// <param name="symbols"></param>
        public void AddBreakValues(double[] values, moSymbol[] symbols)
        {
            if (values.Length != symbols.Length)
            {
                throw new Exception("the length of the two arrays is not equal!");
            }
            _BreakValues.AddRange(values);
            _Symbols.AddRange(symbols);
        }

        /// <summary>
        /// 根据指定值获取对应的符号
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public moSymbol FindSymbol(double value)
        {
            Int32 sBreakCount = _BreakValues.Count;
            if (sBreakCount == 0)
                return _DefaultSymbol;
            if (value < _BreakValues[0])    //小于第一个分割值
            {
                return _Symbols[0];
            }
            else
            {
                for (Int32 i = 0; i <= sBreakCount - 2; i++)
                {
                    if (i < sBreakCount - 2 && value >= _BreakValues[i] && value < _BreakValues[i + 1])
                        return _Symbols[i + 1];
                    else if (i == sBreakCount - 2 && value >= _BreakValues[i] && value <= _BreakValues[i + 1])
                        return _Symbols[i + 1];
                }
            }
            return _DefaultSymbol;
        }

        /// <summary>
        /// 为所有符号生成渐变色
        /// </summary>
        /// <param name="startColor"></param>
        /// <param name="endColor"></param>
        public void RampColor(Color startColor, Color endColor)
        {
            Int32 sBreakCount = _BreakValues.Count;
            if (sBreakCount <= 0)
                return;
            Int32 A1 = startColor.A, R1 = startColor.R, G1 = startColor.G, B1 = startColor.B;
            Int32 A2 = endColor.A, R2 = endColor.R, G2 = endColor.G, B2 = endColor.B;
            Int32 A, R, G, B;
            double H, S, V;
            Color[] sColors = new Color[sBreakCount];
            if (sBreakCount == 1)
                sColors[0] = startColor;
            else
            {
                //将起始和终止颜色转换为HSV
                double[] sStartHSV = RGBToHSV(startColor.R, startColor.G, startColor.B);
                double[] sEndHSV = RGBToHSV(endColor.R, endColor.G, endColor.B);
                sColors[0] = startColor;
                sColors[sBreakCount - 1] = endColor;
                for (Int32 i = 1; i <= sBreakCount - 2; i++)
                {
                    H = sStartHSV[0] + i * (sEndHSV[0] - sStartHSV[0]) / sBreakCount;
                    S = sStartHSV[1] + i * (sEndHSV[1] - sStartHSV[1]) / sBreakCount;
                    V = sStartHSV[2] + i * (sEndHSV[2] - sStartHSV[2]) / sBreakCount;
                    byte[] sRGB = HSVToRGB(H, S, V);
                    A = A1 + i * (A2 - A1) / sBreakCount;
                    R = sRGB[0];
                    G = sRGB[1];
                    B = sRGB[2];
                    sColors[i] = Color.FromArgb(A, R, G, B);
                }
            }
            for (Int32 i = 0; i <= sBreakCount - 1; i++)
            {
                if (_Symbols[i] != null)
                {
                    if (_Symbols[i].SymbolType == moSymbolTypeConstant.SimpleMarkerSymbol)
                    {
                        moSimpleMarkerSymbol sSymbol = (moSimpleMarkerSymbol)_Symbols[i];
                        sSymbol.Color = sColors[i];
                    }
                    else if (_Symbols[i].SymbolType == moSymbolTypeConstant.SimpleLineSymbol)
                    {
                        moSimpleLineSymbol sSymbol = (moSimpleLineSymbol)_Symbols[i];
                        sSymbol.Color = sColors[i];
                    }
                    else if (_Symbols[i].SymbolType == moSymbolTypeConstant.SimpleFillSymbol)
                    {
                        moSimpleFillSymbol sSymbol = (moSimpleFillSymbol)_Symbols[i];
                        sSymbol.Color = sColors[i];
                    }
                }
            }

        }

        /// <summary>
        /// 为所有符号生成渐变大小
        /// </summary>
        /// <param name="startSize"></param>
        /// <param name="endSize"></param>
        public void RampSize(double startSize, double endSize)
        {
            Int32 sBreakCount = _BreakValues.Count;
            if (sBreakCount <= 0)
                return;
            double[] sSizes = new double[sBreakCount];
            if (sBreakCount == 1)
            {
                sSizes[0] = startSize;
            }
            else
            {
                sSizes[0] = startSize;
                sSizes[sBreakCount - 1] = endSize;
                double sSizeStep = (endSize - startSize) / (sBreakCount - 1);
                for (Int32 i = 1; i <= sBreakCount - 2; i++)
                {
                    sSizes[i] = sSizes[i - 1] + sSizeStep;
                }
            }
            for (Int32 i = 0; i <= sBreakCount - 1; i++)
            {
                if (_Symbols[i] != null)
                {
                    if (_Symbols[i].SymbolType == moSymbolTypeConstant.SimpleMarkerSymbol)
                    {
                        moSimpleMarkerSymbol sSymbol = (moSimpleMarkerSymbol)_Symbols[i];
                        sSymbol.Size = sSizes[i];
                    }
                    else if (_Symbols[i].SymbolType == moSymbolTypeConstant.SimpleLineSymbol)
                    {
                        moSimpleLineSymbol sSymbol = (moSimpleLineSymbol)_Symbols[i];
                        sSymbol.Size = sSizes[i];
                    }
                }
            }
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public override moRenderer Clone()
        {
            moClassBreaksRenderer sRenderer = new moClassBreaksRenderer();
            sRenderer._Field = _Field;
            sRenderer._HeadTitle = _HeadTitle;
            sRenderer._ShowHead = _ShowHead;

            Int32 sBreakCount = _BreakValues.Count;
            for (Int32 i = 0; i <= sBreakCount - 1; i++)
            {
                double sBreakValue = _BreakValues[i];
                moSymbol sSymbol = null;
                if (_Symbols[i] != null)
                    sSymbol = _Symbols[i].Clone();
                //sRenderer.AddUniqueValue(sValue, sSymbol);
            }
            if (_DefaultSymbol != null)
            {
                sRenderer.DefaultSymbol = _DefaultSymbol.Clone();
            }
            sRenderer._ShowDefaultSymbol = _ShowDefaultSymbol;
            return sRenderer;
        }
        #endregion

        #region 私有函数

        private double[] RGBToHSV(double R, double G, double B)
        {
            byte[] sRGB = new byte[3];
            sRGB[0] = (byte)R; sRGB[1] = (byte)G; sRGB[2] = (byte)B;
            double H, S, V;
            byte sMax = sRGB.Max();
            byte sMin = sRGB.Min();
            V = (double)sMax;
            if (sMax != sMin)
            {
                S = (sMax - sMin) / sMax;
                if (R == sMax)
                    H = (G - B) / (sMax - sMin) * 60;
                else if (G == sMax)
                    H = 120 + (B - R) / (sMax - sMin) * 60;
                else
                    H = 240 + (R - G) / (sMax - sMin) * 60;
                if (H < 0)
                    H = H + 360;
            }
            else
            {
                S = 0;
                H = -1;
            }
            double[] sHSV = new double[3];
            sHSV[0] = H;
            sHSV[1] = S;
            sHSV[2] = V;
            return sHSV;
        }

        //将HSV转换为RGB
        private byte[] HSVToRGB(double H, double S, double V)
        {
            byte[] sRGB = new byte[3];
            byte R, G, B;
            if (S == 0)
            {
                R = (byte)V; G = (byte)V; B = (byte)V;
            }
            else
            {
                H = H / 60;
                Int32 i = (Int32)H;
                double f = H - i;
                double aa = V * (1 - S);
                double bb = V * (1 - S * f);
                double cc = V * (1 - S * (1 - f));
                switch (i)
                {
                    case 0:
                        R = (byte)V;
                        G = (byte)cc;
                        B = (byte)aa;
                        break;
                    case 1:
                        R = (byte)bb;
                        G = (byte)V;
                        B = (byte)aa;
                        break;
                    case 2:
                        R = (byte)aa;
                        G = (byte)V;
                        B = (byte)cc;
                        break;
                    case 3:
                        R = (byte)aa;
                        G = (byte)bb;
                        B = (byte)V;
                        break;
                    case 4:
                        R = (byte)cc;
                        G = (byte)aa;
                        B = (byte)V;
                        break;
                    case 5:
                        R = (byte)V;
                        G = (byte)aa;
                        B = (byte)bb;
                        break;
                    default:
                        R = 0; G = 0; B = 0;
                        break;
                }
            }
            sRGB[0] = R;
            sRGB[1] = G;
            sRGB[2] = B;
            return sRGB;
        }
        #endregion
    }
}
