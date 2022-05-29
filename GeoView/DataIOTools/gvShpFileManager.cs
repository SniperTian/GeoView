using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GeoView.DataIOTools
{
    //要求1：moEnum-moGeometryTypeConstant新增MultiPoint = 3
    //要求2：moPoints:moGeometry
    //上述要求在shpFileReader中已经提及
    public class gvShpFileManager
    {
        #region 字段

        private Int32 _FileCode;    //文件码
        private Int32 _Version; //版本号
        private MyMapObjects.moGeometryTypeConstant _GeometryType;  //几何类型常数
        private Int32 _FeatureCount;    //要素数目
        private List<MyMapObjects.moGeometry> _Geometries = new List<MyMapObjects.moGeometry>();    //要素列表

        #endregion

        #region 构造函数

        public gvShpFileManager(string filePath)
        {
            FileStream sStream = new FileStream(filePath, FileMode.Open);
            BinaryReader sr = new BinaryReader(sStream);
            ReadHeader(sr);
            ReadGeometries(sr);
            sr.Dispose();
            sStream.Dispose();
        }

        public gvShpFileManager(MyMapObjects.moGeometryTypeConstant GeometryType)
        {
            _FileCode = 9995;
            _Version = 1000;
            _GeometryType = GeometryType;
            _FeatureCount = 0;
        }

        #endregion

        #region 属性
        #endregion

        #region 方法

        /// <summary>
        /// 更新要素列表(要素类型应与初始几何类型保持一致,但未提供检查机制)
        /// </summary>
        /// <param name="Geometries"></param>
        public void UpdateGeometries(List<MyMapObjects.moGeometry> Geometries)
        {
            _FeatureCount = Geometries.Count;
            _Geometries = Geometries;
        }
        
        /// <summary>
        /// 在制定路径创建要素信息文件
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveToFile(string filePath)
        {
            FileStream sStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryWriter sw = new BinaryWriter(sStream);
            RecordHeader(sw);
            RecordGeometries(sw);
            sw.Close();
            sStream.Close();
        }

        #endregion

        #region 私有函数

        //读取文件头
        private void ReadHeader(BinaryReader sr)
        {
            _FileCode = sr.ReadInt32();
            if (_FileCode != 9995)
            {
                string msg = "Invalid gvShpFileCode!";
                throw new NotSupportedException(msg);
            }
            _Version = sr.ReadInt32();
            _GeometryType = (MyMapObjects.moGeometryTypeConstant)sr.ReadInt32();
            _FeatureCount = sr.ReadInt32();
        }

        //读取要素内容
        private void ReadGeometries(BinaryReader sr)
        {
            if (_GeometryType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                ReadPoint(sr);
            }
            else if (_GeometryType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                ReadMultiPolyline(sr);
            }
            else if (_GeometryType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
            {
                ReadMultiPolygon(sr);
            }
            else if (_GeometryType == MyMapObjects.moGeometryTypeConstant.MultiPoint)
            {
                ReadMultiPoint(sr);
            }
        }

        //读取Point数据
        private void ReadPoint(BinaryReader sr)
        {
            for(Int32 i = 0; i < _FeatureCount; ++i)
            {
                Int32 sPartCount = sr.ReadInt32(); //对于Point而言,部件数为默认为1
                Int32 sPointCount = sr.ReadInt32(); //对于Point而言,每一部件的点数默认为1
                double sX = sr.ReadDouble();
                double sY = sr.ReadDouble();
                MyMapObjects.moPoint sPoint = new MyMapObjects.moPoint(sX, sY);
                _Geometries.Add(sPoint);
            }
        }

        //读取MultiPolyline数据
        private void ReadMultiPolyline(BinaryReader sr)
        {
            for(Int32 i = 0; i < _FeatureCount; ++i)
            {
                Int32 sPartCount = sr.ReadInt32();
                MyMapObjects.moMultiPolyline sMultiPolyline = new MyMapObjects.moMultiPolyline();
                for(Int32 j = 0; j < sPartCount; ++j)
                {
                    Int32 sPointCount = sr.ReadInt32();
                    MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
                    for(Int32 k = 0; k < sPointCount; ++k)
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
        }

        //读取MultiPolygon数据
        private void ReadMultiPolygon(BinaryReader sr)
        {
            for(Int32 i = 0; i < _FeatureCount; ++i)
            {
                Int32 sPartCount = sr.ReadInt32();
                MyMapObjects.moMultiPolygon sMultiPolygon = new MyMapObjects.moMultiPolygon();
                for(Int32 j = 0; j < sPartCount; ++j)
                {
                    Int32 sPointCount = sr.ReadInt32();
                    MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
                    for(Int32 k = 0; k < sPointCount; ++k)
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
        }

        //读取MultiPoint数据
        private void ReadMultiPoint(BinaryReader sr)
        {
            for(Int32 i = 0; i < _FeatureCount; ++i)
            {
                Int32 sPartCount = sr.ReadInt32();  //对于MultiPoint而言，部件数默认为1
                Int32 sPointCount = sr.ReadInt32();
                MyMapObjects.moPoints sPoints = new MyMapObjects.moPoints();
                for(Int32 k = 0; k < sPointCount; ++k)
                {
                    double sX = sr.ReadDouble();
                    double sY = sr.ReadDouble();
                    MyMapObjects.moPoint sPoint = new MyMapObjects.moPoint(sX, sY);
                    sPoints.Add(sPoint);
                }
                sPoints.UpdateExtent();
                _Geometries.Add(sPoints);
            }
        }

        //记录文件头
        private void RecordHeader(BinaryWriter sw)
        {
            sw.Write(_FileCode);
            sw.Write(_Version);
            sw.Write((int)_GeometryType);
            sw.Write(_FeatureCount);
        }

        //记录要素内容
        private void RecordGeometries(BinaryWriter sw)
        {
            if (_GeometryType == MyMapObjects.moGeometryTypeConstant.Point)
            {
                RecordPoint(sw);
            }
            else if (_GeometryType == MyMapObjects.moGeometryTypeConstant.MultiPolyline)
            {
                RecordMultiPolyline(sw);
            }
            else if (_GeometryType == MyMapObjects.moGeometryTypeConstant.MultiPolygon)
            {
                RecordMultiPolygon(sw);
            }
            else if (_GeometryType == MyMapObjects.moGeometryTypeConstant.MultiPoint)
            {
                RecordMultiPoint(sw);
            }
        }

        //记录Point数据
        private void RecordPoint(BinaryWriter sw)
        {
            for(Int32 i = 0; i < _FeatureCount; ++i)
            {
                sw.Write(1);
                sw.Write(1);
                MyMapObjects.moPoint sPoint = (MyMapObjects.moPoint)_Geometries[i];
                sw.Write(sPoint.X);
                sw.Write(sPoint.Y);
            }
        }

        //记录MultiPolyline数据
        private void RecordMultiPolyline(BinaryWriter sw)
        {
            for(Int32 i = 0; i < _FeatureCount; ++i)
            {
                MyMapObjects.moMultiPolyline sMultiPolyline = (MyMapObjects.moMultiPolyline)_Geometries[i];
                sw.Write(sMultiPolyline.Parts.Count);
                for (int j = 0; j < sMultiPolyline.Parts.Count; ++j)
                {
                    MyMapObjects.moPoints sPoints = sMultiPolyline.Parts.GetItem(j);
                    sw.Write(sPoints.Count);
                    for(int k = 0; k < sPoints.Count; ++k)
                    {
                        sw.Write(sPoints.GetItem(k).X);
                        sw.Write(sPoints.GetItem(k).Y);
                    }
                }
            }
        }

        //记录MultiPolygon数据
        private void RecordMultiPolygon(BinaryWriter sw)
        {
            for(Int32 i = 0; i < _FeatureCount; ++i)
            {
                MyMapObjects.moMultiPolygon sMultiPolygon = (MyMapObjects.moMultiPolygon)_Geometries[i];
                sw.Write(sMultiPolygon.Parts.Count);
                for(int j = 0; j < sMultiPolygon.Parts.Count; ++j)
                {
                    MyMapObjects.moPoints sPoints = sMultiPolygon.Parts.GetItem(j);
                    sw.Write(sPoints.Count);
                    for(int k = 0; k < sPoints.Count; ++k)
                    {
                        sw.Write(sPoints.GetItem(k).X);
                        sw.Write(sPoints.GetItem(k).Y);
                    }
                }
            }
        }

        //记录MultiPoint数据
        private void RecordMultiPoint(BinaryWriter sw)
        {
            for(Int32 i = 0; i < _FeatureCount; ++i)
            {
                MyMapObjects.moPoints sPoints = (MyMapObjects.moPoints)_Geometries[i];
                sw.Write(1);
                sw.Write(sPoints.Count);
                for(Int32 j = 0; j < sPoints.Count; ++j)
                {
                    sw.Write(sPoints.GetItem(j).X);
                    sw.Write(sPoints.GetItem(j).Y);
                }
            }
        }

        #endregion
    }
}
