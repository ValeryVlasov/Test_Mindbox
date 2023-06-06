using Microsoft.VisualBasic;

namespace Geometry
{
    public class Triangle
    {
        public double EdgeA { get; }
        public double EdgeB { get; }
        public double EdgeC { get; }

        public Triangle(double _edgeA, double _edgeB, double _edgeC)
        {
            if ( _edgeA < 0 || _edgeB < 0 || _edgeC < 0) { throw new ArgumentException("The length of each side must be greater then zero"); }



            EdgeA = _edgeA;
            EdgeB = _edgeB;
            EdgeC = _edgeC;
        }

        public bool IsRightTriangle()
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
