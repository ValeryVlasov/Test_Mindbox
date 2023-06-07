using System;
using Geometry;
using NUnit.Framework;

namespace GeometryTest
{
    [TestFixture]
    public class CircleTest
    {
        private const double eps = 1e-7;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ZeroRadiusTest()
        {
            Assert.Catch<ArgumentException>(() => new Circle(0));
        }

        [Test]
        public void NegativeRadiusTest()
        {
            Assert.Catch<ArgumentException>(() => new Circle(-1));
        }

        [Test]
        public void GetSquareTest()
        {
            var radius = 10;
            var circle = new Circle(radius);
            var expected = Math.PI * Math.Pow(radius, 2);   

            var result = circle.GetSquare();

            Assert.Less(Math.Abs(result - expected), eps);
        }
    }
}