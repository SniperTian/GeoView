using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoView.DataIOTools
{
    //dbf字段信息
    public class dbfField
    {
        #region 字段

        private string _FieldName;   //字段名称，占11个字节(0-10)
        private byte _FieldType;    //字段的数据类型，为ASCII码值
                                    //Field type: 
                                    //    C   –   Character
                                    //    Y   –   Currency
                                    //    N   –   Numeric
                                    //    F   –   Float
                                    //    D   –   Date
                                    //    T   –   DateTime
                                    //    B   –   Double
                                    //    I   –   Integer
                                    //    L   –   Logical
                                    //    M   – Memo
                                    //    G   – General
                                    //    C   –   Character (binary)
                                    //    M   –   Memo (binary)
                                    //    P   –   Picture
        private UInt32 _ReservedField1; //保留字节，用于以后添加新的说明性信息时使用，默认为0。
        private byte _FieldLength;  //字段长度,表示该字段对应的值在后面的记录中所占的长度
        private byte _FieldPrecision;   //字段精度
        private byte _FieldFlags;   //列属性(与其他说明文档有出入，待考证)
                                    //0x01   System Column (not visible to user), 
                                    //0x02   Column can store null values, 
                                    //0x04   Binary column (for CHAR and MEMO only), 
                                    //0x06   (0x02+0x04) When a field is NULL and binary (Integer, Currency, and Character/Memo fields), 
                                    //0x0C   Column is autoincrementing
                                    //字段区共32个字节，目前记录了第0-18个字节，后面的基本为保留字节，不再读取

        #endregion

        #region 构造函数
        public dbfField()
        {

        }
        #endregion

        #region 属性

        public string FieldName
        {
            set { _FieldName = value; }
            get { return _FieldName; }
        }

        public byte FieldType
        {
            set { _FieldType = value; }
            get{ return _FieldType; }
        }

        public UInt32 ReservedField1
        {
            set { _ReservedField1 = value; }
            get { return _ReservedField1; }
        }

        public byte FieldLength
        {
            set { _FieldLength = value; }
            get { return _FieldLength; }
        }

        public byte FieldPrecision
        {
            set { _FieldPrecision = value; }
            get { return _FieldPrecision; }
        }

        public byte FieldFlags
        {
            set { _FieldFlags = value; }
            get { return _FieldFlags; }
        }

        #endregion
    }
}
