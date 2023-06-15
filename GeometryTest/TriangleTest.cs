using System;
using Geometry;
using NUnit.Framework;
using static NUnit.Framework.Constraints.Tolerance;

namespace GeometryTest
{
    public class TriangleTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitTriangleTest()
        {
            // Arrange
            double a = 3, b = 4, c = 5;

            // Act
            var triangle = new Triangle(a, b, c);

            // Assert
            Assert.NotNull(triangle);
            Assert.Less(Math.Abs(triangle.EdgeA - a), Constants.Accuracy);
            Assert.Less(Math.Abs(triangle.EdgeB - b), Constants.Accuracy);
            Assert.Less(Math.Abs(triangle.EdgeC - c), Constants.Accuracy);
        }

        [TestCase(-5, 4, 3)]
        [TestCase(5, -4, 3)]
        [TestCase(5, 4, -3)]
        [TestCase(0, 4, 3)]
        [TestCase(5, 0, 3)]
        [TestCase(5, 4, 0)]
        public void InitTriangleWithInvalidSidesTest(double a, double b, double c)
        {
            Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));
        }

        [Test]
        public void GetSquareTest()
        {
            // Arrange
            double a = 3, b = 4, c = 5;
            double result = 6;
            var triangle = new Triangle(a, b, c);

            // Act
            var square = triangle?.GetSquare();

            // Assert
            Assert.NotNull(square);
            Assert.Less(Math.Abs(square.Value - result), Constants.Accuracy);
        }

        [Test]
        public void NotTriangleTest()
        {
            Assert.Catch<ArgumentException>(() => new Triangle(2, 50, 2));
        }

        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(3, 3, 5, ExpectedResult = false)]
        [TestCase(3, 4, 5.000000001, ExpectedResult = true)]
        [TestCase(3, 4, 5 + 2e-7, ExpectedResult = false)]
        public bool NotRightTriangle(double a, double b, double c)
        {
            // Arrange
            var triangle = new Triangle(a, b, c);

            // Act
            var isRight = triangle.IsRightTriangle;

            // Assert
            return isRight;
        }
    }
}
