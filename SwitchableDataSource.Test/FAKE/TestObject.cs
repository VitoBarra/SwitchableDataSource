namespace SwitchableDataSource.Test;

public class TestObject
{
    public int Id { get; set; } = -1;
    public string Name { get; set; } = "";

    public override bool Equals(object? obj)
    {
        if (obj is TestObject to)
        {
            return this.Id == to.Id && this.Name == to.Name;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}
