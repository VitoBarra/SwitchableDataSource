using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Test.Integration.Implementation;

public abstract class AbstractDataManagerTest
{
    protected abstract IDataManager<T> GetDataManager<T>();

    protected abstract void ClearFunction();


    [Test]
    public void Save_ReadList_ReturnSameAsSave()
    {
        // Arrange
        var jsonDataManager = GetDataManager<TestObject>();
        var expectedList = new List<TestObject> { new TestObject { Id = 1, Name = "Test1" }, new TestObject { Id = 2, Name = "Test2" } };

        // Act
        jsonDataManager.Save(expectedList);
        var actualList = jsonDataManager.ReadList();

        // Assert
        Assert.That(actualList.Count, Is.EqualTo(expectedList.Count));
        Assert.IsTrue(expectedList.SequenceEqual(actualList));
        ClearFunction();
    }

    [Test]
    public void Save_ReadObject_ReturnSameAsSave()
    {
        // Arrange
        var jsonDataManager = GetDataManager<TestObject>();
        var expectedObject = new TestObject { Id = 1, Name = "Test" };

        // Act
        jsonDataManager.Save(new List<TestObject> { expectedObject });
        var actualObject = jsonDataManager.ReadObject();

        // Assert
        Assert.That(actualObject, Is.EqualTo(expectedObject));
        ClearFunction();
    }
}
