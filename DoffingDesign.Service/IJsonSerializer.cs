namespace DoffingDesign.Service
{
    public interface IJsonSerializer
    {
        string Serializer(object obj);
        T Deserialize<T>(string json);
    }
}