using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyWebApi.Models
{
    public class TodoItem
    {
        readonly JObject json;

        public TodoItem()
        {
            json = new JObject();
        }

        public TodoItem(JObject json)
        {
            this.json = json;
        }

        public JObject AsJObject()
        {
            return json;
        }

        public string Key
        {
            get
            {
                return json.Value<string>("key");
            }

            set
            {
                json["key"] = value;
            }
        }

        public string Name
        {
            get
            {
                return json.Value<string>("name");
            }

            set
            {
                json["name"] = value;
            }
        }

        public bool IsComplete
        {
            get
            {
                return json.Value<bool>("isComplete");
            }

            set
            {
                json["isComplete"] = value;
            }
        }
    }
}