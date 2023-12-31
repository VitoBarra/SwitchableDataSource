﻿using SwitchableDataSource.DataInteraction;
using SwitchableDataSource.MemoryInteraction.Decorator.AutoSaver;
using SwitchableDataSource.Test.MemorizationStrategy;

namespace SwitchableDataSource.Test.Decorator;

[TestFixture(Category = "Unit")]
public class AutoSaveInteraction
{
    private int IdleTime = 2000;
    private int RateMil = 2000;

    public AutoSaver<TestObject> GetAutoSaver()
    {
        var dataManager = new FakeDataManager<TestObject>();
        var memorization = new CachedDataInteraction<TestObject>(dataManager);
        return new AutoSaver<TestObject>(memorization, IdleTime, RateMil);
    }

    public void StopAutoSaver<T>(AutoSaver<T> autoSaver)
    {
        autoSaver.SaveAndClose();
    }


    [Test]
    public void AddOrModify_ShouldSaveAfterIdleTime()
    {
        // Arrange
        var autoSave = GetAutoSaver();
        var expectedList = new List<TestObject>();

        for (int i = 0; i < 10; i++)
        {
            expectedList.Add(new TestObject { Id = i, Name = "Test" + i });
        }

        // Act
        foreach (var t in expectedList)
            autoSave.AddOrModify(t);

        autoSave.SaveToSource();

        for (int i = 11; i < 20; i++)
        {
            var l = new TestObject { Id = i, Name = "Test" + i };
            expectedList.Add(l);
            autoSave.AddOrModify(l);
        }

        autoSave.Start();
        System.Threading.Thread.Sleep(RateMil + 2000);
        var actualList = autoSave.ReadFromSource();

        // Assert
        Assert.That(actualList.Count, Is.EqualTo(expectedList.Count));
        Assert.IsTrue(expectedList.SequenceEqual(actualList));

        StopAutoSaver(autoSave);
    }
}