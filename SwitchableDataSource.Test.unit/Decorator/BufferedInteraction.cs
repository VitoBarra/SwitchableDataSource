using SwitchableDataSource.DataInteraction;
using SwitchableDataSource.DataInteraction.Decorator.Memory;
using SwitchableDataSource.Test.MemorizationStrategy;

namespace SwitchableDataSource.Test.Decorator;

[TestFixture(Category = "Unit")]
public class BufferedInteractionTest
{
    public BufferedInteraction<TestObject> GetBufferedInteraction()
    {
        var dataManager = new FakeDataManager<TestObject>();
        var memorization = new CachedDataInteraction<TestObject>(dataManager);
        return new BufferedInteraction<TestObject>(memorization,20);
    }

 // [Test]
 //    public void AddOrModify_AddElement_ElementAddedToBuffer()
 //    {
 //        // Arrange
 //        var bufferedInteraction = GetBufferedInteraction();
 //        var testObject = new TestObject(){Id = 1, Name = "test"};
 //
 //        // Act
 //        bufferedInteraction.AddOrModify(testObject);
 //
 //        // Assert
 //        Assert.Equals(bufferedInteraction.GetObjectWhere(x=>x.Id==testObject.Id), testObject);
 //    }
 //
 //    [Test]
 //    public void SaveToSource_BufferNotEmpty_BufferSavedToSource()
 //    {
 //        // Arrange
 //        var bufferedInteraction = GetBufferedInteraction();
 //        var testObject = new TestObject();
 //        bufferedInteraction.AddOrModify(testObject);
 //
 //        // Act
 //        bufferedInteraction.SaveToSource();
 //
 //        // Assert
 //        Assert.IsEmpty(bufferedInteraction.UnSavedBuffer);
 //        Assert.Contains(testObject, bufferedInteraction.DataInteraction.ReadFromSource());
 //    }
 //
 //    [Test]
 //    public void GetObjectWhere_ObjectExistsInBuffer_ReturnsObjectFromBuffer()
 //    {
 //        // Arrange
 //        var bufferedInteraction = GetBufferedInteraction();
 //        var testObject = new TestObject();
 //        bufferedInteraction.AddOrModify(testObject);
 //
 //        // Act
 //        var result = bufferedInteraction.GetObjectWhere(obj => obj == testObject);
 //
 //        // Assert
 //        Assert.AreEqual(testObject, result);
 //    }
 //
 //    [Test]
 //    public void GetObjectWhere_ObjectNotInBuffer_ReturnsObjectFromSource()
 //    {
 //        // Arrange
 //        var bufferedInteraction = GetBufferedInteraction();
 //        var testObject = new TestObject();
 //        bufferedInteraction.DataInteraction.AddOrModify(testObject);
 //
 //        // Act
 //        var result = bufferedInteraction.GetObjectWhere(obj => obj == testObject);
 //
 //        // Assert
 //        Assert.AreEqual(testObject, result);
 //    }
 //
 //    [Test]
 //    public void ReadFromSource_BufferNotEmpty_ReturnsCombinedList()
 //    {
 //        // Arrange
 //        var bufferedInteraction = GetBufferedInteraction();
 //        var testObject = new TestObject();
 //        bufferedInteraction.AddOrModify(testObject);
 //
 //        // Act
 //        var result = bufferedInteraction.ReadFromSource();
 //
 //        // Assert
 //        Assert.Contains(testObject, result);
 //    }
    
}