using System;
using MathUtil.Algorithm;
using MathUtil.Geometry;
using Xunit;

namespace MathUtil.UnitTest
{
    public class AlgorithmTest
    {
        Polygon GetPolygon()
        {
            var boundary = new Point2D[]
            {
                new Point2D(0, 0),
                new Point2D(4, 0),
                new Point2D(4, 4),
                new Point2D(2, 4),
                new Point2D(2, 3),
                new Point2D(3, 1),
                new Point2D(1, 2),
                new Point2D(0, 2)

                //new Point2D(0, 0),
                //new Point2D(2, 3),
                //new Point2D(4, 1),
                //new Point2D(3, -3),
                //new Point2D(3, 4),
                //new Point2D(1, 4)
            };
            return new Polygon(boundary);
        }

        [Fact]
        public void GeometryAlgorithmTest()
        {
            var point = new Point2D(2, 1.51);
            var polygon = GetPolygon();
            Assert.False(GeometryAlgorithm.IsPointInPolygon(point, polygon));
            point = new Point2D(1, 2.1);
            var distance = GeometryAlgorithm.Point2Polygon(point, polygon, out var nearest);
            Assert.True(point.X == nearest.X && distance == Math.Abs(point.Y - nearest.Y));
        }

        [Fact]
        public void Test2()
        {
            var segment = new Segment(new Point2D(0, 0), new Point2D(2, 2));
            var point = new Point2D(2, 0);
            Assert.Equal(new Point2D(2d / 2, 2d / 2), segment.GetLine().GetFootpoint(point));
        }


        [Fact]
        public void Test3()
        {
            var polygon = new Point2D[]
            {
                new Point2D(0, 0),
                new Point2D(2, 3),
                new Point2D(4, 1),
                new Point2D(3, -3),
                new Point2D(3, 4),
                new Point2D(1, 4)
            };
            Assert.True(GeometryAlgorithm.IsSelfIntersected(polygon));
        }

        [Fact]
        public void Test4()
        {
            var circle = new Circle(Point2D.Origin, 1);
            var point = new Point2D(-3, 0);

            Assert.True(GeometryAlgorithm.Point2Circle(point, circle, out _).IsEqual(2));
        }
    }
}
