using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoView
{
    public partial class Renderer : Form
    {
        #region 字段

        private Int32 renderMode = 0; //渲染方式,0:简单渲染,1:唯一值渲染,2:分级渲染

        //简单渲染参数
        private Int32 render

        private Int32 renderSymbol = 0;
        private Color simpleRenderColor = Color.DarkGoldenrod;
        private Color classBreakRenderColor = Color.DarkGoldenrod;
        private double classBreakRenderStartSize = 2;
        private double classBreakRenderEndSize = 6;

        private Int32 classNum = 5;

        private Int32 uniqueFieldIndex = 0;
        private Int32 classBreakFieldIndex = 5;

        #endregion



        public Renderer()
        {
            InitializeComponent();
        }
    }
}
