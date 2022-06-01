using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMapObjects
{
    public class moLayers
    {
        #region 字段

        private List<moMapLayer> _Layers = new List<moMapLayer>();

        #endregion

        #region 构造函数

        public moLayers()
        { }

        #endregion

        #region 属性

        /// <summary>
        /// 获取图层数量
        /// </summary>
        public Int32 Count
        {
            get { return _Layers.Count; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取指定索引号的图层
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public moMapLayer GetItem(Int32 index)
        {
            return _Layers[index];
        }

        /// <summary>
        /// 在图层序列末尾增加一个图层
        /// </summary>
        /// <param name="mapLayer"></param>
        public void Add(moMapLayer mapLayer)
        {
            _Layers.Add(mapLayer);
        }

        public void Insert(Int32 index, moMapLayer mapLayer)
        {
            _Layers.Insert(index, mapLayer);
        }

        /// <summary>
        /// 移除指定图层
        /// </summary>
        /// <param name="mapLayer"></param>
        public void Remove(moMapLayer mapLayer)
        {
            _Layers.Remove(mapLayer);
        }

        /// <summary>
        /// 移除指定索引号的图层
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(Int32 index)
        {
            _Layers.RemoveAt(index);
        }

        /// <summary>
        /// 清除所有图层
        /// </summary>
        public void Clear()
        {
            _Layers.Clear();
        }

        /// <summary>
        /// 将指定索引的图层移动到另一指定索引
        /// </summary>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        public void MoveTo(Int32 fromIndex, Int32 toIndex)
        {
            if (fromIndex == toIndex)
                return;
            else
            {
                moMapLayer sLayer = _Layers[fromIndex];
                _Layers.RemoveAt(fromIndex);
                _Layers.Insert(toIndex, sLayer);
            }
        }

        #endregion
    }
}
