using Model;
using System.Drawing;
using System.Xml.Linq;

namespace TestPlant;

[TestClass]
public class RoseTest
{
    // Тесты для конструкторов
    [TestMethod]

    public void DefaultConstructor_SetDefaultHasThrons()
    {
        // Arrange
        bool expectedHasThrons = false;

        // Act
        Rose plant = new Rose();
        bool actualSmell = plant.HasThorns;

        // Assert
        Assert.AreEqual(expectedHasThrons, actualSmell);
    }

    [TestMethod]
    public void ConstructorWithParams_SetHasThrons()
    {
        // Arrange
        bool expectedHasThrons = false;

        // Act
        Rose plant = new Rose("Роза", "Красный", "Сладкий", false, 12);
        bool actualSmell = plant.HasThorns;

        // Assert
        Assert.AreEqual(expectedHasThrons, actualSmell);
    }

    [TestMethod]
    public void CopyConstructor_CopiesHasThrons()
    {
        // Arrange
        Rose original = new Rose("РОЗА", "Сладкий", "Сладкий", true,  1);
        // Act
        Rose copy = new Rose(original);
        // Assert
        Assert.AreEqual(original.HasThorns, copy.HasThorns);
    }


    // Тесты для Show
    [TestMethod]
    public void Show_Virtual()
    {
        Rose tree = new Rose("Роза", "Красный", "Вкусная", true,  1);
        string[] expected = { "ID", "1", "Name", "Роза", "Color", "Красный", "Smell", "Вкусная", "Has Thorns", "True" };

        string[] result = tree.Show();

        CollectionAssert.AreEqual(expected, result);
    }

    // Тесты для ShowNoVirtual
    [TestMethod]
    public void Show_NoVirtual()
    {
        Rose tree = new Rose("Роза", "Красный", "Вкусная", true, 1);
        string[] expected = { "Name", "Роза", "Color", "Красный", "Smell", "Вкусная", "HasThorns", "True" };

        string[] result = tree.ShowNoVirtual();

        CollectionAssert.AreEqual(expected, result);
    }

    // Тесты для Init
    [TestMethod]
    public void Init_SetValuesCorrectly()
    {
        Rose tree = new Rose();
        string newName = "РОЗА";
        string newColor = "Белый";
        string newSmell = "Солидный";
        bool newHasThorns = false;

        tree.Init(newName, newColor, newSmell, newHasThorns);

        Assert.AreEqual(newName, tree.Name);
        Assert.AreEqual(newColor, tree.Color);
        Assert.AreEqual(newSmell, tree.Smell);
        Assert.AreEqual(newHasThorns, tree.HasThorns);
    }


    // Тесты для Clone
    [TestMethod]
    public void Clone_ReturnsDeepCopy()
    {
        Rose original = new Rose("РОЗА", "Зелёный", "Сладкий",true, 1);
        Rose clone = original.Clone();

        Assert.AreEqual(original, clone);
        Assert.IsFalse(ReferenceEquals(original, clone));
    }

    // Тесты для Equals
    [TestMethod]
    public void Equals_EqualsValues_ReturnsTrue()
    {
        Rose tree1 = new Rose("РОЗА", "Зелёный", "Сладкий", false, 1);
        Rose tree2 = new Rose("РОЗА", "Зелёный", "Сладкий", false, 1);

        Assert.IsTrue(tree1.Equals(tree2));
    }

    [TestMethod]
    public void Equals_DifferentHasThorns_ReturnsFalse()
    {
        Rose tree1 = new Rose("РОЗА", "Зелёный", "Сладкий", true, 1);
        Rose tree2 = new Rose("РОЗА", "Зелёный", "Сладкий", false, 1);

        Assert.IsFalse(tree1.Equals(tree2));
    }

    // Тесты для GetCountOfItem
    [TestMethod]
    public void GetCountOfItem_ReturnsCorrectCount()
    {
        Rose.countOfRose = 0;
        Rose tree1 = new Rose();
        Rose tree2 = new Rose();

        uint count = Rose.GetCountOfItem();

        Assert.AreEqual(2u, count);
    }
}
