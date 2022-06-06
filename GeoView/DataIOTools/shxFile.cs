using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GeoView.DataIOTools
{
    public class shxFile
    {
        #region 字段

        private long _RecordNum;
        private List<Int32> _Offset = new List<Int32>();
        private List<Int32> _ContentLength = new List<Int32>();

        #endregion

        #region 构造函数

        public shxFile(BinaryReader sr)
        {
            sr.BaseStream.Seek(100, SeekOrigin.Begin);  //跳过文件头
            _RecordNum = (sr.BaseStream.Length - 100) / 8;
            while (true)
            {
                try
                {
                    _Offset.Add(ReadInt32_BE(sr) * 2);  //  以byte为单位，故需×2
                    _ContentLength.Add(ReadInt32_BE(sr) * 2);
                }
                catch (IOException)
                {
                    break;  //读到文件尾
                }
            }
        }

        #endregion

        #region 属性
        /// <summary>
        /// 获取记录数
        /// </summary>
        public long RecordNum
        {
            get { return _RecordNum; }
        }

        /// <summary>
        /// 获取要素记录相对于起始位置的偏移量
        /// </summary>
        public List<Int32> Offset
        {
            get { return _Offset; }
        }

        /// <summary>
        /// 获取各要素记录长度
        /// </summary>
        public List<Int32> ContentLength
        {
            get { return _ContentLength; }
        }

        #endregion

        #region 私有函数

        //读取大端字节序4字节整数
        private Int32 ReadInt32_BE(BinaryReader sr)
        {
            byte[] intBytes = new byte[4];
            for (int i = 3; i >= 0; --i)
            {
                int b = sr.ReadByte();
                if (b == -1) throw new EndOfStreamException();
                intBytes[i] = (byte)b;
            }
            return BitConverter.ToInt32(intBytes, 0);
        }

        #endregion
    }
}
