using Model;
using System.Drawing;
using System.Security.Authentication.ExtendedProtection;
using System.Xml.Linq;
namespace TestPlant
{
    [TestClass]
    public sealed class PlantTest
    {
        [TestMethod]
        public void DefaultConstructor_SetDefaultId()
        {
            // Arrange
            IdNumber.countOfItem = 0;
            int expectedId = IdNumber.countOfItem;

            // Act
            Plant plant = new Plant();
            int actualId = plant.idOfPlants.Number;

            // Assert
            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void DefaultConstructor_SetDefaultName()
        {
            // Arrange
            string expectedName = $"Растение #{Plant.countOfPlants + 1}";

            // Act
            Plant plant = new Plant();
            string actualName = plant.Name;

            // Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void DefaultConstructor_SetDefaultColor()
        {
            // Arrange
            string expectedColor = $"Цвет {Plant.countOfPlants + 1}";

            // Act
            Plant plant = new Plant();
            string actualColor = plant.Color;

            // Assert
            Assert.AreEqual(expectedColor, actualColor);
        }

        [TestMethod]
        public void ConstructorWithParams_SetId()
        {
            // Arrange
            int expectedId = 12;

            // Act
            Plant plant = new Plant("Роза", "Красный", 12);
            int actualId = plant.idOfPlants.Number;

            // Assert
            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void ConstructorWithParams_SetName()
        {
            // Arrange
            string expectedName = "Роза";

            // Act
            Plant plant = new Plant("Роза", "Красный", 12);
            string actualName = plant.Name;

            // Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void ConstructorWithParams_SetColor()
        {
            // Arrange
            string expectedColor = "Красный";

            // Act
            Plant plant = new Plant("Роза", "Красный", 12);
            string actualColor = plant.Color;

            // Assert
            Assert.AreEqual(expectedColor, actualColor);
        }

        [TestMethod]
        public void CopyConstructor_CopiesName()
        {
            // Arrange
            Plant original = new Plant("Тюльпан", "Жёлтый", 12);
            string expectedName = "Тюльпан";

            // Act
            Plant copy = new Plant(original);
            string actualName = copy.Name;

            // Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void CopyConstructor_CopiesColor()
        {
            // Arrange
            Plant original = new Plant("Тюльпан", "Жёлтый", 12);
            string expectedColor = "Жёлтый";

            // Act
            Plant copy = new Plant(original);
            string actualColor = copy.Color;

            // Assert
            Assert.AreEqual(expectedColor, actualColor);
        }

        // Тесты для свойств
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Name_EmptyString_ThrowsException()
        {
            // Arrange
            Plant plant = new Plant("", "Красный", 12);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Color_EmptyString_ThrowsException()
        {
            // Arrange
            Plant plant = new Plant("Роза", "", 12);
        }

        // Тесты для методов
        [TestMethod]
        public void Show_NoVirtual()
        {
            // Arrange
            string[] expectedArray = ["ID", "12", "Name", "Роза", "Color", "Красный"];
            Plant plant = new Plant("Роза", "Красный", 12);

            // Act
            string[] result = plant.Show();

            // Assert
            CollectionAssert.AreEqual(expectedArray, result);
        }

        [TestMethod]
        public void Show_Virtual()
        {
            // Arrange
            string[] expectedArray = ["Name", "Роза", "Color", "Красный"];
            Plant plant = new Plant("Роза", "Красный", 12);

            // Act
            string[] result = plant.ShowNoVirtual();

            // Assert
            CollectionAssert.AreEqual(expectedArray, result);
        }

        [TestMethod]
        public void Init_SetValues()
        {
            Plant tree = new Plant();
            string newName = "Берёза";
            string newColor = "Белый";

            tree.Init(newName, newColor);

            Assert.AreEqual(newName, tree.Name);
            Assert.AreEqual(newColor, tree.Color);
        }


        [TestMethod]
        public void RandomInit_SetRandomName()
        {
            // Arrange
            Plant plant = new Plant("Роза", "Красный", 12);

            // Act
            plant.RandomInit();
            string actualName = plant.Name;

            // Assert
            CollectionAssert.Contains(Plant.ARROFNAME, actualName);
        }

        [TestMethod]
        public void RandomInit_SetRandomColor()
        {
            // Arrange
            Plant plant = new Plant("Роза", "Красный", 12);

            // Act
            plant.RandomInit();
            string actualColor = plant.Color;

            // Assert
            CollectionAssert.Contains(Plant.ARROFCOLOR, actualColor);
        }

        [TestMethod]
        public void CompareTo_EqualsName_ReturnsZero()
        {
            // Arrange
            Plant plant1 = new Plant("Роза", "Красный", 12);
            Plant plant2 = new Plant("Роза", "Белый", 12);

            // Act
            int result = plant1.CompareTo(plant2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareTo_Less_ReturnsMinus1()
        {
            // Arrange
            Plant plant1 = new Plant("Дуб", "Зелёный", 12);
            Plant plant2 = new Plant("Роза", "Красный", 12);

            // Act
            int result = plant1.CompareTo(plant2);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CompareTo_More_Returns1()
        {
            // Arrange
            Plant plant2 = new Plant("Дуб", "Зелёный", 12);
            Plant plant1 = new Plant("Роза", "Красный", 12);

            // Act
            int result = plant1.CompareTo(plant2);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Equals_EqualsValues_ReturnsTrue()
        {
            // Arrange
            Plant plant1 = new Plant("Роза", "Красный", 1001);
            Plant plant2 = new Plant("Роза", "Красный", 1002);

            // Act
            bool result = plant1.Equals(plant2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            // Arrange
            Plant plant1 = new Plant("Роза", "Красный", 1001);
            Plant plant2 = new Plant("Тюльпан", "Жёлтый", 1002);

            // Act
            bool result = plant1.Equals(plant2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeepClone_Item()
        {
            // Arrange
            Plant original = new Plant("Роза", "Красный", 1001);

            // Act
            Plant clone = (Plant)original.Clone();
            

            // Assert
            Assert.AreEqual(original, clone);
        }

        [TestMethod]
        public void Clone_CreatesIndependentId()
        {
            // Arrange
            Plant original = new Plant("Роза", "Красный", 1001);

            // Act
            Plant clone = (Plant)original.Clone();
            original.idOfPlants.Number = 2000;
            int cloneId = clone.idOfPlants.Number;

            // Assert
            Assert.AreEqual(1001, cloneId);
        }

        [TestMethod]
        public void ShallowCopy_CopiesName()
        {
            // Arrange
            Plant original = new Plant("Роза", "Красный", 1001);

            // Act
            Plant shallowCopy = original.ShallowCopy();
            
            // Assert
            Assert.AreEqual(original, shallowCopy);
        }

        [TestMethod]
        public void ShallowCopy_SharesIdReference()
        {
            // Arrange
            Plant original = new Plant("Роза", "Красный", 1001);

            // Act
            Plant shallowCopy = original.ShallowCopy();
            original.idOfPlants.Number = 2000;
            int copyId = shallowCopy.idOfPlants.Number;

            // Assert
            Assert.AreEqual(2000, copyId);
        }

        [TestMethod]
        public void GetCountOfItem_IncrementsWithNewPlant()
        {
            // Arrange
            uint expectedCount = Plant.countOfPlants+1;

            // Act
            Plant plant = new Plant("Роза", "Красный", 1001);
            uint actualCount = Plant.GetCountOfItem();

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
