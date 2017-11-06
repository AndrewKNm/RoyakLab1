using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using org.mariuszgromada.math.mxparser;

namespace RoyakLab1

{
    public class GraphicsBuilder : IGraphicsBuilder
    {
        Expression exp;
        private List<Point> pointList;
        public void ParseExpression(string s, int h)
        {
            pointList.Clear();
            for (int i = 0; i < 640; i += 4)
            {
                double ax = (double)i / 100;
                Argument x = new Argument(string.Format("x = {0}",ax));
                exp = new Expression(s, x);
                var y = h - (int)(exp.calculate()*100);
                AddPoint(new Point(i, y));
            }
        }
        public GraphicsBuilder()
        {
            pointList = new List<Point>();
        }
        public void AddPoint(Point p)
        {
            pointList.Add(p);
            pointList = pointList.OrderBy(pt => pt.X).ToList();
        }
        public GraphicsPath GetPath()
        {
            var gp = new GraphicsPath();
            gp.AddLines(pointList.ToArray<Point>());
            return gp;
        }
    }
}