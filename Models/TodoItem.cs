using Newtonsoft.Json.Linq;

namespace MyWebApi.Models
{
    public class TodoItem
    {
        JObject json = new JObject();

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