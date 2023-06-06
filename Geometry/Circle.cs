using System.Security.Cryptography.X509Certificates;

namespace Geometry
{
    public class Circle : IFigure
    {
        public double Radius { get; }
        public const double eps = 1e-6;

        public Circle(double radius) {
            if (radius - eps < Constants.Accuracy)
                throw new ArgumentException("Invalid radius of circle", nameof(radius));
            Radius = radius;
        }

        public double GetSquare() { return Math.PI * Math.Pow(Radius, 2); }
    }
}