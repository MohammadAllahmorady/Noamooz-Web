using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Noamooz.Web.Infrastructure
{
    public static class MyExtensionMethods
    {
        public static int ConvertToInt(this string values)
        {
            return int.Parse(values);
        }

        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data == null ? default(T) : JsonConvert.DeserializeObject<T>(data);
        }
    }
}
