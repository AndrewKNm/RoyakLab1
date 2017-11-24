using System;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using org.mariuszgromada.math.mxparser;

namespace RoyakLab1

{
    public class GraphicsBuilder : IGraphicsBuilder
    {
        public class parameters
        {
            public double x { get; set; }
        };
        Expression exp;
        private List<Point> pointList;
        public void ParseExpression(string s, int h, int w, int factor)
        {
            pointList.Clear();
            var script = Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.Create<double>(s, Microsoft.CodeAnalysis.Scripting.ScriptOptions.Default.WithImports("System.Math").WithReferences(typeof(parameters).AssemblyQualifiedName), typeof(parameters));
            Microsoft.CodeAnalysis.Scripting.ScriptRunner<double> fun = script.CreateDelegate();
            for (int i = 0; i < w; i += 4)
            {
                double ax = (double)i / factor;               
                //var st = $"x = {ax}";
               // st = st.Replace(",", ".");
                
               // Argument x = new Argument(st);
               // exp = new Expression(s, x);
                var y = h/2 - (int)(fun.Invoke(new parameters() { x = ax }).Result *factor);
                //var z = exp.calculate();
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