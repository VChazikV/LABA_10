using Model;

namespace TestPlant;

[TestClass]
public class FlowerTest
{

    // ����� ��� �������������
    [TestMethod]

    public void DefaultConstructor_SetDefaultSmell()
    {
        // Arrange
        string expectedSmell = "��� ������";

        // Act
        Flower plant = new Flower();
        string actualSmell = plant.Smell;

        // Assert
        Assert.AreEqual(expectedSmell, actualSmell);
    }

    [TestMethod]
    public void ConstructorWithParams_SetSmell()
    {
        // Arrange
        string expectedSmell = "�������";
        // Act
        Flower tree = new Flower("����", "�����", "�������", 1);
        string actualSmell = tree.Smell;
        // Assert
        Assert.AreEqual(expectedSmell, actualSmell);
    }

    [TestMethod]
    public void CopyConstructor_CopiesSmell()
    {
        // Arrange
        Flower original = new Flower("����", "�������", "�������", 1);
        // Act
        Flower copy = new Flower(original);
        // Assert
        Assert.AreEqual(original.Smell, copy.Smell);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Smell_EmptyString_ThrowsArgumentException()
    {
        new Flower("���", "������", "", 1);
    }


    // ����� ��� Show
    [TestMethod]
    public void Show_Virtual()
    {
        Flower tree = new Flower("����", "�������", "�������", 1);
        string[] expected = { "ID", "1", "Name", "����", "Color", "�������", "Smell", "�������" };

        string[] result = tree.Show();

        CollectionAssert.AreEqual(expected, result);
    }

    // ����� ��� ShowNoVirtual
    [TestMethod]
    public void Show_NoVirtual()
    {
        Flower tree = new Flower("����", "�������", "�������", 1);
        string[] expected = { "Name", "����", "Color", "�������", "Smell", "�������" };

        string[] result = tree.ShowNoVirtual();

        CollectionAssert.AreEqual(expected, result);
    }

    // ����� ��� Init
    [TestMethod]
    public void Init_SetValuesCorrectly()
    {
        Flower tree = new Flower();
        string newName = "�����";
        string newColor = "�����";
        string newSmell = "��������";

        tree.Init(newName, newColor, newSmell);

        Assert.AreEqual(newName, tree.Name);
        Assert.AreEqual(newColor, tree.Color);
        Assert.AreEqual(newSmell, tree.Smell);
    }


    // ����� ��� RandomInit
    [TestMethod]
    public void RandomInit_SetRandomValues()
    {
        Flower tree = new Flower();
        tree.RandomInit();

        CollectionAssert.Contains(Flower.ARROFSMELL, tree.Smell);
        CollectionAssert.Contains(Flower.ARROFFLOWERS, tree.Name);
    }

    // ����� ��� Clone
    [TestMethod]
    public void Clone_ReturnsDeepCopy()
    {
        Flower original = new Flower("����", "������", "�������", 1);
        Flower clone = original.Clone();

        Assert.AreEqual(original, clone);
        Assert.IsFalse(ReferenceEquals(original, clone));
    }

    // ����� ��� Equals
    [TestMethod]
    public void Equals_EqualsValues_ReturnsTrue()
    {
        Flower tree1 = new Flower("����", "������", "�������", 1);
        Flower tree2 = new Flower("����", "������", "�������", 1);

        Assert.IsTrue(tree1.Equals(tree2));
    }

    [TestMethod]
    public void Equals_DifferentHeight_ReturnsFalse()
    {
        Flower tree1 = new Flower("����", "������", "������", 1);
        Flower tree2 = new Flower("����", "������", "�������", 1);

        Assert.IsFalse(tree1.Equals(tree2));
    }

    // ����� ��� GetCountOfItem
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
