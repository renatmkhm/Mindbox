namespace AreaCalculation
{
    public interface IShape
    {
        double CalculateArea();
    }

    public abstract class ShapeBase : IShape
    {
        public virtual double CalculateArea()
        {
            throw new NotImplementedException("CalculateArea() method not implemented.");
        }
    }

    public class Circle : ShapeBase
    {
        private double radius;

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius should be a positive value.");

            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }

    public class Triangle : ShapeBase
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (!IsTriangleValid(sideA, sideB, sideC))
                throw new ArgumentException("Invalid triangle sides.");

            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        private bool IsTriangleValid(double sideA, double sideB, double sideC)
        {
            bool positive = sideA > 0 || sideB > 0 || sideC > 0;
            bool valid = sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA;

            return positive && valid;
        }

        public bool IsRightTriangle()
        {
            double[] sides = { sideA, sideB, sideC };
            Array.Sort(sides);

            double aSquared = Math.Pow(sides[0], 2);
            double bSquared = Math.Pow(sides[1], 2);
            double cSquared = Math.Pow(sides[2], 2);

            return Math.Abs(cSquared - (aSquared + bSquared)) < double.Epsilon;
        }

        public override double CalculateArea()
        {
            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiPerimeter *
                (semiPerimeter - sideA) *
                (semiPerimeter - sideB) *
                (semiPerimeter - sideC));

            return area;
        }
    }
}