using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;

namespace Geometry
{
    public class Triangle : ITriangle
    {
        public double EdgeA { get; }
        public double EdgeB { get; }
        public double EdgeC { get; }

        private readonly bool _isRightTriangle;
        public bool IsRightTriangle => _isRightTriangle;

        public Triangle(double edgeA, double edgeB, double edgeC)
        {
            if ( edgeA <= 0 || edgeB <= 0 || edgeC <= 0) { throw new ArgumentException("The length of each side must be greater then zero"); }

            var maxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
            if ((edgeA + edgeB + edgeC) - 2 * maxEdge < Constants.Accuracy)
                throw new ArgumentException("The larger side must be less then sum of the two other sides");

            EdgeA = edgeA;
            EdgeB = edgeB;
            EdgeC = edgeC;

            _isRightTriangle = GetIsRightTriangle();
        }

        private bool GetIsRightTriangle()
        {
            double maxEdge = EdgeA, b = EdgeB, c = EdgeC;

            if (b - maxEdge > Constants.Accuracy)
                Utils.Swap(ref maxEdge, ref b);
            if (c - maxEdge > Constants.Accuracy)
                Utils.Swap(ref maxEdge, ref c);

            return Math.Abs(Math.Pow(maxEdge, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < Constants.Accuracy;
        }

        public double GetSquare()
        {
            var halfP = (EdgeA + EdgeB + EdgeC) / 2;
            return Math.Sqrt(halfP * (halfP - EdgeA) * (halfP - EdgeB) * (halfP - EdgeC));
        }
    }
}
