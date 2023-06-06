using System.Security.Cryptography.X509Certificates;

namespace Geometry
{
    public class Circle : IFigure
    {
        public double Radius { get; }

        public Circle(double radius) {
            if (radius < 0)
                throw new ArgumentException("Invalid radius of circle", nameof(radius));
            Radius = radius;
        }

        public double GetSquare() { return Math.PI * Math.Pow(Radius, 2); }
    }
}