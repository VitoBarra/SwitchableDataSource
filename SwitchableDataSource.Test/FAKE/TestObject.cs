namespace SwitchableDataSource.Test;

public class TestObject
{
    public int Id { get; set; } = -1;
    public string Name { get; set; } = "";


    protected bool Equals(TestObject other)
    {
        return Id == other.Id && Name == other.Name;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (Id * 397) ^ Name.GetHashCode();
        }
    }
}