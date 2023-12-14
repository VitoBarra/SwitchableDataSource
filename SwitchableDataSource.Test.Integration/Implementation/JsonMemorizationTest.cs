using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using SwitchableDataSource.DataManagerCollection.DataManagers;


namespace SwitchableDataSource.Test.Integration;

[TestFixture]
public class JsonMemorizationTest
{
    private string testFilePath = "test.json";

    private JsonDataManager<T> GetJsonDataManager<T>()
    {
        return new JsonDataManager<T>(testFilePath);
    }

    private void RemoveFileFromDisk()
    {
        if (File.Exists(testFilePath))
        {
            File.Delete(testFilePath);
        }
    }

    [Test]
    public void Save_ReadList_ReturnSameAsSave()
    {
        // Arrange
        var jsonDataManager = GetJsonDataManager<TestObject>();
        var expectedList = new List<TestObject> { new TestObject { Id = 1, Name = "Test1" }, new TestObject { Id = 2, Name = "Test2" } };

        // Act
        jsonDataManager.Save(expectedList);
        var actualList = jsonDataManager.ReadList();

        // Assert
        Assert.That(actualList.Count, Is.EqualTo(expectedList.Count));
        Assert.IsTrue(expectedList.SequenceEqual(actualList));
        RemoveFileFromDisk();
    }

    [Test]
    public void Save_ReadObject_ReturnSameAsSave()
    {
        // Arrange
        var jsonDataManager = GetJsonDataManager<TestObject>();
        var expectedObject = new TestObject { Id = 1, Name = "Test" };

        // Act
        jsonDataManager.Save(new List<TestObject> { expectedObject });
        var actualObject = jsonDataManager.ReadObject();

        // Assert
        Assert.That(actualObject, Is.EqualTo(expectedObject));
        RemoveFileFromDisk();
    }

    [Test]
    public void Append_List_ThrowsNotSupportedException()
    {
        // Arrange
        var jsonDataManager = GetJsonDataManager<TestObject>();
        IList<TestObject> dataList = new List<TestObject> { new TestObject { Id = 1, Name = "Test1" }, new TestObject { Id = 2, Name = "Test2" } };

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => jsonDataManager.Append(dataList));
        RemoveFileFromDisk();
    }

    [Test]
    public void Append_SingleData_ThrowsNotSupportedException()
    {
        // Arrange
        var jsonDataManager = GetJsonDataManager<TestObject>();
        var data = new TestObject { Id = 1, Name = "Test1" };

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => jsonDataManager.Append(data));
        RemoveFileFromDisk();
    }



}
