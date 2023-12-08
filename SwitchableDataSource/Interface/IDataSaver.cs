namespace SwitchableDataSource.Interface;

/// <summary>
/// Defines the contract for classes responsible for saving data of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of data to be saved.</typeparam>
public interface IDataSaver<T>
{
    /// <summary>
    /// Flushes the provided data list, overwriting any existing data.
    /// </summary>
    /// <param name="DataList">The list of data to be saved, replacing existing data.</param>
    void Save(IList<T> DataList);

    /// <summary>
    /// Appends the provided data list to the existing data.
    /// </summary>
    /// <param name="DataList">The list of data to be appended.</param>
    void Append(IList<T> DataList);

    /// <summary>
    /// Appends a single piece of data to the existing data.
    /// </summary>
    /// <param name="Data">The data to be appended.</param>
    void Append(T Data);
}
