using Model;

namespace TestPlant;

[TestClass]
public class TreeTest
{
    // Тесты для конструкторов
    [TestMethod]

    public void DefaultConstructor_SetDefaultHeight()
    {
        // Arrange
        int expectedHeight = 100;

        // Act
        Tree plant = new Tree();
        int actualHeight = plant.Height;

        // Assert
        Assert.AreEqual(expectedHeight, actualHeight);
    }

    [TestMethod]
    public void ConstructorWithParams_SetHeight()
    {
        // Arrange
        int expectedHeight = 200;
        // Act
        Tree tree = new Tree("Дуб", "Зелёный", 200, 1);
        int actualHeight = tree.Height;
        // Assert
        Assert.AreEqual(expectedHeight, actualHeight);
    }

    [TestMethod]
    public void CopyConstructor_CopiesHeight()
    {
        // Arrange
        Tree original = new Tree("Сосна", "Зелёный", 150, 1);
        // Act
        Tree copy = new Tree(original);
        // Assert
        Assert.AreEqual(original.Height, copy.Height);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Height_BigHeight_ThrowsArgumentException()
    {
        new Tree("Дуб", "Зелёный", 1001, 1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Height_NegativeHeight_ThrowsArgumentException()
    {
        new Tree("Дуб", "Зелёный", -1, 1);
    }

    // Тесты для Show
    [TestMethod]
    public void Show_Virtual()
    {
        Tree tree = new Tree("Клён", "Красный", 300, 1);
        string[] expected = { "ID", "1", "Name", "Клён", "Color", "Красный", "Height", "300" };

        string[] result = tree.Show();

        CollectionAssert.AreEqual(expected, result);
    }

    // Тесты для ShowNoVirtual
    [TestMethod]
    public void Show_NoVirtual()
    {
        Tree tree = new Tree("Ель", "Зелёный", 400, 1);
        string[] expected = { "Name", "Ель", "Color", "Зелёный", "Height", "400" };

        string[] result = tree.ShowNoVirtual();

        CollectionAssert.AreEqual(expected, result);
    }

    // Тесты для Init
    [TestMethod]
    public void Init_SetValues()
    {
        Tree tree = new Tree();
        string newName = "Берёза";
        string newColor = "Белый";
        int newHeight = 250;

        tree.Init(newName, newColor, newHeight);

        Assert.AreEqual(newName, tree.Name);
        Assert.AreEqual(newColor, tree.Color);
        Assert.AreEqual(newHeight, tree.Height);
    }


    // Тесты для RandomInit
    [TestMethod]
    public void RandomInit_SetRandomValues()
    {
        Tree tree = new Tree();
        tree.RandomInit();

        CollectionAssert.Contains(Tree.ARROFTREES, tree.Name);
        CollectionAssert.Contains(Plant.ARROFCOLOR, tree.Color);
        Assert.IsTrue(tree.Height >= 1 && tree.Height < 1001);
    }

    // Тесты для Clone
    [TestMethod]
    public void Clone_ReturnsDeepCopy()
    {
        Tree original = new Tree("Ива", "Зелёный", 600, 1);
        Tree clone = original.Clone();

        Assert.AreEqual(original, clone);
        Assert.IsFalse(ReferenceEquals(original, clone));
    }

    // Тесты для Equals
    [TestMethod]
    public void Equals_EqualsValues_ReturnsTrue()
    {
        Tree tree1 = new Tree("Тополь", "Зелёный", 700, 1);
        Tree tree2 = new Tree("Тополь", "Зелёный", 700, 1);

        Assert.IsTrue(tree1.Equals(tree2));
    }

    [TestMethod]
    public void Equals_DifferentHeight_ReturnsFalse()
    {
        Tree tree1 = new Tree("Липа", "Зелёный", 700, 1);
        Tree tree2 = new Tree("Липа", "Зелёный", 800, 1);

        Assert.IsFalse(tree1.Equals(tree2));
    }

    // Тесты для GetCountOfItem
    [TestMethod]
    public void GetCountOfItem_ReturnsCorrectCount()
    {
        Tree.countOfTree = 0;
        Tree tree1 = new Tree();
        Tree tree2 = new Tree();

        uint count = Tree.GetCountOfItem();

        Assert.AreEqual(2u, count);
    }
}

