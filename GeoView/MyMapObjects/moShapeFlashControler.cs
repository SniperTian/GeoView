using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMapObjects
{
    //图形闪烁控制器
    internal class moShapeFlashControler
    {
        #region 字段

        private moShape[] mShapes;      //图形集合
        private Int32 mTimes;           //闪烁次数
        private Int32 mInterval;        //闪烁的时间间隔，单位毫秒
        private Int32 mSteps;           //时钟循环总次数=_Times*2
        private Int32 mCurStep;         //时钟循环当前次数
        private Timer mTimer = new Timer();     //时钟，用于时间控制
        private bool mIsInFlash = false;    //是否正处于闪烁控制中。

        #endregion

        #region 构造函数

        internal moShapeFlashControler()
        {
            mTimer.Tick += MTimer_Tick;
            mTimer.Enabled = false;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 开始闪烁
        /// </summary>
        /// <param name="shapes"></param>
        /// <param name="times"></param>
        /// <param name="interval"></param>
        internal void StartFlash(moShape[] shapes, Int32 times, Int32 interval)
        {
            if (shapes.Length == 0)
                return;
            if (times <= 0)
                return;
            if (interval <= 0)
                return;

            //如果正在闪烁，则先停止先前的闪烁控制，并触发重绘事件
            if (mIsInFlash == true)
            {
                mTimer.Stop();
                if (NeedClearFlashShapes != null)
                    NeedClearFlashShapes(this);
            }
            //记录参数
            mShapes = shapes;
            mTimes = times;
            mInterval = interval;
            mTimer.Interval = mInterval / 2;
            //计算或设置其他参数
            mIsInFlash = true;
            mSteps = times * 2;
            mCurStep = 0;
            //时钟开始计数
            mTimer.Start();
        }

        /// <summary>
        /// 停止闪烁
        /// </summary>
        internal void StopFlash()
        {
            if (mIsInFlash == true)
            {
                if (mCurStep % 2 == 1)
                {
                    if (NeedClearFlashShapes != null)
                        NeedClearFlashShapes(this);
                }
                mIsInFlash = false;
                mTimer.Stop();
            }
        }

        #endregion

        #region 时钟事件处理
        private void MTimer_Tick(object sender, EventArgs e)
        {
            //根据当前步数的奇偶性，判断属于什么阶段
            if (mCurStep % 2 == 0)
            {
                //偶数，绘制阶段，触发需要绘制事件
                if (NeedDrawFlashShapes != null)
                    NeedDrawFlashShapes(this, mShapes);
                //步数+1
                mCurStep = mCurStep + 1;
            }
            else
            {
                //奇数，清除阶段，触发需要清除事件
                if (NeedClearFlashShapes != null)
                    NeedClearFlashShapes(this);
                //步数+1
                mCurStep = mCurStep + 1;
            }
            //如果当前次数大于等于总次数，则停止时钟
            if (mCurStep >= mSteps)
            {
                mIsInFlash = false;
                mTimer.Stop();
            }
        }

        #endregion

        #region 事件

        //需要清除正在闪烁的图形
        internal delegate void NeedClearFlashShapesHandle(object sender);
        internal event NeedClearFlashShapesHandle NeedClearFlashShapes;

        //需要绘制正在闪烁的图形
        internal delegate void NeedDrawFlashShapesHandle(object sender, moShape[] shapes);
        internal event NeedDrawFlashShapesHandle NeedDrawFlashShapes;

        #endregion
    }
}
