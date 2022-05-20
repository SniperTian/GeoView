using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMapObjects
{
    /// <summary>
    /// 简单渲染
    /// </summary>
    public class moSimpleRenderer:moRenderer
    {
        #region 字段

        private moSymbol _Symbol;

        #endregion

        #region 构造函数

        public moSimpleRenderer()
        { }

        #endregion

        #region 属性

        public override moRendererTypeConstant RendererType
        {
            get { return moRendererTypeConstant.Simple; }
        }

        public moSymbol Symbol
        {
            get { return _Symbol; }
            set { _Symbol = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override moRenderer Clone()
        {
            moSimpleRenderer sRenderer = new moSimpleRenderer();
            sRenderer.Symbol = _Symbol.Clone();
            return sRenderer;
        }

        #endregion
    }
}
