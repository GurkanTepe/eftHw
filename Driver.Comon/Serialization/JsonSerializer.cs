using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Driver.Comon.Serialization
{
    public class JsonSerializer : ITextSerializer
    {
        public string Serialize(object obj)
        {
            var settings = GetSerializationSettings();
            return JsonConvert.SerializeObject(obj, settings);
        }

        public T Deserialize<T>(string value)
        {
            var settings = GetSerializationSettings();
            return JsonConvert.DeserializeObject<T>(value, settings);
        }

        public T Deserialize<T>(Stream stream)
        {
            var settings = GetSerializationSettings();
            var serializer = Newtonsoft.Json.JsonSerializer.CreateDefault(settings);
            using (var reader = new JsonTextReader(new StreamReader(stream, Encoding.UTF8))
            {
                CloseInput = true
            })
            {
                return serializer.Deserialize<T>(reader);
            }
        }

        public static JsonSerializerSettings GetSerializationSettings()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            return settings;
        }
    }
}
