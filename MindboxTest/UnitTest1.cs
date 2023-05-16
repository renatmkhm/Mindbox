using NUnit.Framework;
using AreaCalculation;

namespace AreaCalculation.Tests
{
    [TestFixture]
    public class ShapeTests
    {
        [Test]
        public void Circle_CalculateArea_ValidRadius_ReturnsCorrectArea()
        {
            // Arrange
            double radius = 3;
            double expectedArea = 28.274333882308138;
            Circle circle = new Circle(radius);

            // Act
            double actualArea = circle.CalculateArea();

            // Assert
            Assert.That(actualArea, Is.EqualTo(expectedArea));
        }

        [Test]
        public void Circle_CalculateArea_ZeroRadius_ThrowsArgumentException()
        {
            // Arrange
            double radius = 0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }

        [Test]
        public void Triangle_CalculateArea_ValidSides_ReturnsCorrectArea()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            double expectedArea = 6;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            double actualArea = triangle.CalculateArea();

            // Assert
            Assert.That(actualArea, Is.EqualTo(expectedArea));
        }

        [Test]
        public void Triangle_CalculateArea_InvalidSides_ThrowsArgumentException()
        {
            // Arrange
            double sideA = 1;
            double sideB = 2;
            double sideC = 10;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [Test]
        public void Triangle_IsRightTriangle_RightTriangleSides_ReturnsTrue()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            bool isRightTriangle = triangle.IsRightTriangle();

            // Assert
            Assert.IsTrue(isRightTriangle);
        }

        [Test]
        public void Triangle_IsRightTriangle_NonRightTriangleSides_ReturnsFalse()
        {
            // Arrange
            double sideA = 2;
            double sideB = 3;
            double sideC = 4;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            bool isRightTriangle = triangle.IsRightTriangle();

            // Assert
            Assert.IsFalse(isRightTriangle);
        }
    }
}
