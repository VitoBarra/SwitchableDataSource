
namespace SwitchableDataSource.Interface;

public interface IDataReader<T>
{
     IList<T> ReadList();
     T ReadObject();

}