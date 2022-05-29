using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GeoView.DataIOTools
{
    //要求1：moEnum-moGeometryTypeConstant新增MultiPoint = 3
    //要求2：moPoints:moGeometry
    public class shpFileReader
    {
        #region 字段

        private shpFileHeader _shpFileHeader;
        private shxFile _shxFile;
        private MyMapObjects.moGeometryTypeConstant _ShapeType;
        private List<MyMapObjects.moGeometry> _Geometries = new List<MyMapObjects.moGeometry>();

        #endregion

        #region 构造函数

        public shpFileReader(string filePath) //filePath要求是.shp的文件路径
        {
            string shpFilePath = filePath;
            string shxFilePath;
            FileStream sStream; //用于读取shp文件
            FileStream bStream; //用于读取shx文件
            BinaryReader sr;    //用于读取shp文件
            BinaryReader br;    //用于读取shx文件
            try
            {
                shxFilePath = shpFilePath.Substring(0, shpFilePath.IndexOf(".shp")) + ".shx";
                sStream = new FileStream(shpFilePath, FileMode.Open);
                bStream = new FileStream(shxFilePath, FileMode.Open);
                sr = new BinaryReader(sStream);
                br = new BinaryReader(bStream);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //读取索引文件
            _shxFile = new shxFile(br);
            //读取文件头
            _shpFileHeader = new shpFileHeader(sr);
            GetShapeType();
            //读取内容
            for(int i = 0; i < _shxFile.RecordNum; ++i)
            {
                sr.BaseStream.Seek(_shxFile.Offset[i], SeekOrigin.Begin);
                ReadEachRecordOfShapeFile(sr);
            }
            sr.Dispose();
            br.Dispose();
            sStream.Dispose();
            bStream.Dispose();
        }

        #endregion

        #region 属性

        //获取要素数目
        public Int32 Count
        {
            get { return _Geometries.Count; }
        }

        //获取要素类型
        public MyMapObjects.moGeometryTypeConstant ShapeType
        {
            get { return _ShapeType; }
        }

        //获取要素
        public List<MyMapObjects.moGeometry> Geometries
        {
            get { return _Geometries; }
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

        private void GetShapeType()
        {
            switch((int)_shpFileHeader.ShapeType)
            {
                case (int)ShapeTypeConstant.NullShape:
                    _ShapeType = MyMapObjects.moGeometryTypeConstant.Point;
                    break;
                case (int)ShapeTypeConstant.Point:
                    _ShapeType = MyMapObjects.moGeometryTypeConstant.Point;
                    break;
                case (int)ShapeTypeConstant.PolyLine:
                    _ShapeType = MyMapObjects.moGeometryTypeConstant.MultiPolyline;
                    break;
                case (int)ShapeTypeConstant.Polygon:
                    _ShapeType = MyMapObjects.moGeometryTypeConstant.MultiPolygon;
                    break;
                case (int)ShapeTypeConstant.MultiPoint:
                    _ShapeType = MyMapObjects.moGeometryTypeConstant.MultiPoint;
                    break;
                default:
                    {
                        string msg = "不支持该Shape类型数据";
                        throw new NotSupportedException(msg);
                    }
            }
        }

        private void ReadEachRecordOfShapeFile(BinaryReader sr)
        {
            //Record Header
            Int32 sRecordNumber = ReadInt32_BE(sr);
            Int32 sContentLength = ReadInt32_BE(sr);
            //ShapeType
            Int32 sShapeType = sr.ReadInt32();
            //根据ShapeType读取对应的数据类型
            switch ((int)sShapeType)
            {
                case (int)ShapeTypeConstant.NullShape:
                    break;
                case (int)ShapeTypeConstant.Point:
                    ReadShpPoint(sr);
                    break;
                case (int)ShapeTypeConstant.PolyLine:
                    ReadShpPolyLine(sr);
                    break;
                case (int)ShapeTypeConstant.Polygon:
                    ReadShpPolygon(sr);
                    break;
                case (int)ShapeTypeConstant.MultiPoint:
                    ReadShpMultiPoint(sr);
                    break;
                default:
                    {
                        string msg = "不支持该Shape类型数据";
                        throw new NotSupportedException(msg);
                    }
            }
        }

        //读取Point
        private void ReadShpPoint(BinaryReader sr)
        {
            double sX = sr.ReadDouble();
            double sY = sr.ReadDouble();
            MyMapObjects.moPoint sPoint = new MyMapObjects.moPoint(sX, sY);
            _Geometries.Add(sPoint);
        }

        //读取PolyLine
        private void ReadShpPolyLine(BinaryReader sr)
        {
            //读取边界盒参数
            sr.ReadDouble();
            sr.ReadDouble();
            sr.ReadDouble();
            sr.ReadDouble();
            //读取NumParts和NumPoints
            Int32 sNumParts = sr.ReadInt32();
            Int32 sNumPoints = sr.ReadInt32();
            //读取每一部分的点在数组中的起始位置
            Int32[] sEachPartIndex = new Int32[sNumParts + 1];
            for (Int32 i = 0; i < sNumParts; ++i)
            {
                sEachPartIndex[i] = sr.ReadInt32();
            }
            sEachPartIndex[sNumParts] = sNumPoints;
            //构建MultiPolyline
            MyMapObjects.moMultiPolyline sMultiPolyline = new MyMapObjects.moMultiPolyline();
            for(Int32 i = 0; i < sNumParts; ++i)
            {
                MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
                for(Int32 j = 0; j < sEachPartIndex[i + 1] - sEachPartIndex[i]; ++j)
                {
                    double sX = sr.ReadDouble();
                    double sY = sr.ReadDouble();
                    MyMapObjects.moPoint sPoint = new MyMapObjects.moPoint(sX, sY);
                    sPoints.Add(sPoint);
                }
                sMultiPolyline.Parts.Add(sPoints);
            }
            sMultiPolyline.UpdateExtent();
            _Geometries.Add(sMultiPolyline);
        }

        //读取Polygon
        private void ReadShpPolygon(BinaryReader sr)
        {
            //读取边界盒参数
            sr.ReadDouble();
            sr.ReadDouble();
            sr.ReadDouble();
            sr.ReadDouble();
            //读取NumParts和NumPoints
            Int32 sNumParts = sr.ReadInt32();
            Int32 sNumPoints = sr.ReadInt32();
            //读取每一部分的点在数组中的起始位置
            Int32[] sEachPartIndex = new Int32[sNumParts + 1];
            for (Int32 i = 0; i < sNumParts; ++i)
            {
                sEachPartIndex[i] = sr.ReadInt32();
            }
            sEachPartIndex[sNumParts] = sNumPoints;
            //构建MultiPolygon
            MyMapObjects.moMultiPolygon sMultiPolygon = new MyMapObjects.moMultiPolygon();
            for(int i = 0; i < sNumParts; ++i)
            {
                MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
                for (Int32 j = 0; j < sEachPartIndex[i + 1] - sEachPartIndex[i]; ++j)
                {
                    double sX = sr.ReadDouble();
                    double sY = sr.ReadDouble();
                    MyMapObjects.moPoint sPoint = new MyMapObjects.moPoint(sX, sY);
                    sPoints.Add(sPoint);
                }
                sMultiPolygon.Parts.Add(sPoints);
            }
            sMultiPolygon.UpdateExtent();
            _Geometries.Add(sMultiPolygon);
        }

        //读取MultiPoint
        private void ReadShpMultiPoint(BinaryReader sr)
        {
            //读取边界盒参数
            sr.ReadDouble();
            sr.ReadDouble();
            sr.ReadDouble();
            sr.ReadDouble();
            //读取NumPoints
            Int32 sNumPoints = sr.ReadInt32();
            //构建Points
            MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
            for(Int32 i = 0; i < sNumPoints; ++i)
            {
                double sX = sr.ReadDouble();
                double sY = sr.ReadDouble();
                MyMapObjects.moPoint sPoint = new MyMapObjects.moPoint(sX, sY);
                sPoints.Add(sPoint);
            }
            _Geometries.Add(sPoints);
        }

        #endregion
    }
}
