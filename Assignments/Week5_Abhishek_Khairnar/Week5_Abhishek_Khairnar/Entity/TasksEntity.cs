using Newtonsoft.Json;

namespace Week5_Abhishek_Khairnar.Model
{
    public class TasksEntity
    {
        // Required Fields
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public int Version { get; set; }
        public Boolean Archieved { get; set; }
        public DateTime? LastUpdated { get; set; }
        public Boolean isActive { get; set; }

        // Class Fields
        public string TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
