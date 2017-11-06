using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
namespace RoyakLab1
{
    public class GraphicsBuilder : IGraphicsBuilder
    {
        private List<Point> pointList;
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