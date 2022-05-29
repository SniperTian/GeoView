using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace MyMapObjectsDemo.DataIOTools
{
    //暂且支持wkt格式,还没有写系统自定义的投影类型
    //暂不具备报错机制(如果文件格式不符合wkt)
    public class gvProjFileManager
    {
        #region 字段

        private MyMapObjects.moProjectionCS _ProjectionCS;

        #endregion

        #region 构造函数

        public gvProjFileManager(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string wktStr = sr.ReadLine();
            AnalyzeWktStr(wktStr);
            sr.Close();
        }

        #endregion

        #region 属性
        #endregion

        #region 方法
        #endregion

        #region 私有函数

        //解析wkt内容
        //说明1：本初子午线--PRIMEM["Greenwich",0]已内置，没有解析
        //说明2：第一个--UNIT["Degree",0.017453292519943295]],也没有解析
        private void AnalyzeWktStr(string wktStr)
        {
            string sProjCSName = GetContentInSemiColon(new Regex(@"PROJCS\[.*?,").Match(wktStr).Value);
            string sGeoCSName = GetContentInSemiColon(new Regex(@"GEOGCS\[.*?,").Match(wktStr).Value);
            string sDatumName = GetContentInSemiColon(new Regex(@"DATUM\[.*?,").Match(wktStr).Value);
            string sSpheroidName = GetContentInSemiColon(new Regex(@"SPHEROID\[.*?,").Match(wktStr).Value);
            //以下的sProjection还需转换为moProjectionTypeConstant
            string sProjection = GetContentInSemiColon(new Regex(@"PROJECTION\[.*?,").Match(wktStr).Value);
            string[] sStrArr = new Regex(@"SPHEROID\[.*?\],").Match(wktStr).Value.Split(',');
            //以下常数中，若wkt无对应内容，则默认为0.
            double sSemiMajor = GetDoubleContent(sStrArr[1]);
            double sInverseFlattening = GetDoubleContent(sStrArr[2]);
            double sOriginLatitude = GetDoubleContent(new Regex(@"PARAMETER\[""Latitude_Of_Origin"".*?\],").Match(wktStr).Value);
            double sCentralMeridian = GetDoubleContent(new Regex(@"PARAMETER\[""Central_Meridian"".*?\],").Match(wktStr).Value);
            double sFalseEasting = GetDoubleContent(new Regex(@"PARAMETER\[""False_Easting"".*?\],").Match(wktStr).Value);
            double sFalseNorthing = GetDoubleContent(new Regex(@"PARAMETER\[""False_Northing"".*?\],").Match(wktStr).Value);
            double sScaleFactor = GetDoubleContent(new Regex(@"PARAMETER\[""Scale_Factor"".*?\],").Match(wktStr).Value);
            //将Standard_Parallel_1替换为空是为了避免数字1的干扰
            double sStandardParallelOne = GetDoubleContent(new Regex(@"PARAMETER\[""Standard_Parallel_1"".*?\],").Match(wktStr).Value.Replace("Standard_Parallel_1", ""));
            double sStandardParallelTwo = GetDoubleContent(new Regex(@"PARAMETER\[""Standard_Parallel_2"".*?\],").Match(wktStr).Value.Replace("Standard_Parallel_2", ""));
            //以下的sLinearUnitName还需转换为moLinearUnitConstant
            string sLinearUnitName = GetContentInSemiColon(new Regex(@"UNIT\[.*?,").Matches(wktStr)[1].Value);
            //未完待续...
            //还需将这些参数写入_ProjectionCS
            int a = 0;
        }

        //提取出双引号""之间的内容
        private string GetContentInSemiColon(string oriStr)
        {
            string sTemp = new Regex(@""".*?""").Match(oriStr).Value;
            return sTemp.Replace("\"", "");
        }

        //提取字符串中double数字,注意：字符串中只能有一个数字
        //若为空，则返回0
        private double GetDoubleContent(string oriStr)
        {
            string sTemp = new Regex(@"(\d|\.|-)+").Match(oriStr).Value;
            if (sTemp == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(sTemp);
            }
        }
        #endregion
    }
}
