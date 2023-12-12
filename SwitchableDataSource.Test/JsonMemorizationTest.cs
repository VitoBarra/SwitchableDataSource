using SwitchableDataSource.DataManagers;
using SwitchableDataSource.MemoryInteraction.Decorator.AutoSaver;

namespace SwitchableDataSource.Test;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[TestFixture]
public class JsonMemorizationTest
{
    private string testFilePath = "test.json";
    private JsonDataManager<TestObject> _jsonDataManager;

    [SetUp]
    public void Setup()
    {
        _jsonDataManager = new JsonDataManager<TestObject>(testFilePath);
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(testFilePath))
        {
            File.Delete(testFilePath);
        }
    }

    [Test]
    public void Save_ReadList_Test()
    {
        // Arrange
        var expectedList = new List<TestObject> { new TestObject { Id = 1, Name = "Test1" }, new TestObject { Id = 2, Name = "Test2" } };

        // Act
        _jsonDataManager.Save(expectedList);
        var actualList = _jsonDataManager.ReadList();

        // Assert
        Assert.That(actualList.Count, Is.EqualTo(expectedList.Count));
        Assert.IsTrue(expectedList.SequenceEqual(actualList));
    }

    [Test]
    public void Save_ReadObject_Test()
    {
        // Arrange
        var expectedObject = new TestObject { Id = 1, Name = "Test" };

        // Act
        _jsonDataManager.Save(new List<TestObject> { expectedObject });
        var actualObject = _jsonDataManager.ReadObject();

        // Assert
        Assert.That(actualObject, Is.EqualTo(expectedObject));
    }

    [Test]
    public void Append_List_ThrowsNotSupportedException()
    {
        // Arrange
        IList<TestObject> dataList = new List<TestObject> { new TestObject { Id = 1, Name = "Test1" }, new TestObject { Id = 2, Name = "Test2" } };

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => _jsonDataManager.Append(dataList));
    }

    [Test]
    public void Append_SingleData_ThrowsNotSupportedException()
    {
        // Arrange
        var data = new TestObject { Id = 1, Name = "Test1" };

        // Act & Assert
        Assert.Throws<NotSupportedException>(() => _jsonDataManager.Append(data));
    }



}
