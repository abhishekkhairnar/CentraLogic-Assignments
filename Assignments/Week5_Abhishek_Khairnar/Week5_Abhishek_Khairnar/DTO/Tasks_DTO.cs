using Newtonsoft.Json;

namespace Week5_Abhishek_Khairnar.DTO
{
    public class Tasks_DTO
    {
        [JsonProperty(PropertyName = "taskId", NullValueHandling = NullValueHandling.Ignore)]
        public int TaskId { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }
}
