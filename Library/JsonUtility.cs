using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Library
{
    public class JsonUtility
    {
        public static T ParseToObject<T>(string json, bool isUpperCase = true)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return isUpperCase
                ? JsonConvert.DeserializeObject<T>(json, serializerSettings)
                : JsonConvert.DeserializeObject<T>(json);
        }

        public static string ParseToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
