using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TipToyGui.Common
{
    public class Polygon
    {
        private static int idCounter;
        private int id;
        public PointF[] Vertices { get => verts.ToArray(); set => verts = value.ToList(); }
        private List<PointF> verts;
        private int selectedIndex = -1;

        public Polygon()
        {
            verts = new List<PointF>();
            idCounter++;
            id = idCounter;
        }

        public RectangleF GetBound()
        {
            PointF topLeft = new PointF();
            PointF bottomRight = new PointF();

            for (int i = 0; i < Vertices.Length; i++)
            {
                if (i == 0)
                {
                    bottomRight.X = topLeft.X = Vertices[i].X;
                    bottomRight.Y = topLeft.Y = Vertices[i].Y;
                }
                else
                {
                    if (Vertices[i].X < topLeft.X) topLeft.X = Vertices[i].X;
                    if (Vertices[i].X > bottomRight.X) bottomRight.X = Vertices[i].X;

                    if (Vertices[i].Y < topLeft.Y) topLeft.Y = Vertices[i].Y;
                    if (Vertices[i].Y > bottomRight.Y) bottomRight.Y = Vertices[i].Y;
                }
            }
            return new RectangleF(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);
        }

        public void SelectIndex(PointF pos)
        {
            selectedIndex = verts.FindIndex(x => x == pos);
        }

        public void MoveVert(PointF pos)
        {
            if (selectedIndex > -1)
                verts[selectedIndex] = pos;
        }

        public void AddVert(PointF pos, PointF pos2)
        {
            int a = verts.FindIndex(x => x == pos);
            int b = verts.FindIndex(x => x == pos2);
            if (a < b && b - a > 1 || a > b && a - b > 1)
            {
                verts.Insert(a < b ? a : b, Middle(pos, pos2));
            }
            else
            {
                verts.Insert(a < b ? b : a, Middle(pos, pos2));
            }
        }

        public PointF Middle(PointF a, PointF b)
        {
            float x = (a.X + b.X) / 2;
            float y = (a.Y + b.Y) / 2;
            return new PointF(x, y);
        }

        public void AddVert(PointF pos)
        {
            verts.Add(pos);
        }

        public void DelVert(PointF pos)
        {
            int i = verts.FindIndex(x => x == pos);
            if (i > -1)
                verts.RemoveAt(i);
        }

        public override string ToString()
        {
            return $"Polygon ID {id}";
        }

        internal void MovePolygon(PointF pointF)
        {
            var r = GetBound().Center();
            var offset = pointF.Sub(r);

            for (int i = 0; i < verts.Count; i++)
            {
                verts[i]= verts[i].Add(offset);
            }

            
        }
    }
}