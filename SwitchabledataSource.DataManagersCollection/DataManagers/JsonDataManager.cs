using Newtonsoft.Json;
using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataManagerCollection.DataManagers;

public class JsonDataManager<T> : IDataManager<T>
{
    private readonly string _filePath;

    public JsonDataManager(string filePath)
    {
        _filePath = filePath;
    }


    public void Save(IList<T> DataList)
    {
        string json = JsonConvert.SerializeObject(DataList);
        File.WriteAllText(_filePath, json);
    }

    public IList<T> ReadList()
    {
        try
        {
            string json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<IList<T>>(json) ?? new List<T>();
        }
        catch (FileNotFoundException)
        {
            return new List<T>();
        }
    }

    public T ReadObject()
    {
        string json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<IList<T>>(json)[0] ?? default!;
    }

    public void Release()
    {
        throw new NotSupportedException();
    }
}


