using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GeoView.DataIOTools
{
    public class shpFileHeader
    {
        #region 字段

        //（1）文件相关信息
        private Int32 _FileCode;
        private Int32 _FileLength;
        private Int32 _Version;
        private ShapeTypeConstant _ShapeType;
        //（2）边界盒参数
        private double _MinX;
        private double _MaxX;
        private double _MinY;
        private double _MaxY;
        
        #endregion

        #region 构造函数

        public shpFileHeader(BinaryReader sr)
        {
            //读取文件码
            _FileCode = ReadInt32_BE(sr);
            if (_FileCode != 9994)
            {
                string msg = "Invalid ShapeFileCode!";
                throw new NotSupportedException(msg);
            }
            //5个Unused字节
            ReadInt32_BE(sr);
            ReadInt32_BE(sr);
            ReadInt32_BE(sr);
            ReadInt32_BE(sr);
            ReadInt32_BE(sr);
            //读取文件长度、版本等信息
            _FileLength = ReadInt32_BE(sr);
            _Version = sr.ReadInt32();
            _ShapeType = (ShapeTypeConstant)sr.ReadInt32();
            _MinX = sr.ReadDouble();
            _MinY = sr.ReadDouble();
            _MaxX = sr.ReadDouble();
            _MaxY = sr.ReadDouble();
            //读取边界盒其他参数，本程序不支持使用这些参数
            sr.ReadDouble();
            sr.ReadDouble();
            sr.ReadDouble();
            sr.ReadDouble();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取文件码
        /// </summary>
        public Int32 FileCode
        {
            get { return _FileCode; }
        }

        /// <summary>
        /// 获取shp约定的要素几何类型
        /// </summary>
        public ShapeTypeConstant ShapeType
        {
            get { return _ShapeType; }
        }

        /// <summary>
        /// 获取最小外包矩形的MinX
        /// </summary>
        public double MinX
        {
            get { return _MinX; }
        }

        /// <summary>
        /// 获取最小外包矩形的MaxX
        /// </summary>
        public double MaxX
        {
            get { return _MaxX; }
        }

        /// <summary>
        /// 获取最小外包矩形的MinY
        /// </summary>
        public double MinY
        {
            get { return _MinY; }
        }

        /// <summary>
        /// 获取最小外包矩形的MaxY
        /// </summary>
        public double MaxY
        {
            get { return _MaxY; }
        }

        #endregion

        #region 私有函数

        //读取大端字节序4字节整数
        private Int32 ReadInt32_BE(BinaryReader sr)
        {
            byte[] intBytes = new byte[4];
            for(int i = 3; i >= 0; --i)
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
