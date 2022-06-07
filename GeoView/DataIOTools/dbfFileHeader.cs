using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GeoView.DataIOTools
{
    //备注：注意检查记录数与要素数是否相等
    public class dbfFileHeader
    {
        #region 字段

        private byte _FileType; //文件类型
        private byte[] _LastModifyDate; //最后一次修改日期
        private UInt32 _RecordNum;  //记录数，即表格的行数
        private UInt16 _HeaderLength;   //文件头中的字节数，在此之后的字节为表格记录数据
        private UInt16 _RecordLength;   //一条记录中的字节长度，即每行数据所占的长度
        private UInt16 _Reserved;   //保留字节
        private byte _IncompleteTransaction;    //未完成的操作
        private byte _PwdFlag;  //dBASE IV编密码标记
        private byte[] _ReservedForMultiUser;   //保留字节，用于多用户处理时使用
        private byte _TableFlags;   //dbf文件的MDX标识
        private byte _LanguageDriver;   //页码标记
        private UInt16 _Reserved2;  //保留字节，用于以后添加新的说明性信息时使用
        private List<dbfField> _dbfFields = new List<dbfField>();   //dbf字段列表

        #endregion

        #region 构造函数

        public dbfFileHeader(BinaryReader sr)
        {
            _FileType = sr.ReadByte();
            if (new byte[] { 0x02, 0x03, 0x30, 0x43, 0x63, 0x83, 0x8b, 0xcb, 0xf5, 0xfb }.Contains(_FileType))
            {
                _LastModifyDate = sr.ReadBytes(3);
                _RecordNum = sr.ReadUInt32();
                _HeaderLength = sr.ReadUInt16();
                _RecordLength = sr.ReadUInt16();
                _Reserved = sr.ReadUInt16();
                _IncompleteTransaction = sr.ReadByte();
                _PwdFlag = sr.ReadByte();
                _ReservedForMultiUser = sr.ReadBytes(12);
                _TableFlags = sr.ReadByte();
                _LanguageDriver = sr.ReadByte();
                _Reserved2 = sr.ReadUInt16();
                while (sr.PeekChar() != 0x0D)
                {
                    dbfField sdbfField = new dbfField();
                    sdbfField.FieldName = Encoding.UTF8.GetString(sr.ReadBytes(11), 0, 11).Replace("\0", "").ToLower();
                    sdbfField.FieldType = sr.ReadByte();
                    sdbfField.ReservedField1 = sr.ReadUInt32();
                    sdbfField.FieldLength = sr.ReadByte();
                    sdbfField.FieldPrecision = sr.ReadByte();
                    sdbfField.FieldFlags = sr.ReadByte();
                    _dbfFields.Add(sdbfField);
                    sr.ReadBytes(13);   //该字段部分后面的内容不再记录
                }
            }
            else
            {
                string msg = "Invalid dbfFileCode!";
                throw new NotSupportedException(msg);
            }
        }

        public dbfFileHeader()
        {
            _FileType = 0x02;
            _RecordNum = 0;
            _HeaderLength = 33;
            _RecordLength = 0;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取文件类型
        /// </summary>
        public byte FileType
        {
            get { return _FileType; }
        }

        /// <summary>
        /// 获取最后一次编辑日期
        /// </summary>
        public byte[] LastModifyDate
        {
            get { return _LastModifyDate; }
        }

        /// <summary>
        /// 获取或设置记录数
        /// </summary>
        public UInt32 RecordNum
        {
            set { _RecordNum = value; }
            get { return _RecordNum; }
        }

        /// <summary>
        /// 获取或设置文件头的字节长度
        /// </summary>
        public UInt16 HeaderLength
        {
            set { _HeaderLength = value; }
            get { return _HeaderLength; }
        }

        /// <summary>
        /// 获取或设置一条记录中的字节长度
        /// </summary>
        public UInt16 RecordLength
        {
            set { _RecordLength = value; }
            get { return _RecordLength; }
        }

        public UInt16 Reserved
        {
            get { return _Reserved; }
        }

        public byte IncompleteTransaction
        {
            get { return _IncompleteTransaction; }
        }

        public byte PwdFlag
        {
            get { return _PwdFlag; }
        }

        public byte[] ReservedForMultiUser
        {
            get { return _ReservedForMultiUser; }
        }

        public byte TableFlags
        {
            get { return _TableFlags; }
        }

        public byte LanguageDriver
        {
            get { return _LanguageDriver; }
        }

        public UInt16 Reserved2
        {
            get { return _Reserved2; }
        }

        /// <summary>
        /// 获取字段列表
        /// </summary>
        public List<dbfField> dbfFields
        {
            get { return _dbfFields; }
        }

        #endregion
    }
}
