using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMapObjects
{
    //部件集合对象
    public class moParts
    {
        #region 字段

        private List<moPoints> _Parts;

        #endregion

        #region 构造函数

        public moParts()
        {
            _Parts = new List<moPoints>();
        }

        public moParts(moPoints[] parts)
        {
            _Parts = new List<moPoints>();
            _Parts.AddRange(parts);
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取部件数目
        /// </summary>
        /// <returns></returns>
        public Int32 Count
        {
            get { return _Parts.Count; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引的部件
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public moPoints GetItem(Int32 index)
        {
            return _Parts[index];
        }

        /// <summary>
        /// 设置指定索引位置的部件
        /// </summary>
        /// <param name="index"></param>
        /// <param name="part"></param>
        public void SetItem(Int32 index, moPoints part)
        {
            _Parts[index] = part;
        }

        /// <summary>
        /// 将指定元素添加到末尾
        /// </summary>
        /// <param name="part"></param>
        public void Add(moPoints part)
        {
            _Parts.Add(part);
        }

        /// <summary>
        /// 将指定数组中的元素添加到末尾
        /// </summary>
        /// <param name="parts"></param>
        public void AddRange(moPoints[] parts)
        {
            _Parts.AddRange(parts);
        }

        //其他的增加、插入、删除的接口不再编写，根据需要自行添加

        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public moParts Clone()
        {
            moParts sParts = new moParts();
            Int32 sPartCount = _Parts.Count;
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                moPoints sPart = _Parts[i].Clone();
                sParts.Add(sPart);
            }
            return sParts;
        }

        #endregion
    }
}
