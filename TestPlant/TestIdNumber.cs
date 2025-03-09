namespace TestPlant;
using Model;

[TestClass]
public class TestIdNumber
{
    [TestClass]
    public class IdNumberTests
    {

        // Тесты для конструктора с параметром
        [TestMethod]
        public void Constructor_WithValidNumber_SetsNumberCorrectly()
        {
            // Arrange
            IdNumber.countOfItem = 0;
            int expectedNumber = 5;

            // Act
            IdNumber idNumber = new IdNumber(5);

            // Assert
            Assert.AreEqual(expectedNumber, idNumber.Number);
            Assert.AreEqual(1, IdNumber.countOfItem);
        }

        // Тесты для конструктора по умолчанию
        [TestMethod]
        public void DefaultConstructor_SetsNumberToCountOfItem()
        {
            // Arrange
            IdNumber.countOfItem = 0;
            IdNumber idNumber1 = new IdNumber(); // countOfItem = 0
            IdNumber idNumber2 = new IdNumber(); // countOfItem = 1

            // Assert
            Assert.AreEqual(0, idNumber1.Number);
            Assert.AreEqual(1, idNumber2.Number);
        }

        // Тесты для свойства Number
        [TestMethod]
        public void NumberProperty_SetValidValue_SetsCorrectly()
        {
            // Arrange
            IdNumber idNumber = new IdNumber(1);
            int expectedNumber = 10;

            // Act
            idNumber.Number = 10;

            // Assert
            Assert.AreEqual(expectedNumber, idNumber.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NumberProperty_SetNegativeValue_ThrowsArgumentException()
        {
            // Arrange
            IdNumber idNumber = new IdNumber(-12);

            // Act & Assert
            
        }

        // Тесты для метода Equals
        [TestMethod]
        public void Equals_SameNumber_ReturnsTrue()
        {
            // Arrange
            IdNumber idNumber1 = new IdNumber(5);
            IdNumber idNumber2 = new IdNumber(5);

            // Act & Assert
            Assert.IsTrue(idNumber1.Equals(idNumber2));
        }

        [TestMethod]
        public void Equals_DifferentNumber_ReturnsFalse()
        {
            // Arrange
            IdNumber idNumber1 = new IdNumber(5);
            IdNumber idNumber2 = new IdNumber(6);

            // Act & Assert
            Assert.IsFalse(idNumber1.Equals(idNumber2));
        }

        [TestMethod]
        public void Equals_NullObject_ReturnsFalse()
        {
            // Arrange
            IdNumber idNumber = new IdNumber(5);

            // Act & Assert
            Assert.IsFalse(idNumber.Equals(null));
        }

        [TestMethod]
        public void Equals_DifferentType_ReturnsFalse()
        {
            // Arrange
            IdNumber idNumber = new IdNumber(5);
            object other = new object();

            // Act & Assert
            Assert.IsFalse(idNumber.Equals(other));
        }

        // Тесты для ToString
        [TestMethod]
        public void ToString_ReturnsNumberAsString()
        {
            // Arrange
            IdNumber idNumber = new IdNumber(42);
            string expectedString = "42";

            // Act
            string result = idNumber.ToString();

            // Assert
            Assert.AreEqual(expectedString, result);
        }
    }
}
