using Model;

namespace TestPlant;

[TestClass]
public class TreeTest
{
    // ����� ��� �������������
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
        Tree tree = new Tree("���", "������", 200, 1);
        int actualHeight = tree.Height;
        // Assert
        Assert.AreEqual(expectedHeight, actualHeight);
    }

    [TestMethod]
    public void CopyConstructor_CopiesHeight()
    {
        // Arrange
        Tree original = new Tree("�����", "������", 150, 1);
        // Act
        Tree copy = new Tree(original);
        // Assert
        Assert.AreEqual(original.Height, copy.Height);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Height_BigHeight_ThrowsArgumentException()
    {
        new Tree("���", "������", 1001, 1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Height_NegativeHeight_ThrowsArgumentException()
    {
        new Tree("���", "������", -1, 1);
    }

    // ����� ��� Show
    [TestMethod]
    public void Show_Virtual()
    {
        Tree tree = new Tree("���", "�������", 300, 1);
        string[] expected = { "ID", "1", "Name", "���", "Color", "�������", "Height", "300" };

        string[] result = tree.Show();

        CollectionAssert.AreEqual(expected, result);
    }

    // ����� ��� ShowNoVirtual
    [TestMethod]
    public void Show_NoVirtual()
    {
        Tree tree = new Tree("���", "������", 400, 1);
        string[] expected = { "Name", "���", "Color", "������", "Height", "400" };

        string[] result = tree.ShowNoVirtual();

        CollectionAssert.AreEqual(expected, result);
    }

    // ����� ��� Init
    [TestMethod]
    public void Init_SetValues()
    {
        Tree tree = new Tree();
        string newName = "�����";
        string newColor = "�����";
        int newHeight = 250;

        tree.Init(newName, newColor, newHeight);

        Assert.AreEqual(newName, tree.Name);
        Assert.AreEqual(newColor, tree.Color);
        Assert.AreEqual(newHeight, tree.Height);
    }


    // ����� ��� RandomInit
    [TestMethod]
    public void RandomInit_SetRandomValues()
    {
        Tree tree = new Tree();
        tree.RandomInit();

        CollectionAssert.Contains(Tree.ARROFTREES, tree.Name);
        CollectionAssert.Contains(Plant.ARROFCOLOR, tree.Color);
        Assert.IsTrue(tree.Height >= 1 && tree.Height < 1001);
    }

    // ����� ��� Clone
    [TestMethod]
    public void Clone_ReturnsDeepCopy()
    {
        Tree original = new Tree("���", "������", 600, 1);
        Tree clone = original.Clone();

        Assert.AreEqual(original, clone);
        Assert.IsFalse(ReferenceEquals(original, clone));
    }

    // ����� ��� Equals
    [TestMethod]
    public void Equals_EqualsValues_ReturnsTrue()
    {
        Tree tree1 = new Tree("������", "������", 700, 1);
        Tree tree2 = new Tree("������", "������", 700, 1);

        Assert.IsTrue(tree1.Equals(tree2));
    }

    [TestMethod]
    public void Equals_DifferentHeight_ReturnsFalse()
    {
        Tree tree1 = new Tree("����", "������", 700, 1);
        Tree tree2 = new Tree("����", "������", 800, 1);

        Assert.IsFalse(tree1.Equals(tree2));
    }

    // ����� ��� GetCountOfItem
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

