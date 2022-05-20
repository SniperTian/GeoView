using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMapObjects
{
    public static class moMapTools
    {
        #region 基本部分

        internal static double GetDistance(double x1, double y1, double x2, double y2)
        {
            double sDis;
            sDis = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
            sDis = Math.Sqrt(sDis);
            return sDis;
        }

        /// <summary>
        /// 获取指定点到指定线段的最短距离
        /// </summary>
        /// <param name="x0">指定点x坐标</param>
        /// <param name="y0">指定点y坐标</param>
        /// <param name="x1">指定线段起点x坐标</param>
        /// <param name="y1">指定线段起点y坐标</param>
        /// <param name="x2">指定线段终点x坐标</param>
        /// <param name="y2">指定线段终点y坐标</param>
        /// <returns></returns>
        internal static double GetDistanceFromPointToSegment(double x0, double y0, double x1, double y1, double x2, double y2)
        {
            //思路：采用向量內积法
            double pX = x2 - x1, pY = y2 - y1;      //线段两端点坐标之差
            double som = pX * pX + pY * pY;         //坐标之差的平方和,即距离的平方
            if (som == 0)
            {
                //即线段起点和终点重合
                double dX = x1 - x0, dY = y1 - y0;
                double dist = Math.Sqrt(dX * dX + dY * dY);
                return dist;
            }
            else
            {
                double u = ((x0 - x1) * pX + (y0 - y1) * pY) / som;
                if (u > 1)
                    u = 1;
                else if (u < 0)
                    u = 0;
                double x = x1 + u * pX, y = y1 + u * pY;
                double dX = x - x0, dY = y - y0;
                double dist = Math.Sqrt(dX * dX + dY * dY);
                return dist;
            }
        }

        /// <summary>
        /// 指示两个矩形盒是否相交
        /// </summary>
        /// <param name="box1"></param>
        /// <param name="box2"></param>
        internal static bool AreBoxesCross(moRectangle box1, moRectangle box2)
        {
            if (box1.MinX > box2.MaxX || box1.MaxX < box2.MinX)
                return false;
            else if (box1.MinY > box2.MaxY || box1.MaxY < box2.MinY)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 一条水平向右的射线与一条线段是否相交
        /// </summary>
        /// <param name="point"></param>
        /// <param name="sPoint"></param>
        /// <param name="ePoint"></param>
        /// <returns></returns>
        internal static bool IsRayCrossSegment(moPoint point, moPoint sPoint, moPoint ePoint)
        {
            if (sPoint.Y == ePoint.Y)
                //与射线平行
                return false;
            if (sPoint.Y > point.Y && ePoint.Y > point.Y)
                //线段在射线上边
                return false;
            if (sPoint.Y < point.Y && ePoint.Y < point.Y)
                //线段在射线下边
                return false;
            if (sPoint.Y == point.Y && ePoint.Y > point.Y)
                //交点为下端点
                return false;
            if (ePoint.Y == point.Y && sPoint.Y > point.Y)
                //交点为下端点
                return false;
            if (sPoint.X < point.X && ePoint.X < point.X)
                //线段位于起点的左边
                return false;

            double x = ePoint.X - (ePoint.X - sPoint.X) * (ePoint.Y - point.Y) / (ePoint.Y - sPoint.Y);
            if (x < point.X)
                //交点在射线起点的左侧，故视为无交点
                return false;

            return true;
        }

        /// <summary>
        /// 指定的扫描线与指定线段是否相交
        /// </summary>
        /// <param name="scanY"></param>
        /// <param name="sPoint"></param>
        /// <param name="ePoint"></param>
        /// <returns></returns>
        internal static bool IsScanCrossSegment(double scanY, moPoint sPoint, moPoint ePoint)
        {
            if (sPoint.Y == ePoint.Y)
                //与扫描线平行
                return false;
            if (sPoint.Y > scanY && ePoint.Y > scanY)
                //线段在扫描线上边
                return false;
            if (sPoint.Y < scanY && ePoint.Y < scanY)
                //线段在扫描线下边
                return false;
            if (sPoint.Y == scanY && ePoint.Y > scanY)
                //交点为下端点
                return false;
            if (ePoint.Y == scanY && sPoint.Y > scanY)
                //交点为下端点
                return false;

            return true;
        }

        /// <summary>
        /// 求一条水平向右的射线与一个多边形的交点个数
        /// </summary>
        /// <param name="point"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        internal static Int32 GetIntersectionCountBetweenRayAndPolygon(moPoint point, moPoints points)
        {
            Int32 sIntersectionCount = 0;
            Int32 sPointCount = points.Count;
            if (IsRayCrossSegment(point, points.GetItem(sPointCount - 1), points.GetItem(0)) == true)
            {
                //起点与最后一点的连线与射线有交点
                sIntersectionCount = sIntersectionCount + 1;
            }
            //求射线与其他边的交点
            for (Int32 i = 0; i <= sPointCount - 2; i++)
            {
                if (IsRayCrossSegment(point, points.GetItem(i), points.GetItem(i + 1)) == true)
                {
                    sIntersectionCount = sIntersectionCount + 1;
                }
            }
            return sIntersectionCount;
        }

        /// <summary>
        /// 获取指定扫描线与指定多边形的交点的X坐标序列
        /// </summary>
        /// <param name="scanY"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        internal static List<double> GetIntersectionsBetweenScanAndPolygon(double scanY, moPoints points)
        {
            Int32 sPointCount = points.Count;
            List<double> sIntersections = new List<double>(); //交点X坐标序列
            if (IsScanCrossSegment(scanY, points.GetItem(sPointCount - 1), points.GetItem(0)) == true)
            {   //起点与最后一点的连线与扫描线有交点
                double x1 = points.GetItem(sPointCount - 1).X, y1 = points.GetItem(sPointCount - 1).Y;
                double x2 = points.GetItem(0).X, y2 = points.GetItem(0).Y;
                double x = x1 + (x2 - x1) * (scanY - y1) / (y2 - y1);
                sIntersections.Add(x);
            }
            //求扫描线与其他边的交点
            for (Int32 i = 0; i <= sPointCount - 2; i++)
            {
                if (IsScanCrossSegment(scanY, points.GetItem(i), points.GetItem(i + 1)) == true)
                {
                    double x1 = points.GetItem(i).X, y1 = points.GetItem(i).Y;
                    double x2 = points.GetItem(i + 1).X, y2 = points.GetItem(i + 1).Y;
                    double x = x1 + (x2 - x1) * (scanY - y1) / (y2 - y1);
                    sIntersections.Add(x);
                }
            }
            return sIntersections;
        }

        /// <summary>
        /// 指示两条线段是否有交点
        /// </summary>
        /// <param name="sPoint1"></param>
        /// <param name="ePoint1"></param>
        /// <param name="sPoint2"></param>
        /// <param name="ePoint2"></param>
        /// <returns></returns>
        internal static bool AreSegmentsCross(moPoint sPoint1, moPoint ePoint1, moPoint sPoint2, moPoint ePoint2)
        {
            //思路：采用参数方程求解，原理如下
            //线段1参数方程x = sx1 + (ex1 - sx1) * t, y = sy1 + (ey1 - sy1) * t
            //线段2参数方程x = sx2 + (ex2 - sx2) * l, y = sy2 + (ey2 - sy2) * l
            //解参数方程组： (1)sx1 + (ex1 - sx1) * t = sx2 + (ex2 - sx2) * l; (2)sy1 + (ey1 - sy1) * t = sy2 + (ey2 - sy2) * l
            //如果0 <= t <= 1 and 0 <= l <= 1，则有交点
            double sx1 = sPoint1.X, sy1 = sPoint1.Y;        //第一条线段起点
            double ex1 = ePoint1.X, ey1 = ePoint1.Y;        //第一条线段终点
            double sx2 = sPoint2.X, sy2 = sPoint2.Y;        //第二条线段起点
            double ex2 = ePoint2.X, ey2 = ePoint2.Y;        //第二条线段终点
            double deltaX1 = ex1 - sx1, deltaY1 = ey1 - sy1;
            double deltaX2 = ex2 - sx2, deltaY2 = ey2 - sy2;

            //如果两条线段平行则返回False
            if (deltaY2 * deltaX1 - deltaX2 * deltaY1 == 0)
                return false;
            //如果不平行，则求交点
            double t, l;
            t = (deltaX2 * (sy1 - sy2) - deltaY2 * (sx1 - sx2)) / (deltaX1 * deltaY2 - deltaX2 * deltaY1);
            l = (deltaX1 * (sy1 - sy2) - deltaY1 * (sx1 - sx2)) / (deltaX1 * deltaY2 - deltaX2 * deltaY1);
            if (t >= 0 && t <= 1 && l >= 0 && l <= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 指示指定线段是否与指定矩形盒相交
        /// </summary>
        /// <param name="sPoint"></param>
        /// <param name="ePoint"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        internal static bool IsSegmentCrossBox(moPoint sPoint, moPoint ePoint, moRectangle box)
        {
            //先判断线段两个端点是否全部位于矩形盒某条边的外侧，如是，则返回False
            if (sPoint.X < box.MinX && ePoint.X < box.MinX)
                //两个端点位于矩形左边的外侧
                return false;
            if (sPoint.X > box.MaxX && ePoint.X > box.MaxX)
                //两个端点位于矩形右边的外侧
                return false;
            if (sPoint.Y < box.MinY && ePoint.Y < box.MinY)
                //两个端点位于矩形底边的外侧
                return false;
            if (sPoint.Y > box.MaxY && ePoint.Y > box.MaxY)
                //两个端点位于矩形上边的外侧
                return false;
            //定义四个顶点
            moPoint sPoint1 = new moPoint(box.MinX, box.MaxY);           //矩形左上点
            moPoint sPoint2 = new moPoint(box.MaxX, box.MaxY);          //矩形右上点
            moPoint sPoint3 = new moPoint(box.MaxX, box.MinY);          //矩形右下点
            moPoint sPoint4 = new moPoint(box.MinX, box.MinY);          //矩形左下点
            //将每条边与线段求交
            if (AreSegmentsCross(sPoint, ePoint, sPoint1, sPoint2) == true)
                //与上边有交点
                return true;
            if (AreSegmentsCross(sPoint, ePoint, sPoint3, sPoint4) == true)
                //与下边有交点
                return true;
            if (AreSegmentsCross(sPoint, ePoint, sPoint1, sPoint4) == true)
                //与左边有交点
                return true;
            if (AreSegmentsCross(sPoint, ePoint, sPoint2, sPoint3) == true)
                //与右边有交点
                return true;
            return false;
        }

        /// <summary>
        /// 求指定简单多边形的面积
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        internal static double GetPolygonSquare(moPoints points)
        {
            Int32 sPointCount = points.Count;
            double s = 0;
            double x0 = points.GetItem(0).X, y0 = points.GetItem(0).Y;
            for (Int32 i = 1; i <= sPointCount - 2; i++)
            {
                s = s + (points.GetItem(i).X - x0) * (points.GetItem(i + 1).Y - y0) - (points.GetItem(i + 1).X - x0) * (points.GetItem(i).Y - y0);
            }
            s = Math.Abs(s / 2);
            return s;
        }

        #endregion

        #region 算法部分

        /// <summary>
        /// 指示在指定容限下，一个点是否位于另一个点上
        /// </summary>
        /// <param name="point"></param>
        /// <param name="pointOverlapped"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool IsPointOnPoint(moPoint point, moPoint pointOverlapped, double tolerance)
        {
            if (GetDistance(point.X, point.Y, pointOverlapped.X, pointOverlapped.Y) <= tolerance)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 指示在指定容限下，指定点是否位于指定的折线上
        /// </summary>
        /// <param name="point"></param>
        /// <param name="points"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool IsPointOnPolyline(moPoint point, moPoints points, double tolerance)
        {
            moRectangle sBox = new moRectangle(points.MinX - tolerance, points.MaxX + tolerance, points.MinY - tolerance, points.MaxY + tolerance);
            if (IsPointWithinBox(point, sBox) == false)
                return false;
            Int32 sPointCount = points.Count;
            for (Int32 i = 0; i <= sPointCount - 2; i++)
            {
                if (GetDistanceFromPointToSegment(point.X, point.Y, points.GetItem(i).X, points.GetItem(i).Y,
                    points.GetItem(i + 1).X, points.GetItem(i + 1).Y) <= tolerance)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 指示在指定容限下，指定点是否位于指定复合折线上
        /// </summary>
        /// <param name="point"></param>
        /// <param name="multiPolyline"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool IsPointOnMultiPolyline(moPoint point, moMultiPolyline multiPolyline, double tolerance)
        {
            moRectangle sBox = new moRectangle(multiPolyline.MinX - tolerance, multiPolyline.MaxX + tolerance,
                multiPolyline.MinY - tolerance, multiPolyline.MaxY + tolerance);
            if (IsPointWithinBox(point, sBox) == false)
                return false;
            Int32 sPartCount = multiPolyline.Parts.Count;
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                if (IsPointOnPolyline(point, multiPolyline.Parts.GetItem(i), tolerance) == true)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 指示指定点是否位于指定矩形盒内
        /// </summary>
        /// <param name="point"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        public static bool IsPointWithinBox(moPoint point, moRectangle box)
        {
            if (point.X >= box.MinX && point.X <= box.MaxX && point.Y >= box.MinY && point.Y <= box.MaxY)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 指示指定点是否位于指定复合多边形内
        /// </summary>
        /// <param name="point"></param>
        /// <param name="multiPolygon"></param>
        /// <returns></returns>
        public static bool IsPointWithinMultiPolygon(moPoint point, moMultiPolygon multiPolygon)
        {
            //（1）判断点是否位于外包矩形内，如否则返回否
            moRectangle sExtent = multiPolygon.GetEnvelope();
            if (IsPointWithinBox(point, sExtent) == false)
            {
                return false;
            }
            //（2）射线法求交点个数
            Int32 sIntersectionCount = 0;       //交点个数
            Int32 sPartCount = multiPolygon.Parts.Count;
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                sIntersectionCount = sIntersectionCount + GetIntersectionCountBetweenRayAndPolygon(point, multiPolygon.Parts.GetItem(i));
            }
            if (sIntersectionCount % 2 == 1)
            {
                //奇数个，位于多边形内
                return true;
            }
            return false;
        }

        /// <summary>
        /// 指示指定复合折线是否部分或完全位于指定矩形盒内
        /// </summary>
        /// <param name="multipolyline"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        public static bool IsMultiPolylinePartiallyWithinBox(moMultiPolyline multipolyline, moRectangle box)
        {
            //思路：先判断矩形盒是否相交，如是，按如下顺序，满足任何一个条件，则返回True
            //（1）复合折线任何一个点位于矩形盒内;
            //（2）矩形盒与复合折线有交点
            moRectangle sBox = multipolyline.GetEnvelope();
            if (AreBoxesCross(sBox, box) == false)
                return false;
            //（1）复合折线任何一个点位于矩形盒内;
            Int32 sPartCount = multipolyline.Parts.Count;
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                Int32 sPointCount = multipolyline.Parts.GetItem(i).Count;
                for (Int32 j = 0; j <= sPointCount - 1; j++)
                {
                    moPoint sCurPoint = multipolyline.Parts.GetItem(i).GetItem(j);
                    if (IsPointWithinBox(sCurPoint, box) == true)
                        return true;
                }
            }
            //（2）矩形盒与复合折线有交点
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                moPoints sPoints = multipolyline.Parts.GetItem(i);
                Int32 sPointCount = sPoints.Count;
                for (Int32 j = 0; j <= sPointCount - 2; j++)
                {
                    if (IsSegmentCrossBox(sPoints.GetItem(j), sPoints.GetItem(j + 1), box) == true)
                        return true;
                }
            }
            //（3）都不满足，返回false
            return false;
        }

        /// <summary>
        /// 指示指定复合多边形是否部分或完全位于指定矩形盒内
        /// </summary>
        /// <param name="multipolygon"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        public static bool IsMultiPolygonPartiallyWithinBox(moMultiPolygon multipolygon, moRectangle box)
        {
            //思路：先判断矩形盒是否相交，如是，按如下顺序，满足任何一个条件，则返回True
            //（1）复合多边形任何一个点位于矩形盒内;
            //（2）矩形盒任何一个顶点位于复合多边形内
            //（3）矩形盒与复合多边形有交点
            moRectangle sBox = multipolygon.GetEnvelope();
            if (AreBoxesCross(sBox, box) == false)
                return false;
            //（1）多边形任何一个点位于矩形盒内
            Int32 sPartCount = multipolygon.Parts.Count;
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                Int32 sPointCount = multipolygon.Parts.GetItem(i).Count;
                for (Int32 j = 0; j <= sPointCount - 1; j++)
                {
                    moPoint sCurPoint = multipolygon.Parts.GetItem(i).GetItem(j);
                    if (IsPointWithinBox(sCurPoint, box) == true)
                        return true;
                }
            }
            //（2）矩形盒任何一个顶点位于多边形内
            moPoint sRectPoint = new moPoint(box.MinX, box.MinY);   //左下点
            if (IsPointWithinMultiPolygon(sRectPoint, multipolygon) == true)
                return true;
            sRectPoint = new moPoint(box.MinX, box.MaxY);           //左上点
            if (IsPointWithinMultiPolygon(sRectPoint, multipolygon) == true)
                return true;
            sRectPoint = new moPoint(box.MaxX, box.MaxY);           //右上点
            if (IsPointWithinMultiPolygon(sRectPoint, multipolygon) == true)
                return true;
            sRectPoint = new moPoint(box.MaxX, box.MinY);           //右下点
            if (IsPointWithinMultiPolygon(sRectPoint, multipolygon) == true)
                return true;
            //（3）矩形盒与复合多边形有交点
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                moPoints sPoints = multipolygon.Parts.GetItem(i);
                Int32 sPointCount = sPoints.Count;
                for (Int32 j = 0; j <= sPointCount - 2; j++)
                {
                    if (IsSegmentCrossBox(sPoints.GetItem(j), sPoints.GetItem(j + 1), box) == true)
                        return true;
                }
                if (IsSegmentCrossBox(sPoints.GetItem(sPointCount - 1), sPoints.GetItem(0), box) == true)
                    return true;
            }
            //（4）都不满足，返回false
            return false;
        }

        /// <summary>
        /// 获取指定折线的中点
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static moPoint GetMidPointOfPolyline(moPoints points)
        {
            Int32 sPointCount = points.Count;
            List<double> sDises = new List<double>();     //所有顶点至起点的距离
            sDises.Add(0);  //第一个点至起点的距离
            for (Int32 i = 1; i <= sPointCount - 1; i++)
            {
                double sCurDis = sDises.Last() + GetDistance(points.GetItem(i).X, points.GetItem(i).Y, points.GetItem(i - 1).X, points.GetItem(i - 1).Y);
                sDises.Add(sCurDis);
            }
            //查找中点所在的线段索引号
            Int32 sIndex = 0;
            double sMidDis = sDises.Last() / 2; //中点与起点的距离
            for (Int32 i = 0; i <= sPointCount - 2; i++)
            {
                if (sMidDis >= sDises[i] && sMidDis < sDises[i + 1])
                {
                    sIndex = i;
                    break;
                }
            }
            //计算中点
            double x1 = points.GetItem(sIndex).X, y1 = points.GetItem(sIndex).Y;
            double x2 = points.GetItem(sIndex + 1).X, y2 = points.GetItem(sIndex + 1).Y;
            double sSegDis = GetDistance(x1, y1, x2, y2);
            double x = x1 + (x2 - x1) * (sMidDis - sDises[sIndex]) / sSegDis;
            double y = y1 + (y2 - y1) * (sMidDis - sDises[sIndex]) / sSegDis;
            moPoint sMidPoint = new moPoint(x, y);
            return sMidPoint;
        }

        /// <summary>
        /// 获取指定复合多边形的一个注记点
        /// </summary>
        /// <param name="multiPolygon"></param>
        /// <returns></returns>
        public static moPoint GetLabelPointOfMultiPolygon(moMultiPolygon multiPolygon)
        {
            //思路：找到面积最大的环MaxRing，如果只有一个环，则它就是面积最大的环，面积最大的环必定是外环
            //在MaxRing的Y坐标极值的中点处做扫描线，求出扫描线与MaxRing的交点序列Intersections，获得X坐标
            //最小和最大两个交点P1和P2。
            //该扫描线与其他所有环求交点，如果交点位于P1和P2之间，则加入Intersections，否则不加入。
            //对Intersections按照X坐标排序，然后两两配对，找出长度最大的一对交点，其中点即为注记点
            Int32 sPartCount = multiPolygon.Parts.Count;
            //（1）求面积最大的环
            moPoints sMaxRing;  //面积最大的环
            Int32 sPartIndex = 0;   //面积最大环的索引号
            if (sPartCount == 0)
            { throw new Exception("MultiPolygon has no one part!"); }
            else if (sPartCount == 1)
            {
                sPartIndex = 0;
                sMaxRing = multiPolygon.Parts.GetItem(0);
            }
            else
            {
                //求第一个环的面积
                double sMaxS = GetPolygonSquare(multiPolygon.Parts.GetItem(0));
                //求其他环的面积，保留面积最大者
                for (Int32 i = 1; i <= sPartCount - 1; i++)
                {
                    double sCurS = GetPolygonSquare(multiPolygon.Parts.GetItem(i));
                    if (sCurS > sMaxS)
                    {
                        sMaxS = sCurS;
                        sPartIndex = i;
                    }
                }
                sMaxRing = multiPolygon.Parts.GetItem(sPartIndex);
            }
            //（2）求扫描线和面积最大环的交点序列
            sMaxRing.UpdateExtent();
            double sScanY = (sMaxRing.MinY + sMaxRing.MaxY) / 2;    //扫描线Y坐标
            List<double> sIntersections = GetIntersectionsBetweenScanAndPolygon(sScanY, sMaxRing);
            double sMinX = sIntersections.Min(), sMaxX = sIntersections.Max();  //最小最大X坐标
            //（3）求扫描线与其他环的交点
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                if (i == sPartIndex)
                    continue;               //不用再计算最大环的交点
                //与当前环的交点
                List<double> sCurIntersections = GetIntersectionsBetweenScanAndPolygon(sScanY, multiPolygon.Parts.GetItem(i));
                //加入sIntersections
                for (Int32 j = 0; j <= sCurIntersections.Count - 1; j++)
                    if (sCurIntersections[j] > sMinX && sCurIntersections[j] < sMaxX)
                    {
                        sIntersections.Add(sCurIntersections[j]);
                    }
            }
            //（4）对交点序列排序，并两两配对，求出距离最大者
            sIntersections.Sort();
            Int32 sIntersectionCount = sIntersections.Count;
            double sMaxDis = double.MinValue;
            Int32 sIntersectionIndex = 0;
            for (Int32 i = 0; i <= sIntersectionCount - 2; i += 2)
            {
                double sCurDis = sIntersections[i + 1] - sIntersections[i];
                if (sCurDis > sMaxDis)
                {
                    sMaxDis = sCurDis;
                    sIntersectionIndex = i;
                }
            }
            //（5）计算距离最大的一对交点的中点
            double sLabelPointX = (sIntersections[sIntersectionIndex] + sIntersections[sIntersectionIndex + 1]) / 2;
            moPoint sLabelPoint = new moPoint(sLabelPointX, sScanY);
            return sLabelPoint;
        }
        #endregion
    }
}
