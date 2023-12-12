using SwitchableDataSource.DataManagers;
using SwitchableDataSource.Interface;
using SwitchableDataSource.MemoryInteraction;
using SwitchableDataSource.MemoryInteraction.Decorator.AutoSaver;

namespace SwitchableDataSource.Test;

public class AutoSaveInteraction
{
    private string testFilePath = "test.json";
    private AutoSaver<TestObject> JsonAutoSave;
    private int IdleTime = 2000;
    private int RateMil = 2000;

    [SetUp]
    public void Setup()
    {
        var dataManagerJson = new JsonDataManager<TestObject>(testFilePath);
        var jsonMemorization = new SimpleMemoryInteraction<TestObject>(dataManagerJson);
        JsonAutoSave = new AutoSaver<TestObject>(IdleTime, RateMil, jsonMemorization);
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(testFilePath))
        {
            File.Delete(testFilePath);
        }

        JsonAutoSave.Pause();
    }


    [Test]
    public void AutoSave_Test()
    {
        // Arrange
        var expectedList = new List<TestObject>();

        for (int i = 0; i < 10; i++)
        {
            expectedList.Add(new TestObject { Id = i, Name = "Test" + i });
        }

        // Act
        foreach (var t in expectedList)
            JsonAutoSave.AddOrModify(t);
        JsonAutoSave.Save();

        for (int i = 11; i < 20; i++)
        {
            var l = new TestObject { Id = i, Name = "Test" + i };
            expectedList.Add(l);
            JsonAutoSave.AddOrModify(l);
        }

        JsonAutoSave.Start();
        System.Threading.Thread.Sleep(RateMil + 2000);
        var actualList = JsonAutoSave.ReadList();

        // Assert
        Assert.That(actualList.Count, Is.EqualTo(expectedList.Count));
        Assert.IsTrue(expectedList.SequenceEqual(actualList));
    }
}