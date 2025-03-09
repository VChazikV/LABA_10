using Model;

namespace TestPlant;

[TestClass]
public class FlowerTest
{
    [TestClass]
    public class TreeTests
    {
        [TestInitialize]
        public void Setup()
        {
            Flower.countOfFlower = 0;
        }

        // Тесты для конструкторов
        [TestMethod]

        public void DefaultConstructor_SetDefaultHeight()
        {
            // Arrange
            string expectedSmell = "Нет запаха";

            // Act
            Flower plant = new Flower();
            string actualSmell = plant.Smell;

            // Assert
            Assert.AreEqual(expectedSmell, actualSmell);
        }

        [TestMethod]
        public void ConstructorWithParams_SetValuesCorrectly()
        {
            // Arrange
            string expectedSmell = "Сладкий";
            // Act
            Flower tree = new Flower("Роза", "Белая", "Сладкий", 1);
            string actualSmell = tree.Smell;
            // Assert
            Assert.AreEqual(expectedSmell, actualSmell);
        }

        [TestMethod]
        public void CopyConstructor_CopiesCorrectly()
        {
            // Arrange
            Flower original = new Flower("РОЗА", "Сладкий", "Сладкий", 1);
            // Act
            Flower copy = new Flower(original);
            // Assert
            Assert.AreEqual(original.Smell, copy.Smell);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_BigHeight_ThrowsArgumentException()
        {
            new Flower("Дуб", "Зелёный", "", 1);
        }


        // Тесты для Show
        [TestMethod]
        public void Show_ReturnsCorrectArray()
        {
            Flower tree = new Flower("Роза", "Красный", "Вкусная", 1);
            string[] expected = { "ID", "1", "Name", "Роза", "Color", "Красный", "Smell", "Вкусная" };

            string[] result = tree.Show();

            CollectionAssert.AreEqual(expected, result);
        }

        // Тесты для ShowNoVirtual
        [TestMethod]
        public void ShowNoVirtual_ReturnsCorrectArray()
        {
            Flower tree = new Flower("Роза", "Красный", "Вкусная", 1);
            string[] expected = { "Name", "Роза", "Color", "Красный", "Smell", "Вкусная" };

            string[] result = tree.ShowNoVirtual();

            CollectionAssert.AreEqual(expected, result);
        }

        // Тесты для Init
        [TestMethod]
        public void Init_SetValuesCorrectly()
        {
            Flower tree = new Flower();
            string newName = "Берёза";
            string newColor = "Белый";
            string newSmell = "Солидный";

            tree.Init(newName, newColor, newSmell);

            Assert.AreEqual(newName, tree.Name);
            Assert.AreEqual(newColor, tree.Color);
            Assert.AreEqual(newSmell, tree.Smell);
        }


        // Тесты для RandomInit
        [TestMethod]
        public void RandomInit_SetRandomValuesWithinRange()
        {
            Flower tree = new Flower();
            tree.RandomInit();

            CollectionAssert.Contains(Flower.ARROFSMELL, tree.Smell);
            CollectionAssert.Contains(Flower.ARROFFLOWERS, tree.Name);
        }

        // Тесты для Clone
        [TestMethod]
        public void Clone_ReturnsDeepCopy()
        {
            Flower original = new Flower("РОЗА", "Зелёный", "Сладкий", 1);
            Flower clone = original.Clone();

            Assert.AreEqual(original.Name, clone.Name);
            Assert.AreEqual(original.Color, clone.Color);
            Assert.AreEqual(original.Smell, clone.Smell);
            Assert.IsFalse(ReferenceEquals(original, clone));
        }

        // Тесты для Equals
        [TestMethod]
        public void Equals_SameValues_ReturnsTrue()
        {
            Flower tree1 = new Flower("РОЗА", "Зелёный", "Сладкий", 1);
            Flower tree2 = new Flower("РОЗА", "Зелёный", "Сладкий", 1);

            Assert.IsTrue(tree1.Equals(tree2));
        }

        [TestMethod]
        public void Equals_DifferentHeight_ReturnsFalse()
        {
            Flower tree1 = new Flower("РОЗА", "Зелёный", "Садкий", 1);
            Flower tree2 = new Flower("РОЗА", "Зелёный", "Сладкий", 1);

            Assert.IsFalse(tree1.Equals(tree2));
        }

        // Тесты для GetCountOfItem
        [TestMethod]
        public void GetCountOfItem_ReturnsCorrectCount()
        {
            Flower.countOfFlower = 0;
            Flower tree1 = new Flower();
            Flower tree2 = new Flower();

            uint count = Flower.GetCountOfItem();

            Assert.AreEqual(2u, count);
        }
    }
}
