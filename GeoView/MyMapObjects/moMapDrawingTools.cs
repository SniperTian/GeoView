using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyMapObjects
{
    internal static class moMapDrawingTools
    {
        #region 程序集方法
        internal static void DrawGeometry(Graphics g, moRectangle extent, double mapScale, double dpm, double mpu, moGeometry geometry, moSymbol symbol)
        {
            if (extent == null)
                return;
            if (geometry == null)
                return;
            if (symbol == null)
                return;
            if (geometry.GetType() == typeof(moPoint))
            {
                moPoint sPoint = (moPoint)geometry;
                DrawPoint(g, extent, mapScale, dpm, mpu, sPoint, symbol);
            }
            else if (geometry.GetType() == typeof(moMultiPolyline))
            {
                moMultiPolyline sMultiPolyline = (moMultiPolyline)geometry;
                DrawMultiPolyline(g, extent, mapScale, dpm, mpu, sMultiPolyline, symbol);
            }
            else if (geometry.GetType() == typeof(moMultiPolygon))
            {
                moMultiPolygon sMultiPolygon = (moMultiPolygon)geometry;
                DrawMultiPolygon(g, extent, mapScale, dpm, mpu, sMultiPolygon, symbol);
            }
            else if (geometry.GetType() == typeof(moPoints))
            {
                moPoints sPoints = (moPoints)geometry;
                DrawPoints(g, extent, mapScale, dpm, mpu, sPoints, symbol);
            }
        }

        //绘制点
        internal static void DrawPoint(Graphics g, moRectangle extent, double mapScale, double dpm, double mpu, moPoint point, moSymbol symbol)
        {
            if (symbol.SymbolType == moSymbolTypeConstant.SimpleMarkerSymbol)
            {
                moSimpleMarkerSymbol sSymbol = (moSimpleMarkerSymbol)symbol;
                if (sSymbol.Visible == true)
                    DrawPointBySimpleMarker(g, extent, mapScale, dpm, mpu, point, sSymbol);
            }
        }

        //绘制线段
        internal static void DrawLine(Graphics g, moRectangle extent, double mapScale, double dpm, double mpu, moPoint point1, moPoint point2, moSymbol symbol)
        {
            if (symbol.SymbolType == moSymbolTypeConstant.SimpleLineSymbol)
            {
                moSimpleLineSymbol sSymbol = (moSimpleLineSymbol)symbol;
                if (sSymbol.Visible == true)
                    DrawLineBySimpleLine(g, extent, mapScale, dpm, mpu, point1, point2, sSymbol);
            }
        }

        //绘制点集合（多点）
        internal static void DrawPoints(Graphics g, moRectangle extent, double mapScale, double dpm, double mpu, moPoints points, moSymbol symbol)
        {
            if (symbol.SymbolType == moSymbolTypeConstant.SimpleMarkerSymbol)
            {
                moSimpleMarkerSymbol sSymbol = (moSimpleMarkerSymbol)symbol;
                if (sSymbol.Visible == true)
                {
                    Int32 sPointCount = points.Count;
                    for (Int32 i = 0; i <= sPointCount - 1; i++)
                    {
                        moPoint sPoint = points.GetItem(i);
                        DrawPointBySimpleMarker(g, extent, mapScale, dpm, mpu, sPoint, sSymbol);
                    }
                }
            }
        }

        //绘制矩形
        internal static void DrawRectangle(Graphics g, moRectangle extent, double mapScale, double dpm, double mpu, moRectangle rectangle, moSymbol symbol)
        {
            if (symbol.SymbolType == moSymbolTypeConstant.SimpleFillSymbol)
            {
                moSimpleFillSymbol sSymbol = (moSimpleFillSymbol)symbol;
                if (sSymbol.Visible == true)
                {
                    DrawRectangleBySimpleFill(g, extent, mapScale, dpm, mpu, rectangle, sSymbol);
                }
            }
        }

        //绘制简单折线
        internal static void DrawPolyline(Graphics g, moRectangle extent, double mapScale, double dpm, double mpu, moPoints points, moSymbol symbol)
        {
            if (symbol.SymbolType == moSymbolTypeConstant.SimpleLineSymbol)
            {
                moSimpleLineSymbol sSymbol = (moSimpleLineSymbol)symbol;
                if (sSymbol.Visible == true)
                {
                    DrawPolylineBySimpleLine(g, extent, mapScale, dpm, mpu, points, sSymbol);
                }
            }
        }

        //绘制简单多边形
        internal static void DrawPolygon(Graphics g, moRectangle extent, double mapScale, double dpm, double mpu, moPoints points, moSymbol symbol)
        {
            if (symbol.SymbolType == moSymbolTypeConstant.SimpleFillSymbol)
            {
                moSimpleFillSymbol sSymbol = (moSimpleFillSymbol)symbol;
                if (sSymbol.Visible == true)
                {
                    DrawPolygonBySimpleFill(g, extent, mapScale, dpm, mpu, points, sSymbol);
                }
            }
        }      
        //绘制复合折线
        internal static void DrawMultiPolyline(Graphics g, moRectangle extent, double mapScale, double dpm, double mpu, moMultiPolyline multiPolyline, moSymbol symbol)
        {
            if (symbol.SymbolType == moSymbolTypeConstant.SimpleLineSymbol)
            {
                moSimpleLineSymbol sSymbol = (moSimpleLineSymbol)symbol;
                if (sSymbol.Visible == true)
                    DrawMultiPolylineBySimpleLine(g, extent, mapScale, dpm, mpu, multiPolyline, sSymbol);
            }
        }

        //绘制复合多边形
        internal static void DrawMultiPolygon(Graphics g, moRectangle extent, double mapScale, double dpm, double mpu, moMultiPolygon multiPolygon, moSymbol symbol)
        {
            if (symbol.SymbolType == moSymbolTypeConstant.SimpleFillSymbol)
            {
                moSimpleFillSymbol sSymbol = (moSimpleFillSymbol)symbol;
                if (sSymbol.Visible == true)
                    DrawMultiPolygonBySimpleFill(g, extent, mapScale, dpm, mpu, multiPolygon, sSymbol);
            }
        }

        //绘制注记
        internal static void DrawLabel(Graphics g, double dpm, PointF OriPoint, string labelText, moTextSymbol textSymbol)
        {
            SmoothingMode sSmoothMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.HighQuality;
            //说明，OriPoint：绘制原点（即注记左上点）
            SolidBrush sTextBrush = new SolidBrush(textSymbol.FontColor);
            Pen sMaskPen = new Pen(textSymbol.MaskColor, (float)(2 * textSymbol.MaskWidth * dpm / 1000));
            float dpi = (float)(dpm * 0.0254);
            if (textSymbol.UseMask == true)
            {   //需要描边
                GraphicsPath sGraphicPath = new GraphicsPath();
                sGraphicPath.AddString(labelText, textSymbol.Font.FontFamily, (Int32)textSymbol.Font.Style, textSymbol.Font.Size * dpi / 72, OriPoint, StringFormat.GenericDefault);
                g.DrawPath(sMaskPen, sGraphicPath);
                g.FillPath(sTextBrush, sGraphicPath);
                sGraphicPath.Dispose();
            }
            else
            {   //不需要描边
                g.DrawString(labelText, textSymbol.Font, sTextBrush, OriPoint);
            }
            sTextBrush.Dispose();
            sMaskPen.Dispose();
            g.SmoothingMode = sSmoothMode;
        }


        #endregion

        #region 私有函数

        //采用简单点符号绘制点
        private static void DrawPointBySimpleMarker(Graphics g, moRectangle extent, double mapScale, double dpm,
            double mpu, moPoint point, moSimpleMarkerSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            PointF sScreenPoint = new PointF();
            sScreenPoint.X = (float)((point.X - sOffsetX) * mpu / mapScale * dpm);
            sScreenPoint.Y = (float)((sOffsetY - point.Y) * mpu / mapScale * dpm);
            //（2）计算符号大小
            float sSize = (float)(symbol.Size / 1000 * dpm);     //符号大小，像素
            if (sSize < 1)
                sSize = 1;
            //（3）定义绘制区域并绘制
            Rectangle sDrawingArea = new Rectangle((Int32)(sScreenPoint.X - sSize / 2), (Int32)(sScreenPoint.Y - sSize / 2), (Int32)sSize, (Int32)sSize);
            DrawSimpleMarker(g, sDrawingArea, dpm, symbol);
        }

        //采用简单线符号绘制线段
        private static void DrawLineBySimpleLine(Graphics g, moRectangle extent, double mapScale, double dpm,
            double mpu, moPoint point1, moPoint point2, moSimpleLineSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            PointF sScreenPoint1 = new PointF();
            PointF sScreenPoint2 = new PointF();
            sScreenPoint1.X = (float)((point1.X - sOffsetX) * mpu / mapScale * dpm);
            sScreenPoint1.Y = (float)((sOffsetY - point1.Y) * mpu / mapScale * dpm);
            sScreenPoint2.X = (float)((point2.X - sOffsetX) * mpu / mapScale * dpm);
            sScreenPoint2.Y = (float)((sOffsetY - point2.Y) * mpu / mapScale * dpm);
            //（2）绘制
            Pen sPen = new Pen(symbol.Color, (float)(symbol.Size / 1000 * dpm));
            sPen.DashStyle = (DashStyle)symbol.Style;
            g.DrawLine(sPen, sScreenPoint1, sScreenPoint2);
            sPen.Dispose();
        }

        //采用简单线符号绘制简单折线
        private static void DrawPolylineBySimpleLine(Graphics g, moRectangle extent, double mapScale, double dpm,
            double mpu, moPoints points, moSimpleLineSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            GraphicsPath sGraphicPath = new GraphicsPath();     //用于屏幕绘制
            Int32 sPointCount = points.Count;  //顶点数目
            PointF[] sScreenPoints = new PointF[sPointCount];
            for (Int32 j = 0; j <= sPointCount - 1; j++)
            {
                PointF sScreenPoint = new PointF();
                moPoint sCurPoint = points.GetItem(j);
                sScreenPoint.X = (float)((sCurPoint.X - sOffsetX) * mpu / mapScale * dpm);
                sScreenPoint.Y = (float)((sOffsetY - sCurPoint.Y) * mpu / mapScale * dpm);
                sScreenPoints[j] = sScreenPoint;
            }
            sGraphicPath.AddLines(sScreenPoints);
            //（2）绘制
            Pen sPen = new Pen(symbol.Color, (float)(symbol.Size / 1000 * dpm));
            sPen.DashStyle = (DashStyle)symbol.Style;
            g.DrawPath(sPen, sGraphicPath);
            sPen.Dispose();
        }

        //采用简单线符号绘制复合折线
        private static void DrawMultiPolylineBySimpleLine(Graphics g, moRectangle extent, double mapScale, double dpm,
            double mpu, moMultiPolyline multiPolyline, moSimpleLineSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            Int32 sPartCount = multiPolyline.Parts.Count;        //简单折线的数目
            GraphicsPath sGraphicPath = new GraphicsPath();     //定义复合多边形，用于屏幕绘制
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                Int32 sPointCount = multiPolyline.Parts.GetItem(i).Count;  //当前简单折线的顶点数目
                PointF[] sScreenPoints = new PointF[sPointCount];
                for (Int32 j = 0; j <= sPointCount - 1; j++)
                {
                    PointF sScreenPoint = new PointF();
                    moPoint sCurPoint = multiPolyline.Parts.GetItem(i).GetItem(j);
                    sScreenPoint.X = (float)((sCurPoint.X - sOffsetX) * mpu / mapScale * dpm);
                    sScreenPoint.Y = (float)((sOffsetY - sCurPoint.Y) * mpu / mapScale * dpm);
                    sScreenPoints[j] = sScreenPoint;
                }
                sGraphicPath.AddLines(sScreenPoints);
                sGraphicPath.StartFigure();
            }
            //（2）绘制
            Pen sPen = new Pen(symbol.Color, (float)(symbol.Size / 1000 * dpm));
            sPen.DashStyle = (DashStyle)symbol.Style;
            g.DrawPath(sPen, sGraphicPath);
            sPen.Dispose();
        }

        //采用简单填充符号绘制矩形
        private static void DrawRectangleBySimpleFill(Graphics g, moRectangle extent, double mapScale, double dpm,
            double mpu, moRectangle rectangle, moSimpleFillSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标并生成矩形
            Point sTopLeftPoint = new Point(), sBottomRightPoint = new Point();
            sTopLeftPoint.X = (Int32)((rectangle.MinX - sOffsetX) * mpu / mapScale * dpm);
            sTopLeftPoint.Y = (Int32)((sOffsetY - rectangle.MaxY) * mpu / mapScale * dpm);
            sBottomRightPoint.X = (Int32)((rectangle.MaxX - sOffsetX) * mpu / mapScale * dpm);
            sBottomRightPoint.Y = (Int32)((sOffsetY - rectangle.MinY) * mpu / mapScale * dpm);
            Int32 sWidth = sBottomRightPoint.X - sTopLeftPoint.X;
            Int32 sHeight = sBottomRightPoint.Y - sTopLeftPoint.Y;
            Rectangle sRect = new Rectangle(sTopLeftPoint.X, sTopLeftPoint.Y, sWidth, sHeight);
            //（2）填充
            if (symbol.Color != Color.Transparent)
            {
                SolidBrush sBrush = new SolidBrush(symbol.Color);
                g.FillRectangle(sBrush, sRect);
                sBrush.Dispose();
            }
            //（3）绘制边界
            if (symbol.Outline.SymbolType == moSymbolTypeConstant.SimpleLineSymbol)
            {
                moSimpleLineSymbol sOutline = symbol.Outline;
                if (sOutline.Visible == true)
                {
                    Pen sPen = new Pen(sOutline.Color, (float)(sOutline.Size / 1000 * dpm));
                    sPen.DashStyle = (DashStyle)sOutline.Style;
                    g.DrawRectangle(sPen, sRect);
                    sPen.Dispose();
                }
            }
        }

        //采用简单填充符号绘制简单多边形
        private static void DrawPolygonBySimpleFill(Graphics g, moRectangle extent, double mapScale, double dpm,
            double mpu, moPoints points, moSimpleFillSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            GraphicsPath sGraphicPath = new GraphicsPath();     //用于屏幕绘制
            Int32 sPointCount = points.Count;  //顶点数目
            PointF[] sScreenPoints = new PointF[sPointCount];
            for (Int32 j = 0; j <= sPointCount - 1; j++)
            {
                PointF sScreenPoint = new PointF();
                moPoint sCurPoint = points.GetItem(j);
                sScreenPoint.X = (float)((sCurPoint.X - sOffsetX) * mpu / mapScale * dpm);
                sScreenPoint.Y = (float)((sOffsetY - sCurPoint.Y) * mpu / mapScale * dpm);
                sScreenPoints[j] = sScreenPoint;
            }
            sGraphicPath.AddPolygon(sScreenPoints);
            //（2）填充
            SolidBrush sBrush = new SolidBrush(symbol.Color);
            g.FillPath(sBrush, sGraphicPath);
            sBrush.Dispose();
            //（3）绘制边界
            if (symbol.Outline.SymbolType == moSymbolTypeConstant.SimpleLineSymbol)
            {
                moSimpleLineSymbol sOutline = symbol.Outline;
                if (sOutline.Visible == true)
                {
                    Pen sPen = new Pen(sOutline.Color, (float)(sOutline.Size / 1000 * dpm));
                    sPen.DashStyle = (DashStyle)sOutline.Style;
                    g.DrawPath(sPen, sGraphicPath);
                    sPen.Dispose();
                }
            }
        }

        //采用简单填充符号绘制复合多边形
        private static void DrawMultiPolygonBySimpleFill(Graphics g, moRectangle extent, double mapScale, double dpm,
            double mpu, moMultiPolygon multiPolygon, moSimpleFillSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            Int32 sPartCount = multiPolygon.Parts.Count;        //简单多边形的数目
            GraphicsPath sGraphicPath = new GraphicsPath();     //定义复合多边形，用于屏幕绘制
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                Int32 sPointCount = multiPolygon.Parts.GetItem(i).Count;  //当前简单多边形的顶点数目
                PointF[] sScreenPoints = new PointF[sPointCount];
                for (Int32 j = 0; j <= sPointCount - 1; j++)
                {
                    PointF sScreenPoint = new PointF();
                    moPoint sCurPoint = multiPolygon.Parts.GetItem(i).GetItem(j);
                    sScreenPoint.X = (float)((sCurPoint.X - sOffsetX) * mpu / mapScale * dpm);
                    sScreenPoint.Y = (float)((sOffsetY - sCurPoint.Y) * mpu / mapScale * dpm);
                    sScreenPoints[j] = sScreenPoint;
                }
                sGraphicPath.AddPolygon(sScreenPoints);
            }
            //（2）填充
            SolidBrush sBrush = new SolidBrush(symbol.Color);
            g.FillPath(sBrush, sGraphicPath);
            sBrush.Dispose();
            //（3）绘制边界
            if (symbol.Outline.SymbolType == moSymbolTypeConstant.SimpleLineSymbol)
            {
                moSimpleLineSymbol sOutline = symbol.Outline;
                if (sOutline.Visible == true)
                {
                    Pen sPen = new Pen(sOutline.Color, (float)(sOutline.Size / 1000 * dpm));
                    sPen.DashStyle = (DashStyle)sOutline.Style;
                    g.DrawPath(sPen, sGraphicPath);
                    sPen.Dispose();
                }
            }
        }

        //绘制简单点符号   此处需要自己补全代码
        private static void DrawSimpleMarker(Graphics g, Rectangle drawingArea, double dpm, moSimpleMarkerSymbol symbol)
        {
            if (symbol.Style == moSimpleMarkerSymbolStyleConstant.Circle)
            {
                Pen sPen = new Pen(symbol.Color, 2);
                g.DrawEllipse(sPen, drawingArea);
                sPen.Dispose();
            }
            else if (symbol.Style == moSimpleMarkerSymbolStyleConstant.SolidCircle)
            {
                SolidBrush sBrush = new SolidBrush(symbol.Color);
                g.FillEllipse(sBrush, drawingArea);
                sBrush.Dispose();
            }
            else if (symbol.Style == moSimpleMarkerSymbolStyleConstant.Triangle)
            {
                Pen sPen = new Pen(symbol.Color, 2);
                Point point1 = new Point(drawingArea.X, drawingArea.Y + drawingArea.Height);
                Point point2 = new Point(drawingArea.X + drawingArea.Width, drawingArea.Y + drawingArea.Height);
                Point point3 = new Point(drawingArea.X + drawingArea.Width / 2, drawingArea.Y);
                Point[] pntArr = { point1, point2, point3 };
                g.DrawPolygon(sPen, pntArr);
                sPen.Dispose();
            }
            else if (symbol.Style == moSimpleMarkerSymbolStyleConstant.SolidTriangle)
            {
                SolidBrush sBrush = new SolidBrush(symbol.Color);
                Point point1 = new Point(drawingArea.X, drawingArea.Y + drawingArea.Height);
                Point point2 = new Point(drawingArea.X + drawingArea.Width, drawingArea.Y + drawingArea.Height);
                Point point3 = new Point(drawingArea.X + drawingArea.Width / 2, drawingArea.Y);
                Point[] pntArr = { point1, point2, point3 };
                g.FillPolygon(sBrush, pntArr);
                sBrush.Dispose();
            }
            else if (symbol.Style == moSimpleMarkerSymbolStyleConstant.Square)
            {
                Pen sPen = new Pen(symbol.Color, 2);
                Point point1 = new Point(drawingArea.X, drawingArea.Y);
                g.DrawRectangle(sPen, point1.X, point1.Y, drawingArea.Width, drawingArea.Height);
                sPen.Dispose();
            }
            else if (symbol.Style == moSimpleMarkerSymbolStyleConstant.SolidSquare)
            {
                SolidBrush sBrush = new SolidBrush(symbol.Color);
                g.FillRectangle(sBrush, drawingArea);
                sBrush.Dispose();
            }
            else if (symbol.Style == moSimpleMarkerSymbolStyleConstant.CircleDot)
            {
                Pen sPen = new Pen(symbol.Color, 2);
                SolidBrush sBrush = new SolidBrush(symbol.Color);
                g.DrawEllipse(sPen, drawingArea);
                Rectangle sRect = new Rectangle(drawingArea.X + drawingArea.Width / 2,
                    drawingArea.Y + drawingArea.Height / 2, 2, 2);
                g.FillRectangle(sBrush, sRect);
                sPen.Dispose();
                sBrush.Dispose();
            }
            else if (symbol.Style == moSimpleMarkerSymbolStyleConstant.CircleCircle)
            {
                Pen sPen = new Pen(symbol.Color, 2);
                Rectangle sRect = new Rectangle(drawingArea.X + drawingArea.Width / 4,
                    drawingArea.Y + drawingArea.Height / 4, drawingArea.Width / 2, drawingArea.Height / 2);
                g.DrawEllipse(sPen, drawingArea);
                g.DrawEllipse(sPen, sRect);
                sPen.Dispose();
            }
        }

        #endregion
    }
}
