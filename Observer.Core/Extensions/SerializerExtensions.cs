using Newtonsoft.Json;

namespace Observer.Core.Extensions
{
    public static class SerializerExtensions
    {
        public static string Serialize<T>(this T obj) => JsonConvert.SerializeObject(obj);
        public static T Deserialize<T>(this string serialized) => JsonConvert.DeserializeObject<T>(serialized);
    }
}
