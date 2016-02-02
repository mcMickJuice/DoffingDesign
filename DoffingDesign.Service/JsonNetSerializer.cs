using Newtonsoft.Json;

namespace DoffingDesign.Service
{
    public class JsonNetSerializer: IJsonSerializer
    {
        public string Serializer(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}