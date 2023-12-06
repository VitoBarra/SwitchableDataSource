
namespace SwitchableDataSource.Interface;

public interface IDataAppender<T>
{
    void Append(List<T> DataList);
    void Append(T Data);
}