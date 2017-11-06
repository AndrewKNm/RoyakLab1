using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace RoyakLab1
{
    public interface IGraphicsBuilder
    {
        void ParseExpression(string s, int h);
        void AddPoint(Point p);
        GraphicsPath GetPath();
    }
}