namespace Geometry
{
    public interface ITriangle : IFigure
    {
        double _edgeA { get; }
        double _edgeB { get; }
        double _edgeC { get; }

        bool IsRightTriangle { get; }
    }
}
