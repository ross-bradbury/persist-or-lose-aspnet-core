using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyWebApi.Models
{
    public class MyConverter : JsonConverter
    {
        // see http://www.newtonsoft.com/json/help/html/CustomJsonConverter.htm

        public override bool CanConvert(Type objectType)
        {
            Console.WriteLine($"Object Type: {objectType.FullName}");
            return objectType == typeof(TodoItem);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject json = JObject.Load(reader);
            return new TodoItem(json);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ((TodoItem)value).AsJObject().WriteTo(writer);
        }
    }
}