using System;

namespace GeometryTasks
{
    public class Vector
    {
        public double X;
        public double Y;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector vector)
        {
            return Geometry.Add(this, vector);
        }

        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }

    public class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static double GetLength(Segment segment)
        {
            return Math.Sqrt((segment.Begin.X - segment.End.X) * (segment.Begin.X - segment.End.X) 
                + (segment.Begin.Y - segment.End.Y) * (segment.Begin.Y - segment.End.Y));
        }

        public static double GetLength(Segment segment, Vector vector)
        {
            return Math.Sqrt((segment.Begin.X - vector.X) * (segment.Begin.X - vector.X) 
                + (segment.Begin.Y - vector.Y) * (segment.Begin.Y - vector.Y));
        }

        public static double GetLength(Vector vector, Segment segment)
        {
            return Math.Sqrt((vector.X - segment.End.X) * (vector.X - segment.End.X) 
                + (vector.Y - segment.End.Y) * (vector.Y - segment.End.Y));
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector { X = vector1.X + vector2.X, Y = vector1.Y + vector2.Y };
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            return Geometry.GetLength(segment) == 
                Geometry.GetLength(segment, vector) + Geometry.GetLength(vector, segment);
        }
    }
}